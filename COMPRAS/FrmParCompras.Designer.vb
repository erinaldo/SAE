<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmParCompras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmParCompras))
        Me.Tabcont = New DevComponents.DotNetBar.TabControl
        Me.TabControlPanel3 = New DevComponents.DotNetBar.TabControlPanel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rb_decN = New System.Windows.Forms.RadioButton
        Me.rb_decS = New System.Windows.Forms.RadioButton
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtcomentario = New System.Windows.Forms.TextBox
        Me.cmdguardar = New System.Windows.Forms.Button
        Me.cmdcancelar = New System.Windows.Forms.Button
        Me.gped = New System.Windows.Forms.GroupBox
        Me.pdf2cpp = New System.Windows.Forms.RadioButton
        Me.cmd_vp_cpp = New System.Windows.Forms.Button
        Me.cmdlogoccp = New System.Windows.Forms.Button
        Me.pdfcpp = New System.Windows.Forms.RadioButton
        Me.ticcpp = New System.Windows.Forms.RadioButton
        Me.imgfoto2 = New System.Windows.Forms.PictureBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lbnumero = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lbcaution = New System.Windows.Forms.Label
        Me.GroupBox23 = New System.Windows.Forms.GroupBox
        Me.pdf2fp = New System.Windows.Forms.RadioButton
        Me.cmd_vp_fp = New System.Windows.Forms.Button
        Me.cmdlogofp = New System.Windows.Forms.Button
        Me.pdffp = New System.Windows.Forms.RadioButton
        Me.ticfp = New System.Windows.Forms.RadioButton
        Me.imgfoto = New System.Windows.Forms.PictureBox
        Me.gcot = New System.Windows.Forms.GroupBox
        Me.pdf2ppf = New System.Windows.Forms.RadioButton
        Me.cmd_vp_ppf = New System.Windows.Forms.Button
        Me.cmdlogoppf = New System.Windows.Forms.Button
        Me.pdfppf = New System.Windows.Forms.RadioButton
        Me.ticppf = New System.Windows.Forms.RadioButton
        Me.imgfoto3 = New System.Windows.Forms.PictureBox
        Me.Tab3 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel
        Me.GroupBox18 = New System.Windows.Forms.GroupBox
        Me.rb_cant_fact1 = New System.Windows.Forms.RadioButton
        Me.rb_cant_fact2 = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rb_sol_num2 = New System.Windows.Forms.RadioButton
        Me.rb_sol_num1 = New System.Windows.Forms.RadioButton
        Me.GroupBox20 = New System.Windows.Forms.GroupBox
        Me.rb_imp_ap1 = New System.Windows.Forms.RadioButton
        Me.rb_imp_ap2 = New System.Windows.Forms.RadioButton
        Me.GroupBox21 = New System.Windows.Forms.GroupBox
        Me.rb_fs2 = New System.Windows.Forms.RadioButton
        Me.rb_fs1 = New System.Windows.Forms.RadioButton
        Me.Tab2 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.g_doc = New System.Windows.Forms.GroupBox
        Me.txt_ppf = New System.Windows.Forms.TextBox
        Me.txt_gas = New System.Windows.Forms.TextBox
        Me.txt_cpp = New System.Windows.Forms.TextBox
        Me.txt_aj = New System.Windows.Forms.TextBox
        Me.txt_fp = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.g_cta = New System.Windows.Forms.GroupBox
        Me.g_cuentas = New System.Windows.Forms.GroupBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.txt_cta_rtf = New System.Windows.Forms.TextBox
        Me.txt_cta_caja = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.txt_cta_ppf_d = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.txt_cta_banco = New System.Windows.Forms.TextBox
        Me.txt_cta_ppf_c = New System.Windows.Forms.TextBox
        Me.txt_cta_inv = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.txt_cta_cpp = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txt_cta_seg = New System.Windows.Forms.TextBox
        Me.txt_cta_gas = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.txt_cta_fle = New System.Windows.Forms.TextBox
        Me.txt_cta_com = New System.Windows.Forms.TextBox
        Me.txt_por_iva_d = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txt_por_iva_g = New System.Windows.Forms.TextBox
        Me.txt_cta_desc = New System.Windows.Forms.TextBox
        Me.txt_cta_iva_d = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txt_cta_iva_g = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rbcont2 = New System.Windows.Forms.RadioButton
        Me.rbcont1 = New System.Windows.Forms.RadioButton
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Tab1 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.mimenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.QueEsEstoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.lbprint = New System.Windows.Forms.Label
        Me.lbpara = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdsgt = New System.Windows.Forms.Button
        Me.cmdatras = New System.Windows.Forms.Button
        Me.OPF3 = New System.Windows.Forms.OpenFileDialog
        Me.OPF2 = New System.Windows.Forms.OpenFileDialog
        Me.OPF = New System.Windows.Forms.OpenFileDialog
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.imprimir = New System.Drawing.Printing.PrintDocument
        CType(Me.Tabcont, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tabcont.SuspendLayout()
        Me.TabControlPanel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.gped.SuspendLayout()
        CType(Me.imgfoto2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox23.SuspendLayout()
        CType(Me.imgfoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcot.SuspendLayout()
        CType(Me.imgfoto3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlPanel2.SuspendLayout()
        Me.GroupBox18.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox20.SuspendLayout()
        Me.GroupBox21.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.g_doc.SuspendLayout()
        Me.g_cta.SuspendLayout()
        Me.g_cuentas.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.mimenu.SuspendLayout()
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
        Me.Tabcont.Location = New System.Drawing.Point(5, 3)
        Me.Tabcont.Name = "Tabcont"
        Me.Tabcont.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Tabcont.SelectedTabIndex = 0
        Me.Tabcont.Size = New System.Drawing.Size(759, 389)
        Me.Tabcont.TabIndex = 0
        Me.Tabcont.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.Tabcont.Tabs.Add(Me.Tab1)
        Me.Tabcont.Tabs.Add(Me.Tab2)
        Me.Tabcont.Tabs.Add(Me.Tab3)
        Me.Tabcont.Text = "TabControl1"
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
        Me.GroupBox2.Controls.Add(Me.rb_decN)
        Me.GroupBox2.Controls.Add(Me.rb_decS)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(480, 303)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(265, 43)
        Me.GroupBox2.TabIndex = 104
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Imprimir Valores Con Decimales"
        '
        'rb_decN
        '
        Me.rb_decN.AutoSize = True
        Me.rb_decN.Location = New System.Drawing.Point(141, 19)
        Me.rb_decN.Name = "rb_decN"
        Me.rb_decN.Size = New System.Drawing.Size(123, 17)
        Me.rb_decN.TabIndex = 11
        Me.rb_decN.Text = "NO Ej: 1.000.000"
        Me.rb_decN.UseVisualStyleBackColor = True
        '
        'rb_decS
        '
        Me.rb_decS.AutoSize = True
        Me.rb_decS.Checked = True
        Me.rb_decS.Location = New System.Drawing.Point(7, 20)
        Me.rb_decS.Name = "rb_decS"
        Me.rb_decS.Size = New System.Drawing.Size(135, 17)
        Me.rb_decS.TabIndex = 10
        Me.rb_decS.TabStop = True
        Me.rb_decS.Text = "SI Ej: 1.000.000,00"
        Me.rb_decS.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox8.Controls.Add(Me.Label9)
        Me.GroupBox8.Controls.Add(Me.txtcomentario)
        Me.GroupBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(386, 182)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(370, 102)
        Me.GroupBox8.TabIndex = 102
        Me.GroupBox8.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(128, 13)
        Me.Label9.TabIndex = 104
        Me.Label9.Text = "COMENTARIO FINAL"
        '
        'txtcomentario
        '
        Me.txtcomentario.Location = New System.Drawing.Point(14, 36)
        Me.txtcomentario.Multiline = True
        Me.txtcomentario.Name = "txtcomentario"
        Me.txtcomentario.Size = New System.Drawing.Size(348, 57)
        Me.txtcomentario.TabIndex = 103
        '
        'cmdguardar
        '
        Me.cmdguardar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdguardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdguardar.ForeColor = System.Drawing.Color.Transparent
        Me.cmdguardar.Image = Global.SAE.My.Resources.Resources.gparam
        Me.cmdguardar.Location = New System.Drawing.Point(312, 290)
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
        Me.cmdcancelar.Location = New System.Drawing.Point(388, 290)
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
        Me.gped.Controls.Add(Me.pdf2cpp)
        Me.gped.Controls.Add(Me.cmd_vp_cpp)
        Me.gped.Controls.Add(Me.cmdlogoccp)
        Me.gped.Controls.Add(Me.pdfcpp)
        Me.gped.Controls.Add(Me.ticcpp)
        Me.gped.Controls.Add(Me.imgfoto2)
        Me.gped.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gped.Location = New System.Drawing.Point(385, 59)
        Me.gped.Name = "gped"
        Me.gped.Size = New System.Drawing.Size(370, 102)
        Me.gped.TabIndex = 95
        Me.gped.TabStop = False
        '
        'pdf2cpp
        '
        Me.pdf2cpp.AutoSize = True
        Me.pdf2cpp.Location = New System.Drawing.Point(14, 38)
        Me.pdf2cpp.Name = "pdf2cpp"
        Me.pdf2cpp.Size = New System.Drawing.Size(60, 17)
        Me.pdf2cpp.TabIndex = 93
        Me.pdf2cpp.Text = "PDF 2"
        Me.pdf2cpp.UseVisualStyleBackColor = True
        '
        'cmd_vp_cpp
        '
        Me.cmd_vp_cpp.Image = Global.SAE.My.Resources.Resources.b_view
        Me.cmd_vp_cpp.Location = New System.Drawing.Point(244, 9)
        Me.cmd_vp_cpp.Name = "cmd_vp_cpp"
        Me.cmd_vp_cpp.Size = New System.Drawing.Size(30, 30)
        Me.cmd_vp_cpp.TabIndex = 92
        Me.ToolTip1.SetToolTip(Me.cmd_vp_cpp, "vista previa")
        Me.cmd_vp_cpp.UseVisualStyleBackColor = True
        '
        'cmdlogoccp
        '
        Me.cmdlogoccp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdlogoccp.Location = New System.Drawing.Point(288, 77)
        Me.cmdlogoccp.Name = "cmdlogoccp"
        Me.cmdlogoccp.Size = New System.Drawing.Size(72, 20)
        Me.cmdlogoccp.TabIndex = 13
        Me.cmdlogoccp.Text = "Examinar..."
        Me.cmdlogoccp.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.cmdlogoccp.UseVisualStyleBackColor = True
        '
        'pdfcpp
        '
        Me.pdfcpp.AutoSize = True
        Me.pdfcpp.Checked = True
        Me.pdfcpp.Location = New System.Drawing.Point(14, 15)
        Me.pdfcpp.Name = "pdfcpp"
        Me.pdfcpp.Size = New System.Drawing.Size(49, 17)
        Me.pdfcpp.TabIndex = 12
        Me.pdfcpp.TabStop = True
        Me.pdfcpp.Text = "PDF"
        Me.pdfcpp.UseVisualStyleBackColor = True
        '
        'ticcpp
        '
        Me.ticcpp.AutoSize = True
        Me.ticcpp.Enabled = False
        Me.ticcpp.Location = New System.Drawing.Point(14, 61)
        Me.ticcpp.Name = "ticcpp"
        Me.ticcpp.Size = New System.Drawing.Size(69, 17)
        Me.ticcpp.TabIndex = 10
        Me.ticcpp.Text = "TICKET"
        Me.ticcpp.UseVisualStyleBackColor = True
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
        Me.Label5.Size = New System.Drawing.Size(301, 16)
        Me.Label5.TabIndex = 93
        Me.Label5.Text = "Formato pre-determinado de post-fechado"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label4.Location = New System.Drawing.Point(387, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(336, 16)
        Me.Label4.TabIndex = 92
        Me.Label4.Text = "Formato pre-determinado de cuentas por pagar"
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
        Me.Label2.Size = New System.Drawing.Size(282, 16)
        Me.Label2.TabIndex = 89
        Me.Label2.Text = "Formato pre-determinado de proveedor"
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
        Me.lbcaution.Location = New System.Drawing.Point(5, 303)
        Me.lbcaution.Name = "lbcaution"
        Me.lbcaution.Size = New System.Drawing.Size(305, 48)
        Me.lbcaution.TabIndex = 99
        Me.lbcaution.Text = "* Nota: para los reportes PDF se recomienda escoger una imagen JPG de " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  1. Tama" & _
            "ño: 100 x 100 pixeles aprox." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  2. Peso max:  1 MB aprox." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  "
        '
        'GroupBox23
        '
        Me.GroupBox23.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox23.Controls.Add(Me.pdf2fp)
        Me.GroupBox23.Controls.Add(Me.cmd_vp_fp)
        Me.GroupBox23.Controls.Add(Me.cmdlogofp)
        Me.GroupBox23.Controls.Add(Me.pdffp)
        Me.GroupBox23.Controls.Add(Me.ticfp)
        Me.GroupBox23.Controls.Add(Me.imgfoto)
        Me.GroupBox23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox23.Location = New System.Drawing.Point(6, 59)
        Me.GroupBox23.Name = "GroupBox23"
        Me.GroupBox23.Size = New System.Drawing.Size(370, 102)
        Me.GroupBox23.TabIndex = 94
        Me.GroupBox23.TabStop = False
        '
        'pdf2fp
        '
        Me.pdf2fp.AutoSize = True
        Me.pdf2fp.Location = New System.Drawing.Point(17, 38)
        Me.pdf2fp.Name = "pdf2fp"
        Me.pdf2fp.Size = New System.Drawing.Size(60, 17)
        Me.pdf2fp.TabIndex = 92
        Me.pdf2fp.Text = "PDF 2"
        Me.pdf2fp.UseVisualStyleBackColor = True
        '
        'cmd_vp_fp
        '
        Me.cmd_vp_fp.Image = Global.SAE.My.Resources.Resources.b_view
        Me.cmd_vp_fp.Location = New System.Drawing.Point(238, 9)
        Me.cmd_vp_fp.Name = "cmd_vp_fp"
        Me.cmd_vp_fp.Size = New System.Drawing.Size(30, 30)
        Me.cmd_vp_fp.TabIndex = 91
        Me.ToolTip1.SetToolTip(Me.cmd_vp_fp, "vista previa")
        Me.cmd_vp_fp.UseVisualStyleBackColor = True
        '
        'cmdlogofp
        '
        Me.cmdlogofp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdlogofp.Location = New System.Drawing.Point(283, 77)
        Me.cmdlogofp.Name = "cmdlogofp"
        Me.cmdlogofp.Size = New System.Drawing.Size(72, 20)
        Me.cmdlogofp.TabIndex = 13
        Me.cmdlogofp.Text = "Examinar..."
        Me.cmdlogofp.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.cmdlogofp.UseVisualStyleBackColor = True
        '
        'pdffp
        '
        Me.pdffp.AutoSize = True
        Me.pdffp.Checked = True
        Me.pdffp.Location = New System.Drawing.Point(17, 15)
        Me.pdffp.Name = "pdffp"
        Me.pdffp.Size = New System.Drawing.Size(60, 17)
        Me.pdffp.TabIndex = 12
        Me.pdffp.TabStop = True
        Me.pdffp.Text = "PDF 1"
        Me.pdffp.UseVisualStyleBackColor = True
        '
        'ticfp
        '
        Me.ticfp.AutoSize = True
        Me.ticfp.Location = New System.Drawing.Point(17, 61)
        Me.ticfp.Name = "ticfp"
        Me.ticfp.Size = New System.Drawing.Size(69, 17)
        Me.ticfp.TabIndex = 10
        Me.ticfp.Text = "TICKET"
        Me.ticfp.UseVisualStyleBackColor = True
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
        Me.gcot.Controls.Add(Me.pdf2ppf)
        Me.gcot.Controls.Add(Me.cmd_vp_ppf)
        Me.gcot.Controls.Add(Me.cmdlogoppf)
        Me.gcot.Controls.Add(Me.pdfppf)
        Me.gcot.Controls.Add(Me.ticppf)
        Me.gcot.Controls.Add(Me.imgfoto3)
        Me.gcot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gcot.Location = New System.Drawing.Point(6, 182)
        Me.gcot.Name = "gcot"
        Me.gcot.Size = New System.Drawing.Size(370, 102)
        Me.gcot.TabIndex = 96
        Me.gcot.TabStop = False
        '
        'pdf2ppf
        '
        Me.pdf2ppf.AutoSize = True
        Me.pdf2ppf.Location = New System.Drawing.Point(17, 41)
        Me.pdf2ppf.Name = "pdf2ppf"
        Me.pdf2ppf.Size = New System.Drawing.Size(60, 17)
        Me.pdf2ppf.TabIndex = 93
        Me.pdf2ppf.Text = "PDF 2"
        Me.pdf2ppf.UseVisualStyleBackColor = True
        '
        'cmd_vp_ppf
        '
        Me.cmd_vp_ppf.Image = Global.SAE.My.Resources.Resources.b_view
        Me.cmd_vp_ppf.Location = New System.Drawing.Point(238, 11)
        Me.cmd_vp_ppf.Name = "cmd_vp_ppf"
        Me.cmd_vp_ppf.Size = New System.Drawing.Size(30, 30)
        Me.cmd_vp_ppf.TabIndex = 92
        Me.ToolTip1.SetToolTip(Me.cmd_vp_ppf, "vista previa")
        Me.cmd_vp_ppf.UseVisualStyleBackColor = True
        '
        'cmdlogoppf
        '
        Me.cmdlogoppf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdlogoppf.Location = New System.Drawing.Point(284, 78)
        Me.cmdlogoppf.Name = "cmdlogoppf"
        Me.cmdlogoppf.Size = New System.Drawing.Size(72, 20)
        Me.cmdlogoppf.TabIndex = 13
        Me.cmdlogoppf.Text = "Examinar..."
        Me.cmdlogoppf.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.cmdlogoppf.UseVisualStyleBackColor = True
        '
        'pdfppf
        '
        Me.pdfppf.AutoSize = True
        Me.pdfppf.Checked = True
        Me.pdfppf.Location = New System.Drawing.Point(17, 15)
        Me.pdfppf.Name = "pdfppf"
        Me.pdfppf.Size = New System.Drawing.Size(49, 17)
        Me.pdfppf.TabIndex = 12
        Me.pdfppf.TabStop = True
        Me.pdfppf.Text = "PDF"
        Me.pdfppf.UseVisualStyleBackColor = True
        '
        'ticppf
        '
        Me.ticppf.AutoSize = True
        Me.ticppf.Enabled = False
        Me.ticppf.Location = New System.Drawing.Point(17, 66)
        Me.ticppf.Name = "ticppf"
        Me.ticppf.Size = New System.Drawing.Size(69, 17)
        Me.ticppf.TabIndex = 10
        Me.ticppf.Text = "TICKET"
        Me.ticppf.UseVisualStyleBackColor = True
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
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.GroupBox18)
        Me.TabControlPanel2.Controls.Add(Me.GroupBox1)
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
        Me.GroupBox18.Controls.Add(Me.rb_cant_fact1)
        Me.GroupBox18.Controls.Add(Me.rb_cant_fact2)
        Me.GroupBox18.Enabled = False
        Me.GroupBox18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox18.Location = New System.Drawing.Point(196, 122)
        Me.GroupBox18.Name = "GroupBox18"
        Me.GroupBox18.Size = New System.Drawing.Size(394, 43)
        Me.GroupBox18.TabIndex = 1
        Me.GroupBox18.TabStop = False
        Me.GroupBox18.Text = "Cancelar facturas con valores teniendo en cuenta la retención"
        '
        'rb_cant_fact1
        '
        Me.rb_cant_fact1.AutoSize = True
        Me.rb_cant_fact1.Checked = True
        Me.rb_cant_fact1.Location = New System.Drawing.Point(19, 18)
        Me.rb_cant_fact1.Name = "rb_cant_fact1"
        Me.rb_cant_fact1.Size = New System.Drawing.Size(43, 17)
        Me.rb_cant_fact1.TabIndex = 11
        Me.rb_cant_fact1.TabStop = True
        Me.rb_cant_fact1.Text = "NO"
        Me.rb_cant_fact1.UseVisualStyleBackColor = True
        '
        'rb_cant_fact2
        '
        Me.rb_cant_fact2.AutoSize = True
        Me.rb_cant_fact2.Location = New System.Drawing.Point(93, 18)
        Me.rb_cant_fact2.Name = "rb_cant_fact2"
        Me.rb_cant_fact2.Size = New System.Drawing.Size(37, 17)
        Me.rb_cant_fact2.TabIndex = 10
        Me.rb_cant_fact2.Text = "SI"
        Me.rb_cant_fact2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.rb_sol_num2)
        Me.GroupBox1.Controls.Add(Me.rb_sol_num1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(196, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(394, 43)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Solicitar Numero de Comprobante"
        '
        'rb_sol_num2
        '
        Me.rb_sol_num2.AutoSize = True
        Me.rb_sol_num2.Location = New System.Drawing.Point(93, 20)
        Me.rb_sol_num2.Name = "rb_sol_num2"
        Me.rb_sol_num2.Size = New System.Drawing.Size(43, 17)
        Me.rb_sol_num2.TabIndex = 11
        Me.rb_sol_num2.Text = "NO"
        Me.rb_sol_num2.UseVisualStyleBackColor = True
        '
        'rb_sol_num1
        '
        Me.rb_sol_num1.AutoSize = True
        Me.rb_sol_num1.Checked = True
        Me.rb_sol_num1.Location = New System.Drawing.Point(19, 20)
        Me.rb_sol_num1.Name = "rb_sol_num1"
        Me.rb_sol_num1.Size = New System.Drawing.Size(37, 17)
        Me.rb_sol_num1.TabIndex = 10
        Me.rb_sol_num1.TabStop = True
        Me.rb_sol_num1.Text = "SI"
        Me.rb_sol_num1.UseVisualStyleBackColor = True
        '
        'GroupBox20
        '
        Me.GroupBox20.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox20.Controls.Add(Me.rb_imp_ap1)
        Me.GroupBox20.Controls.Add(Me.rb_imp_ap2)
        Me.GroupBox20.Enabled = False
        Me.GroupBox20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox20.Location = New System.Drawing.Point(196, 249)
        Me.GroupBox20.Name = "GroupBox20"
        Me.GroupBox20.Size = New System.Drawing.Size(394, 43)
        Me.GroupBox20.TabIndex = 3
        Me.GroupBox20.TabStop = False
        Me.GroupBox20.Text = "Imprimir comprobantes solo si estan aprobados"
        '
        'rb_imp_ap1
        '
        Me.rb_imp_ap1.AutoSize = True
        Me.rb_imp_ap1.Checked = True
        Me.rb_imp_ap1.Location = New System.Drawing.Point(23, 20)
        Me.rb_imp_ap1.Name = "rb_imp_ap1"
        Me.rb_imp_ap1.Size = New System.Drawing.Size(43, 17)
        Me.rb_imp_ap1.TabIndex = 11
        Me.rb_imp_ap1.TabStop = True
        Me.rb_imp_ap1.Text = "NO"
        Me.rb_imp_ap1.UseVisualStyleBackColor = True
        '
        'rb_imp_ap2
        '
        Me.rb_imp_ap2.AutoSize = True
        Me.rb_imp_ap2.Location = New System.Drawing.Point(93, 20)
        Me.rb_imp_ap2.Name = "rb_imp_ap2"
        Me.rb_imp_ap2.Size = New System.Drawing.Size(37, 17)
        Me.rb_imp_ap2.TabIndex = 10
        Me.rb_imp_ap2.Text = "SI"
        Me.rb_imp_ap2.UseVisualStyleBackColor = True
        '
        'GroupBox21
        '
        Me.GroupBox21.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox21.Controls.Add(Me.rb_fs2)
        Me.GroupBox21.Controls.Add(Me.rb_fs1)
        Me.GroupBox21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox21.Location = New System.Drawing.Point(196, 189)
        Me.GroupBox21.Name = "GroupBox21"
        Me.GroupBox21.Size = New System.Drawing.Size(394, 43)
        Me.GroupBox21.TabIndex = 2
        Me.GroupBox21.TabStop = False
        Me.GroupBox21.Text = "Hacer que los fletes y seguros aumenten los valores el inventario"
        '
        'rb_fs2
        '
        Me.rb_fs2.AutoSize = True
        Me.rb_fs2.Location = New System.Drawing.Point(93, 20)
        Me.rb_fs2.Name = "rb_fs2"
        Me.rb_fs2.Size = New System.Drawing.Size(43, 17)
        Me.rb_fs2.TabIndex = 11
        Me.rb_fs2.Text = "NO"
        Me.rb_fs2.UseVisualStyleBackColor = True
        '
        'rb_fs1
        '
        Me.rb_fs1.AutoSize = True
        Me.rb_fs1.Checked = True
        Me.rb_fs1.Location = New System.Drawing.Point(19, 20)
        Me.rb_fs1.Name = "rb_fs1"
        Me.rb_fs1.Size = New System.Drawing.Size(37, 17)
        Me.rb_fs1.TabIndex = 10
        Me.rb_fs1.TabStop = True
        Me.rb_fs1.Text = "SI"
        Me.rb_fs1.UseVisualStyleBackColor = True
        '
        'Tab2
        '
        Me.Tab2.AttachedControl = Me.TabControlPanel2
        Me.Tab2.Name = "Tab2"
        Me.Tab2.Text = "Página 2/3"
        Me.Tab2.Visible = False
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.GroupBox4)
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
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox4.Controls.Add(Me.g_doc)
        Me.GroupBox4.Controls.Add(Me.Label24)
        Me.GroupBox4.Controls.Add(Me.g_cta)
        Me.GroupBox4.Controls.Add(Me.Label25)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(745, 354)
        Me.GroupBox4.TabIndex = 78
        Me.GroupBox4.TabStop = False
        '
        'g_doc
        '
        Me.g_doc.Controls.Add(Me.txt_ppf)
        Me.g_doc.Controls.Add(Me.txt_gas)
        Me.g_doc.Controls.Add(Me.txt_cpp)
        Me.g_doc.Controls.Add(Me.txt_aj)
        Me.g_doc.Controls.Add(Me.txt_fp)
        Me.g_doc.Controls.Add(Me.Label34)
        Me.g_doc.Controls.Add(Me.Label33)
        Me.g_doc.Controls.Add(Me.Label32)
        Me.g_doc.Controls.Add(Me.Label31)
        Me.g_doc.Controls.Add(Me.Label30)
        Me.g_doc.Controls.Add(Me.Label29)
        Me.g_doc.Controls.Add(Me.Label28)
        Me.g_doc.Controls.Add(Me.Label12)
        Me.g_doc.Location = New System.Drawing.Point(5, 63)
        Me.g_doc.Name = "g_doc"
        Me.g_doc.Size = New System.Drawing.Size(229, 282)
        Me.g_doc.TabIndex = 0
        Me.g_doc.TabStop = False
        '
        'txt_ppf
        '
        Me.txt_ppf.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txt_ppf.Location = New System.Drawing.Point(169, 208)
        Me.txt_ppf.Name = "txt_ppf"
        Me.txt_ppf.ReadOnly = True
        Me.txt_ppf.ShortcutsEnabled = False
        Me.txt_ppf.Size = New System.Drawing.Size(41, 20)
        Me.txt_ppf.TabIndex = 4
        '
        'txt_gas
        '
        Me.txt_gas.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txt_gas.Location = New System.Drawing.Point(169, 181)
        Me.txt_gas.Name = "txt_gas"
        Me.txt_gas.ReadOnly = True
        Me.txt_gas.ShortcutsEnabled = False
        Me.txt_gas.Size = New System.Drawing.Size(41, 20)
        Me.txt_gas.TabIndex = 3
        '
        'txt_cpp
        '
        Me.txt_cpp.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txt_cpp.Location = New System.Drawing.Point(169, 154)
        Me.txt_cpp.Name = "txt_cpp"
        Me.txt_cpp.ReadOnly = True
        Me.txt_cpp.ShortcutsEnabled = False
        Me.txt_cpp.Size = New System.Drawing.Size(41, 20)
        Me.txt_cpp.TabIndex = 2
        '
        'txt_aj
        '
        Me.txt_aj.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txt_aj.Location = New System.Drawing.Point(169, 73)
        Me.txt_aj.Name = "txt_aj"
        Me.txt_aj.ReadOnly = True
        Me.txt_aj.ShortcutsEnabled = False
        Me.txt_aj.Size = New System.Drawing.Size(41, 20)
        Me.txt_aj.TabIndex = 1
        '
        'txt_fp
        '
        Me.txt_fp.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txt_fp.Location = New System.Drawing.Point(169, 43)
        Me.txt_fp.Name = "txt_fp"
        Me.txt_fp.ReadOnly = True
        Me.txt_fp.ShortcutsEnabled = False
        Me.txt_fp.Size = New System.Drawing.Size(41, 20)
        Me.txt_fp.TabIndex = 0
        '
        'Label34
        '
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Brown
        Me.Label34.Location = New System.Drawing.Point(5, 12)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(220, 32)
        Me.Label34.TabIndex = 173
        Me.Label34.Text = "FACTURAS DE COMPRAS"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label33.Location = New System.Drawing.Point(6, 211)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(130, 13)
        Me.Label33.TabIndex = 172
        Me.Label33.Text = "Pagos Post-Fechados"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label32.Location = New System.Drawing.Point(6, 184)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(46, 13)
        Me.Label32.TabIndex = 171
        Me.Label32.Text = "Gastos"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label31.Location = New System.Drawing.Point(6, 157)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(113, 13)
        Me.Label31.TabIndex = 170
        Me.Label31.Text = "Cuentas Por Pagar"
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Brown
        Me.Label30.Location = New System.Drawing.Point(7, 120)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(216, 32)
        Me.Label30.TabIndex = 169
        Me.Label30.Text = "COMPROBANTES DE EGRESOS"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Brown
        Me.Label29.Location = New System.Drawing.Point(6, 257)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(219, 12)
        Me.Label29.TabIndex = 168
        Me.Label29.Text = "* Doble click para seleccionar documentos"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label28.Location = New System.Drawing.Point(6, 76)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(134, 13)
        Me.Label28.TabIndex = 156
        Me.Label28.Text = "Documento de Ajustes"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label12.Location = New System.Drawing.Point(5, 46)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(143, 13)
        Me.Label12.TabIndex = 155
        Me.Label12.Text = "Factura de Proveedores"
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Brown
        Me.Label24.Location = New System.Drawing.Point(101, 19)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(549, 32)
        Me.Label24.TabIndex = 76
        Me.Label24.Text = "ESTOS PARAMETROS SON OBLIGATORIOS PARA" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "LOS DOCUMENTOS DE COMPRAS Y CTAS X PAGAR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'g_cta
        '
        Me.g_cta.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.g_cta.Controls.Add(Me.g_cuentas)
        Me.g_cta.Controls.Add(Me.GroupBox3)
        Me.g_cta.Controls.Add(Me.Label14)
        Me.g_cta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.g_cta.Location = New System.Drawing.Point(236, 64)
        Me.g_cta.Name = "g_cta"
        Me.g_cta.Size = New System.Drawing.Size(505, 281)
        Me.g_cta.TabIndex = 1
        Me.g_cta.TabStop = False
        '
        'g_cuentas
        '
        Me.g_cuentas.Controls.Add(Me.Label22)
        Me.g_cuentas.Controls.Add(Me.Label1)
        Me.g_cuentas.Controls.Add(Me.Label23)
        Me.g_cuentas.Controls.Add(Me.txt_cta_rtf)
        Me.g_cuentas.Controls.Add(Me.txt_cta_caja)
        Me.g_cuentas.Controls.Add(Me.Label27)
        Me.g_cuentas.Controls.Add(Me.Label21)
        Me.g_cuentas.Controls.Add(Me.txt_cta_ppf_d)
        Me.g_cuentas.Controls.Add(Me.Label26)
        Me.g_cuentas.Controls.Add(Me.Label40)
        Me.g_cuentas.Controls.Add(Me.txt_cta_banco)
        Me.g_cuentas.Controls.Add(Me.txt_cta_ppf_c)
        Me.g_cuentas.Controls.Add(Me.txt_cta_inv)
        Me.g_cuentas.Controls.Add(Me.Label39)
        Me.g_cuentas.Controls.Add(Me.Label20)
        Me.g_cuentas.Controls.Add(Me.txt_cta_cpp)
        Me.g_cuentas.Controls.Add(Me.Label19)
        Me.g_cuentas.Controls.Add(Me.txt_cta_seg)
        Me.g_cuentas.Controls.Add(Me.txt_cta_gas)
        Me.g_cuentas.Controls.Add(Me.Label13)
        Me.g_cuentas.Controls.Add(Me.Label18)
        Me.g_cuentas.Controls.Add(Me.txt_cta_fle)
        Me.g_cuentas.Controls.Add(Me.txt_cta_com)
        Me.g_cuentas.Controls.Add(Me.txt_por_iva_d)
        Me.g_cuentas.Controls.Add(Me.Label17)
        Me.g_cuentas.Controls.Add(Me.txt_por_iva_g)
        Me.g_cuentas.Controls.Add(Me.txt_cta_desc)
        Me.g_cuentas.Controls.Add(Me.txt_cta_iva_d)
        Me.g_cuentas.Controls.Add(Me.Label16)
        Me.g_cuentas.Controls.Add(Me.Label10)
        Me.g_cuentas.Controls.Add(Me.txt_cta_iva_g)
        Me.g_cuentas.Controls.Add(Me.Label15)
        Me.g_cuentas.Controls.Add(Me.Label7)
        Me.g_cuentas.Location = New System.Drawing.Point(5, 58)
        Me.g_cuentas.Name = "g_cuentas"
        Me.g_cuentas.Size = New System.Drawing.Size(495, 215)
        Me.g_cuentas.TabIndex = 176
        Me.g_cuentas.TabStop = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label22.Location = New System.Drawing.Point(4, 16)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(32, 13)
        Me.Label22.TabIndex = 154
        Me.Label22.Text = "Caja"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label1.Location = New System.Drawing.Point(189, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 175
        Me.Label1.Text = "Rete. Fuente"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Brown
        Me.Label23.Location = New System.Drawing.Point(4, 198)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(198, 12)
        Me.Label23.TabIndex = 167
        Me.Label23.Text = "* Doble click para seleccionar cuentas"
        '
        'txt_cta_rtf
        '
        Me.txt_cta_rtf.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txt_cta_rtf.Location = New System.Drawing.Point(345, 66)
        Me.txt_cta_rtf.Name = "txt_cta_rtf"
        Me.txt_cta_rtf.ReadOnly = True
        Me.txt_cta_rtf.ShortcutsEnabled = False
        Me.txt_cta_rtf.Size = New System.Drawing.Size(84, 20)
        Me.txt_cta_rtf.TabIndex = 12
        '
        'txt_cta_caja
        '
        Me.txt_cta_caja.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txt_cta_caja.Location = New System.Drawing.Point(100, 13)
        Me.txt_cta_caja.Name = "txt_cta_caja"
        Me.txt_cta_caja.ReadOnly = True
        Me.txt_cta_caja.ShortcutsEnabled = False
        Me.txt_cta_caja.Size = New System.Drawing.Size(84, 20)
        Me.txt_cta_caja.TabIndex = 1
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label27.Location = New System.Drawing.Point(190, 171)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(155, 13)
        Me.Label27.TabIndex = 173
        Me.Label27.Text = "Pagos Post-Fechados(DB)"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label21.Location = New System.Drawing.Point(4, 42)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(49, 13)
        Me.Label21.TabIndex = 155
        Me.Label21.Text = "Bancos"
        '
        'txt_cta_ppf_d
        '
        Me.txt_cta_ppf_d.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txt_cta_ppf_d.Location = New System.Drawing.Point(345, 167)
        Me.txt_cta_ppf_d.Name = "txt_cta_ppf_d"
        Me.txt_cta_ppf_d.ReadOnly = True
        Me.txt_cta_ppf_d.ShortcutsEnabled = False
        Me.txt_cta_ppf_d.Size = New System.Drawing.Size(84, 20)
        Me.txt_cta_ppf_d.TabIndex = 16
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label26.Location = New System.Drawing.Point(8, 171)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(70, 13)
        Me.Label26.TabIndex = 171
        Me.Label26.Text = "Inventarios"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label40.Location = New System.Drawing.Point(190, 144)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(155, 13)
        Me.Label40.TabIndex = 169
        Me.Label40.Text = "Pagos Post-Fechados(CR)"
        '
        'txt_cta_banco
        '
        Me.txt_cta_banco.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txt_cta_banco.Location = New System.Drawing.Point(100, 39)
        Me.txt_cta_banco.Name = "txt_cta_banco"
        Me.txt_cta_banco.ReadOnly = True
        Me.txt_cta_banco.ShortcutsEnabled = False
        Me.txt_cta_banco.Size = New System.Drawing.Size(84, 20)
        Me.txt_cta_banco.TabIndex = 2
        '
        'txt_cta_ppf_c
        '
        Me.txt_cta_ppf_c.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txt_cta_ppf_c.Location = New System.Drawing.Point(345, 142)
        Me.txt_cta_ppf_c.Name = "txt_cta_ppf_c"
        Me.txt_cta_ppf_c.ReadOnly = True
        Me.txt_cta_ppf_c.ShortcutsEnabled = False
        Me.txt_cta_ppf_c.Size = New System.Drawing.Size(84, 20)
        Me.txt_cta_ppf_c.TabIndex = 15
        '
        'txt_cta_inv
        '
        Me.txt_cta_inv.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txt_cta_inv.Location = New System.Drawing.Point(101, 167)
        Me.txt_cta_inv.Name = "txt_cta_inv"
        Me.txt_cta_inv.ReadOnly = True
        Me.txt_cta_inv.ShortcutsEnabled = False
        Me.txt_cta_inv.Size = New System.Drawing.Size(84, 20)
        Me.txt_cta_inv.TabIndex = 7
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label39.Location = New System.Drawing.Point(190, 118)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(53, 13)
        Me.Label39.TabIndex = 168
        Me.Label39.Text = "Seguros"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label20.Location = New System.Drawing.Point(3, 69)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(96, 13)
        Me.Label20.TabIndex = 156
        Me.Label20.Text = "Ctas. Por Pagar"
        '
        'txt_cta_cpp
        '
        Me.txt_cta_cpp.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txt_cta_cpp.Location = New System.Drawing.Point(100, 65)
        Me.txt_cta_cpp.Name = "txt_cta_cpp"
        Me.txt_cta_cpp.ReadOnly = True
        Me.txt_cta_cpp.ShortcutsEnabled = False
        Me.txt_cta_cpp.Size = New System.Drawing.Size(84, 20)
        Me.txt_cta_cpp.TabIndex = 3
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label19.Location = New System.Drawing.Point(4, 93)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(46, 13)
        Me.Label19.TabIndex = 157
        Me.Label19.Text = "Gastos"
        '
        'txt_cta_seg
        '
        Me.txt_cta_seg.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txt_cta_seg.Location = New System.Drawing.Point(345, 117)
        Me.txt_cta_seg.Name = "txt_cta_seg"
        Me.txt_cta_seg.ReadOnly = True
        Me.txt_cta_seg.ShortcutsEnabled = False
        Me.txt_cta_seg.Size = New System.Drawing.Size(84, 20)
        Me.txt_cta_seg.TabIndex = 14
        '
        'txt_cta_gas
        '
        Me.txt_cta_gas.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txt_cta_gas.Location = New System.Drawing.Point(100, 90)
        Me.txt_cta_gas.Name = "txt_cta_gas"
        Me.txt_cta_gas.ReadOnly = True
        Me.txt_cta_gas.ShortcutsEnabled = False
        Me.txt_cta_gas.Size = New System.Drawing.Size(84, 20)
        Me.txt_cta_gas.TabIndex = 4
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label13.Location = New System.Drawing.Point(190, 93)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 13)
        Me.Label13.TabIndex = 165
        Me.Label13.Text = "Fletes"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label18.Location = New System.Drawing.Point(5, 118)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(55, 13)
        Me.Label18.TabIndex = 158
        Me.Label18.Text = "Compras"
        '
        'txt_cta_fle
        '
        Me.txt_cta_fle.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txt_cta_fle.Location = New System.Drawing.Point(345, 90)
        Me.txt_cta_fle.Name = "txt_cta_fle"
        Me.txt_cta_fle.ReadOnly = True
        Me.txt_cta_fle.ShortcutsEnabled = False
        Me.txt_cta_fle.Size = New System.Drawing.Size(84, 20)
        Me.txt_cta_fle.TabIndex = 13
        '
        'txt_cta_com
        '
        Me.txt_cta_com.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txt_cta_com.Location = New System.Drawing.Point(100, 116)
        Me.txt_cta_com.Name = "txt_cta_com"
        Me.txt_cta_com.ReadOnly = True
        Me.txt_cta_com.ShortcutsEnabled = False
        Me.txt_cta_com.Size = New System.Drawing.Size(84, 20)
        Me.txt_cta_com.TabIndex = 5
        '
        'txt_por_iva_d
        '
        Me.txt_por_iva_d.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txt_por_iva_d.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_por_iva_d.ForeColor = System.Drawing.Color.SteelBlue
        Me.txt_por_iva_d.Location = New System.Drawing.Point(434, 37)
        Me.txt_por_iva_d.MaxLength = 5
        Me.txt_por_iva_d.Name = "txt_por_iva_d"
        Me.txt_por_iva_d.ShortcutsEnabled = False
        Me.txt_por_iva_d.Size = New System.Drawing.Size(42, 20)
        Me.txt_por_iva_d.TabIndex = 11
        Me.txt_por_iva_d.Text = "16,00"
        Me.txt_por_iva_d.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label17.Location = New System.Drawing.Point(5, 144)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(78, 13)
        Me.Label17.TabIndex = 159
        Me.Label17.Text = "Descuentos "
        '
        'txt_por_iva_g
        '
        Me.txt_por_iva_g.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txt_por_iva_g.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_por_iva_g.ForeColor = System.Drawing.Color.SteelBlue
        Me.txt_por_iva_g.Location = New System.Drawing.Point(434, 13)
        Me.txt_por_iva_g.MaxLength = 5
        Me.txt_por_iva_g.Name = "txt_por_iva_g"
        Me.txt_por_iva_g.ShortcutsEnabled = False
        Me.txt_por_iva_g.Size = New System.Drawing.Size(42, 20)
        Me.txt_por_iva_g.TabIndex = 9
        Me.txt_por_iva_g.Text = "16,00"
        Me.txt_por_iva_g.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_cta_desc
        '
        Me.txt_cta_desc.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txt_cta_desc.Location = New System.Drawing.Point(100, 141)
        Me.txt_cta_desc.Name = "txt_cta_desc"
        Me.txt_cta_desc.ReadOnly = True
        Me.txt_cta_desc.ShortcutsEnabled = False
        Me.txt_cta_desc.Size = New System.Drawing.Size(84, 20)
        Me.txt_cta_desc.TabIndex = 6
        '
        'txt_cta_iva_d
        '
        Me.txt_cta_iva_d.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txt_cta_iva_d.Location = New System.Drawing.Point(345, 38)
        Me.txt_cta_iva_d.Name = "txt_cta_iva_d"
        Me.txt_cta_iva_d.ReadOnly = True
        Me.txt_cta_iva_d.ShortcutsEnabled = False
        Me.txt_cta_iva_d.Size = New System.Drawing.Size(84, 20)
        Me.txt_cta_iva_d.TabIndex = 10
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label16.Location = New System.Drawing.Point(190, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(93, 13)
        Me.Label16.TabIndex = 160
        Me.Label16.Text = "I.V.A por pagar"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label10.Location = New System.Drawing.Point(190, 42)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(108, 13)
        Me.Label10.TabIndex = 161
        Me.Label10.Text = "I.V.A descontable"
        '
        'txt_cta_iva_g
        '
        Me.txt_cta_iva_g.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txt_cta_iva_g.Location = New System.Drawing.Point(345, 13)
        Me.txt_cta_iva_g.Name = "txt_cta_iva_g"
        Me.txt_cta_iva_g.ReadOnly = True
        Me.txt_cta_iva_g.ShortcutsEnabled = False
        Me.txt_cta_iva_g.Size = New System.Drawing.Size(84, 20)
        Me.txt_cta_iva_g.TabIndex = 8
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label15.Location = New System.Drawing.Point(475, 41)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(16, 13)
        Me.Label15.TabIndex = 162
        Me.Label15.Text = "%"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label7.Location = New System.Drawing.Point(475, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(16, 13)
        Me.Label7.TabIndex = 163
        Me.Label7.Text = "%"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbcont2)
        Me.GroupBox3.Controls.Add(Me.rbcont1)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(316, 11)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(153, 41)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "¿Interfaz Contable?"
        '
        'rbcont2
        '
        Me.rbcont2.AutoSize = True
        Me.rbcont2.Checked = True
        Me.rbcont2.Location = New System.Drawing.Point(98, 20)
        Me.rbcont2.Name = "rbcont2"
        Me.rbcont2.Size = New System.Drawing.Size(43, 17)
        Me.rbcont2.TabIndex = 1
        Me.rbcont2.TabStop = True
        Me.rbcont2.Text = "NO"
        Me.rbcont2.UseVisualStyleBackColor = True
        '
        'rbcont1
        '
        Me.rbcont1.AutoSize = True
        Me.rbcont1.Location = New System.Drawing.Point(27, 20)
        Me.rbcont1.Name = "rbcont1"
        Me.rbcont1.Size = New System.Drawing.Size(41, 17)
        Me.rbcont1.TabIndex = 0
        Me.rbcont1.Text = "SI "
        Me.rbcont1.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label14.Location = New System.Drawing.Point(7, 25)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(293, 13)
        Me.Label14.TabIndex = 166
        Me.Label14.Text = "CUENTAS QUE AFECTAN CUENTAS POR PAGAR"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Brown
        Me.Label25.Location = New System.Drawing.Point(92, 38)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(560, 16)
        Me.Label25.TabIndex = 77
        Me.Label25.Text = "_____________________________________________________________________"
        '
        'Tab1
        '
        Me.Tab1.AttachedControl = Me.TabControlPanel1
        Me.Tab1.Name = "Tab1"
        Me.Tab1.Text = "Página 1/3"
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
        'GroupPanel2
        '
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.lbprint)
        Me.GroupPanel2.Controls.Add(Me.lbpara)
        Me.GroupPanel2.Controls.Add(Me.Label6)
        Me.GroupPanel2.Controls.Add(Me.cmdsgt)
        Me.GroupPanel2.Controls.Add(Me.cmdatras)
        Me.GroupPanel2.Location = New System.Drawing.Point(5, 397)
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
        Me.GroupPanel2.TabIndex = 1
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
        Me.lbpara.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(189, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(393, 24)
        Me.Label6.TabIndex = 81
        Me.Label6.Text = "SAE PARAMETRIZACIÓN DE COMPRAS"
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
        'OPF3
        '
        Me.OPF3.FileName = "OpenFileDialog1"
        '
        'OPF2
        '
        Me.OPF2.FileName = "OpenFileDialog1"
        '
        'OPF
        '
        Me.OPF.FileName = "OpenFileDialog1"
        '
        'FrmParCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(769, 487)
        Me.Controls.Add(Me.Tabcont)
        Me.Controls.Add(Me.GroupPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmParCompras"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Parametros Compras y Cuentas por Pagar"
        CType(Me.Tabcont, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tabcont.ResumeLayout(False)
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
        Me.TabControlPanel2.ResumeLayout(False)
        Me.GroupBox18.ResumeLayout(False)
        Me.GroupBox18.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox20.ResumeLayout(False)
        Me.GroupBox20.PerformLayout()
        Me.GroupBox21.ResumeLayout(False)
        Me.GroupBox21.PerformLayout()
        Me.TabControlPanel1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.g_doc.ResumeLayout(False)
        Me.g_doc.PerformLayout()
        Me.g_cta.ResumeLayout(False)
        Me.g_cta.PerformLayout()
        Me.g_cuentas.ResumeLayout(False)
        Me.g_cuentas.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.mimenu.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tabcont As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Tab1 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents GroupBox18 As System.Windows.Forms.GroupBox
    Friend WithEvents rb_cant_fact1 As System.Windows.Forms.RadioButton
    Friend WithEvents rb_cant_fact2 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rb_sol_num2 As System.Windows.Forms.RadioButton
    Friend WithEvents rb_sol_num1 As System.Windows.Forms.RadioButton
    Friend WithEvents mimenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents QueEsEstoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox20 As System.Windows.Forms.GroupBox
    Friend WithEvents rb_imp_ap1 As System.Windows.Forms.RadioButton
    Friend WithEvents rb_imp_ap2 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox21 As System.Windows.Forms.GroupBox
    Friend WithEvents rb_fs2 As System.Windows.Forms.RadioButton
    Friend WithEvents rb_fs1 As System.Windows.Forms.RadioButton
    Friend WithEvents Tab2 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel3 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtcomentario As System.Windows.Forms.TextBox
    Friend WithEvents cmdguardar As System.Windows.Forms.Button
    Friend WithEvents cmdcancelar As System.Windows.Forms.Button
    Friend WithEvents gped As System.Windows.Forms.GroupBox
    Friend WithEvents pdf2cpp As System.Windows.Forms.RadioButton
    Friend WithEvents cmd_vp_cpp As System.Windows.Forms.Button
    Friend WithEvents cmdlogoccp As System.Windows.Forms.Button
    Friend WithEvents pdfcpp As System.Windows.Forms.RadioButton
    Friend WithEvents ticcpp As System.Windows.Forms.RadioButton
    Friend WithEvents imgfoto2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbnumero As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbcaution As System.Windows.Forms.Label
    Friend WithEvents GroupBox23 As System.Windows.Forms.GroupBox
    Friend WithEvents pdf2fp As System.Windows.Forms.RadioButton
    Friend WithEvents cmd_vp_fp As System.Windows.Forms.Button
    Friend WithEvents cmdlogofp As System.Windows.Forms.Button
    Friend WithEvents pdffp As System.Windows.Forms.RadioButton
    Friend WithEvents ticfp As System.Windows.Forms.RadioButton
    Friend WithEvents imgfoto As System.Windows.Forms.PictureBox
    Friend WithEvents gcot As System.Windows.Forms.GroupBox
    Friend WithEvents pdf2ppf As System.Windows.Forms.RadioButton
    Friend WithEvents cmd_vp_ppf As System.Windows.Forms.Button
    Friend WithEvents cmdlogoppf As System.Windows.Forms.Button
    Friend WithEvents pdfppf As System.Windows.Forms.RadioButton
    Friend WithEvents ticppf As System.Windows.Forms.RadioButton
    Friend WithEvents imgfoto3 As System.Windows.Forms.PictureBox
    Friend WithEvents Tab3 As DevComponents.DotNetBar.TabItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents lbprint As System.Windows.Forms.Label
    Friend WithEvents lbpara As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdsgt As System.Windows.Forms.Button
    Friend WithEvents cmdatras As System.Windows.Forms.Button
    Friend WithEvents OPF3 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents OPF2 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents OPF As System.Windows.Forms.OpenFileDialog
    Friend WithEvents imprimir As System.Drawing.Printing.PrintDocument
    Friend WithEvents g_cta As System.Windows.Forms.GroupBox
    Friend WithEvents txt_cta_ppf_d As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txt_cta_ppf_c As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbcont2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbcont1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_cta_seg As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_cta_fle As System.Windows.Forms.TextBox
    Friend WithEvents txt_por_iva_d As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_por_iva_g As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_cta_iva_d As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_cta_iva_g As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txt_cta_desc As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txt_cta_com As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txt_cta_gas As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txt_cta_cpp As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txt_cta_banco As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txt_cta_caja As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txt_cta_inv As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents g_doc As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txt_ppf As System.Windows.Forms.TextBox
    Friend WithEvents txt_gas As System.Windows.Forms.TextBox
    Friend WithEvents txt_cpp As System.Windows.Forms.TextBox
    Friend WithEvents txt_aj As System.Windows.Forms.TextBox
    Friend WithEvents txt_fp As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_cta_rtf As System.Windows.Forms.TextBox
    Friend WithEvents g_cuentas As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rb_decN As System.Windows.Forms.RadioButton
    Friend WithEvents rb_decS As System.Windows.Forms.RadioButton
End Class
