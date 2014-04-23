<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmParInmob
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmParInmob))
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtcta_v = New System.Windows.Forms.TextBox
        Me.txtcta_iva = New System.Windows.Forms.TextBox
        Me.txtobs = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.e2 = New System.Windows.Forms.RadioButton
        Me.e1 = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtcta_rtf = New System.Windows.Forms.TextBox
        Me.txtctaac = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtctaad = New System.Windows.Forms.TextBox
        Me.txtcta_c = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtcta_cli = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtctaing = New System.Windows.Forms.TextBox
        Me.imgfoto = New System.Windows.Forms.PictureBox
        Me.cmdlogofac = New System.Windows.Forms.Button
        Me.txtint = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtdocF = New System.Windows.Forms.TextBox
        Me.cbdocF = New System.Windows.Forms.ComboBox
        Me.cbfac = New System.Windows.Forms.CheckBox
        Me.cmdNuevo = New System.Windows.Forms.Button
        Me.txttipo1 = New System.Windows.Forms.TextBox
        Me.pre1 = New System.Windows.Forms.TextBox
        Me.txtn1 = New System.Windows.Forms.TextBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.ini1 = New System.Windows.Forms.NumericUpDown
        Me.cbres1 = New System.Windows.Forms.ComboBox
        Me.fin1 = New System.Windows.Forms.NumericUpDown
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.reso1 = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.feclim1 = New System.Windows.Forms.DateTimePicker
        Me.fecexp1 = New System.Windows.Forms.DateTimePicker
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.lbcaution = New System.Windows.Forms.Label
        Me.cmdcancelar = New System.Windows.Forms.Button
        Me.cmdguardar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.OPF = New System.Windows.Forms.OpenFileDialog
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.imgfoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ini1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fin1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(371, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Observaciones Facturacion"
        '
        'txtcta_v
        '
        Me.txtcta_v.BackColor = System.Drawing.Color.White
        Me.txtcta_v.Location = New System.Drawing.Point(94, 34)
        Me.txtcta_v.Name = "txtcta_v"
        Me.txtcta_v.Size = New System.Drawing.Size(100, 20)
        Me.txtcta_v.TabIndex = 1
        '
        'txtcta_iva
        '
        Me.txtcta_iva.BackColor = System.Drawing.Color.White
        Me.txtcta_iva.Location = New System.Drawing.Point(94, 61)
        Me.txtcta_iva.Name = "txtcta_iva"
        Me.txtcta_iva.ShortcutsEnabled = False
        Me.txtcta_iva.Size = New System.Drawing.Size(100, 20)
        Me.txtcta_iva.TabIndex = 2
        '
        'txtobs
        '
        Me.txtobs.Location = New System.Drawing.Point(371, 117)
        Me.txtobs.Multiline = True
        Me.txtobs.Name = "txtobs"
        Me.txtobs.Size = New System.Drawing.Size(294, 74)
        Me.txtobs.TabIndex = 12
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtctaing)
        Me.GroupBox1.Controls.Add(Me.imgfoto)
        Me.GroupBox1.Controls.Add(Me.cmdlogofac)
        Me.GroupBox1.Controls.Add(Me.txtobs)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtint)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(671, 362)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.e2)
        Me.GroupBox5.Controls.Add(Me.e1)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(8, 105)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(163, 53)
        Me.GroupBox5.TabIndex = 204
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Editar los contratos"
        '
        'e2
        '
        Me.e2.AutoSize = True
        Me.e2.Checked = True
        Me.e2.Location = New System.Drawing.Point(69, 23)
        Me.e2.Name = "e2"
        Me.e2.Size = New System.Drawing.Size(88, 17)
        Me.e2.TabIndex = 18
        Me.e2.TabStop = True
        Me.e2.Text = "Solo Admin"
        Me.e2.UseVisualStyleBackColor = True
        '
        'e1
        '
        Me.e1.AutoSize = True
        Me.e1.Location = New System.Drawing.Point(3, 23)
        Me.e1.Name = "e1"
        Me.e1.Size = New System.Drawing.Size(60, 17)
        Me.e1.TabIndex = 17
        Me.e1.Text = "Todos"
        Me.e1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.txtcta_rtf)
        Me.GroupBox3.Controls.Add(Me.txtcta_iva)
        Me.GroupBox3.Controls.Add(Me.txtctaac)
        Me.GroupBox3.Controls.Add(Me.txtcta_v)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtctaad)
        Me.GroupBox3.Controls.Add(Me.txtcta_c)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtcta_cli)
        Me.GroupBox3.Location = New System.Drawing.Point(130, 198)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(403, 157)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label14.Location = New System.Drawing.Point(130, 14)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(171, 13)
        Me.Label14.TabIndex = 191
        Me.Label14.Text = "MOVIMIENTOS CONTABLES"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label9.Location = New System.Drawing.Point(12, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 13)
        Me.Label9.TabIndex = 190
        Me.Label9.Text = "I.V.A "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label7.Location = New System.Drawing.Point(12, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 189
        Me.Label7.Text = "Cta x Cobrar"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Brown
        Me.Label21.Location = New System.Drawing.Point(5, 142)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(227, 13)
        Me.Label21.TabIndex = 192
        Me.Label21.Text = "* Doble click para seleccionar cuentas"
        '
        'txtcta_rtf
        '
        Me.txtcta_rtf.BackColor = System.Drawing.Color.White
        Me.txtcta_rtf.Location = New System.Drawing.Point(94, 87)
        Me.txtcta_rtf.Name = "txtcta_rtf"
        Me.txtcta_rtf.ShortcutsEnabled = False
        Me.txtcta_rtf.Size = New System.Drawing.Size(100, 20)
        Me.txtcta_rtf.TabIndex = 3
        '
        'txtctaac
        '
        Me.txtctaac.BackColor = System.Drawing.Color.White
        Me.txtctaac.Location = New System.Drawing.Point(291, 89)
        Me.txtctaac.Name = "txtctaac"
        Me.txtctaac.Size = New System.Drawing.Size(100, 20)
        Me.txtctaac.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.txtctaac, "Anticipo de Clinetes")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label3.Location = New System.Drawing.Point(12, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 194
        Me.Label3.Text = "ReteFuente"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label11.Location = New System.Drawing.Point(13, 112)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 26)
        Me.Label11.TabIndex = 202
        Me.Label11.Text = "Comision " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ingresos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label5.Location = New System.Drawing.Point(208, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 196
        Me.Label5.Text = "Cta x Pagar"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label10.Location = New System.Drawing.Point(211, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 13)
        Me.Label10.TabIndex = 199
        Me.Label10.Text = "Acuerdo Db"
        '
        'txtctaad
        '
        Me.txtctaad.BackColor = System.Drawing.Color.White
        Me.txtctaad.Location = New System.Drawing.Point(291, 60)
        Me.txtctaad.Name = "txtctaad"
        Me.txtctaad.Size = New System.Drawing.Size(100, 20)
        Me.txtctaad.TabIndex = 6
        '
        'txtcta_c
        '
        Me.txtcta_c.BackColor = System.Drawing.Color.White
        Me.txtcta_c.Location = New System.Drawing.Point(94, 114)
        Me.txtcta_c.Name = "txtcta_c"
        Me.txtcta_c.Size = New System.Drawing.Size(100, 20)
        Me.txtcta_c.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label8.Location = New System.Drawing.Point(211, 93)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 200
        Me.Label8.Text = "Acuerdo Cr"
        '
        'txtcta_cli
        '
        Me.txtcta_cli.BackColor = System.Drawing.Color.White
        Me.txtcta_cli.Location = New System.Drawing.Point(291, 32)
        Me.txtcta_cli.Name = "txtcta_cli"
        Me.txtcta_cli.Size = New System.Drawing.Size(100, 20)
        Me.txtcta_cli.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label12.Location = New System.Drawing.Point(189, 109)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 13)
        Me.Label12.TabIndex = 203
        Me.Label12.Text = "Logo"
        '
        'txtctaing
        '
        Me.txtctaing.BackColor = System.Drawing.Color.White
        Me.txtctaing.Location = New System.Drawing.Point(541, 310)
        Me.txtctaing.Name = "txtctaing"
        Me.txtctaing.Size = New System.Drawing.Size(100, 20)
        Me.txtctaing.TabIndex = 8
        Me.txtctaing.Visible = False
        '
        'imgfoto
        '
        Me.imgfoto.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.imgfoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgfoto.Location = New System.Drawing.Point(275, 100)
        Me.imgfoto.Name = "imgfoto"
        Me.imgfoto.Size = New System.Drawing.Size(80, 65)
        Me.imgfoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgfoto.TabIndex = 195
        Me.imgfoto.TabStop = False
        '
        'cmdlogofac
        '
        Me.cmdlogofac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdlogofac.Location = New System.Drawing.Point(189, 125)
        Me.cmdlogofac.Name = "cmdlogofac"
        Me.cmdlogofac.Size = New System.Drawing.Size(80, 20)
        Me.cmdlogofac.TabIndex = 11
        Me.cmdlogofac.Text = "Examinar..."
        Me.cmdlogofac.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.cmdlogofac.UseVisualStyleBackColor = True
        '
        'txtint
        '
        Me.txtint.BackColor = System.Drawing.SystemColors.Window
        Me.txtint.Enabled = False
        Me.txtint.Location = New System.Drawing.Point(314, 171)
        Me.txtint.Name = "txtint"
        Me.txtint.ReadOnly = True
        Me.txtint.ShortcutsEnabled = False
        Me.txtint.Size = New System.Drawing.Size(41, 20)
        Me.txtint.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label6.Location = New System.Drawing.Point(192, 174)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 13)
        Me.Label6.TabIndex = 199
        Me.Label6.Text = "Interes Moratorio %"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtdocF)
        Me.GroupBox2.Controls.Add(Me.cbdocF)
        Me.GroupBox2.Controls.Add(Me.cbfac)
        Me.GroupBox2.Controls.Add(Me.cmdNuevo)
        Me.GroupBox2.Controls.Add(Me.txttipo1)
        Me.GroupBox2.Controls.Add(Me.pre1)
        Me.GroupBox2.Controls.Add(Me.txtn1)
        Me.GroupBox2.Controls.Add(Me.Label41)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.ini1)
        Me.GroupBox2.Controls.Add(Me.cbres1)
        Me.GroupBox2.Controls.Add(Me.fin1)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.reso1)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.feclim1)
        Me.GroupBox2.Controls.Add(Me.fecexp1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(671, 94)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Parametros para Facturar"
        '
        'txtdocF
        '
        Me.txtdocF.Enabled = False
        Me.txtdocF.Location = New System.Drawing.Point(447, 17)
        Me.txtdocF.Name = "txtdocF"
        Me.txtdocF.Size = New System.Drawing.Size(214, 18)
        Me.txtdocF.TabIndex = 211
        '
        'cbdocF
        '
        Me.cbdocF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbdocF.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbdocF.FormattingEnabled = True
        Me.cbdocF.Location = New System.Drawing.Point(396, 16)
        Me.cbdocF.Name = "cbdocF"
        Me.cbdocF.Size = New System.Drawing.Size(46, 20)
        Me.cbdocF.TabIndex = 210
        '
        'cbfac
        '
        Me.cbfac.AutoSize = True
        Me.cbfac.Location = New System.Drawing.Point(6, 19)
        Me.cbfac.Name = "cbfac"
        Me.cbfac.Size = New System.Drawing.Size(388, 17)
        Me.cbfac.TabIndex = 1
        Me.cbfac.Text = "Usar Parametros del Modulo Facturacion. TIPO DE DOCUMENTO"
        Me.cbfac.UseVisualStyleBackColor = True
        '
        'cmdNuevo
        '
        Me.cmdNuevo.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdNuevo.Image = Global.SAE.My.Resources.Resources.nuevo
        Me.cmdNuevo.Location = New System.Drawing.Point(626, 51)
        Me.cmdNuevo.Name = "cmdNuevo"
        Me.cmdNuevo.Size = New System.Drawing.Size(35, 36)
        Me.cmdNuevo.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.cmdNuevo, "Nueva Resolucion")
        Me.cmdNuevo.UseVisualStyleBackColor = False
        '
        'txttipo1
        '
        Me.txttipo1.BackColor = System.Drawing.SystemColors.Window
        Me.txttipo1.Location = New System.Drawing.Point(3, 63)
        Me.txttipo1.Name = "txttipo1"
        Me.txttipo1.ShortcutsEnabled = False
        Me.txttipo1.Size = New System.Drawing.Size(41, 18)
        Me.txttipo1.TabIndex = 2
        '
        'pre1
        '
        Me.pre1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.pre1.Enabled = False
        Me.pre1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pre1.Location = New System.Drawing.Point(534, 62)
        Me.pre1.MaxLength = 10
        Me.pre1.Name = "pre1"
        Me.pre1.ShortcutsEnabled = False
        Me.pre1.Size = New System.Drawing.Size(81, 18)
        Me.pre1.TabIndex = 10
        '
        'txtn1
        '
        Me.txtn1.BackColor = System.Drawing.Color.White
        Me.txtn1.Enabled = False
        Me.txtn1.Location = New System.Drawing.Point(47, 63)
        Me.txtn1.Name = "txtn1"
        Me.txtn1.ShortcutsEnabled = False
        Me.txtn1.Size = New System.Drawing.Size(66, 18)
        Me.txtn1.TabIndex = 3
        Me.txtn1.Text = "00000"
        Me.txtn1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label41.Location = New System.Drawing.Point(539, 48)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(38, 12)
        Me.Label41.TabIndex = 209
        Me.Label41.Text = "Prefijo"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label24.Location = New System.Drawing.Point(12, 48)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(26, 12)
        Me.Label24.TabIndex = 197
        Me.Label24.Text = "Tipo"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label25.Location = New System.Drawing.Point(59, 48)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(38, 12)
        Me.Label25.TabIndex = 198
        Me.Label25.Text = "Actual"
        '
        'ini1
        '
        Me.ini1.Enabled = False
        Me.ini1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ini1.Location = New System.Drawing.Point(414, 63)
        Me.ini1.Maximum = New Decimal(New Integer() {276447232, 23283, 0, 0})
        Me.ini1.Name = "ini1"
        Me.ini1.Size = New System.Drawing.Size(53, 18)
        Me.ini1.TabIndex = 8
        Me.ini1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ini1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'cbres1
        '
        Me.cbres1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbres1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbres1.FormattingEnabled = True
        Me.cbres1.Items.AddRange(New Object() {"SI", "NO"})
        Me.cbres1.Location = New System.Drawing.Point(116, 62)
        Me.cbres1.Name = "cbres1"
        Me.cbres1.Size = New System.Drawing.Size(38, 20)
        Me.cbres1.TabIndex = 4
        '
        'fin1
        '
        Me.fin1.Enabled = False
        Me.fin1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fin1.Location = New System.Drawing.Point(475, 63)
        Me.fin1.Maximum = New Decimal(New Integer() {276447232, 23283, 0, 0})
        Me.fin1.Name = "fin1"
        Me.fin1.Size = New System.Drawing.Size(53, 18)
        Me.fin1.TabIndex = 9
        Me.fin1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.fin1.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label26.Location = New System.Drawing.Point(115, 47)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(92, 12)
        Me.Label26.TabIndex = 200
        Me.Label26.Text = "Resolución DIAN"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label29.Location = New System.Drawing.Point(411, 48)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(122, 12)
        Me.Label29.TabIndex = 205
        Me.Label29.Text = "Rango Facturas por PC"
        '
        'reso1
        '
        Me.reso1.Enabled = False
        Me.reso1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reso1.Location = New System.Drawing.Point(156, 63)
        Me.reso1.MaxLength = 30
        Me.reso1.Name = "reso1"
        Me.reso1.ShortcutsEnabled = False
        Me.reso1.Size = New System.Drawing.Size(83, 18)
        Me.reso1.TabIndex = 5
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label27.Location = New System.Drawing.Point(245, 46)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(22, 12)
        Me.Label27.TabIndex = 204
        Me.Label27.Text = "Del"
        '
        'feclim1
        '
        Me.feclim1.Enabled = False
        Me.feclim1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.feclim1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.feclim1.Location = New System.Drawing.Point(332, 63)
        Me.feclim1.Name = "feclim1"
        Me.feclim1.Size = New System.Drawing.Size(78, 18)
        Me.feclim1.TabIndex = 7
        '
        'fecexp1
        '
        Me.fecexp1.Enabled = False
        Me.fecexp1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fecexp1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecexp1.Location = New System.Drawing.Point(243, 63)
        Me.fecexp1.Name = "fecexp1"
        Me.fecexp1.Size = New System.Drawing.Size(78, 18)
        Me.fecexp1.TabIndex = 6
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.lbcaution)
        Me.GroupPanel1.Controls.Add(Me.cmdcancelar)
        Me.GroupPanel1.Controls.Add(Me.cmdguardar)
        Me.GroupPanel1.Location = New System.Drawing.Point(4, 391)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(671, 81)
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
        Me.GroupPanel1.TabIndex = 3
        '
        'lbcaution
        '
        Me.lbcaution.AutoSize = True
        Me.lbcaution.BackColor = System.Drawing.Color.Transparent
        Me.lbcaution.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcaution.ForeColor = System.Drawing.Color.DarkRed
        Me.lbcaution.Location = New System.Drawing.Point(447, 9)
        Me.lbcaution.Name = "lbcaution"
        Me.lbcaution.Size = New System.Drawing.Size(215, 48)
        Me.lbcaution.TabIndex = 100
        Me.lbcaution.Text = "* Nota: Se recomienda escoger una imagen JPG de " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  1. Tamaño: 100 x 100 pixeles " & _
            "aprox." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  2. Peso max:  1 MB aprox." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  "
        '
        'cmdcancelar
        '
        Me.cmdcancelar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdcancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancelar.ForeColor = System.Drawing.Color.Transparent
        Me.cmdcancelar.Image = Global.SAE.My.Resources.Resources.cparam
        Me.cmdcancelar.Location = New System.Drawing.Point(320, 1)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(72, 68)
        Me.cmdcancelar.TabIndex = 1
        Me.cmdcancelar.Text = "&c"
        Me.cmdcancelar.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdcancelar, "Cancelar")
        Me.cmdcancelar.UseVisualStyleBackColor = False
        '
        'cmdguardar
        '
        Me.cmdguardar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdguardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdguardar.ForeColor = System.Drawing.Color.Transparent
        Me.cmdguardar.Image = Global.SAE.My.Resources.Resources.gparam
        Me.cmdguardar.Location = New System.Drawing.Point(241, 1)
        Me.cmdguardar.Name = "cmdguardar"
        Me.cmdguardar.Size = New System.Drawing.Size(72, 68)
        Me.cmdguardar.TabIndex = 0
        Me.cmdguardar.Text = "      &g"
        Me.cmdguardar.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdguardar, "Guardar")
        Me.cmdguardar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Brown
        Me.Label2.Location = New System.Drawing.Point(248, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(170, 13)
        Me.Label2.TabIndex = 193
        Me.Label2.Text = "PARAMETROS GENERALES"
        '
        'OPF
        '
        Me.OPF.FileName = "OpenFileDialog1"
        '
        'FrmParInmob
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(681, 474)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmParInmob"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Parametros Inmobiliaria"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.imgfoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.ini1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fin1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtcta_v As System.Windows.Forms.TextBox
    Friend WithEvents txtcta_iva As System.Windows.Forms.TextBox
    Friend WithEvents txtobs As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdcancelar As System.Windows.Forms.Button
    Friend WithEvents cmdguardar As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtcta_rtf As System.Windows.Forms.TextBox
    Friend WithEvents pre1 As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents ini1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents fin1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents feclim1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents fecexp1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents reso1 As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cbres1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtn1 As System.Windows.Forms.TextBox
    Friend WithEvents txttipo1 As System.Windows.Forms.TextBox
    Friend WithEvents cmdNuevo As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbfac As System.Windows.Forms.CheckBox
    Friend WithEvents cbdocF As System.Windows.Forms.ComboBox
    Friend WithEvents txtdocF As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtcta_cli As System.Windows.Forms.TextBox
    Friend WithEvents txtcta_c As System.Windows.Forms.TextBox
    Friend WithEvents txtint As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdlogofac As System.Windows.Forms.Button
    Friend WithEvents imgfoto As System.Windows.Forms.PictureBox
    Friend WithEvents OPF As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lbcaution As System.Windows.Forms.Label
    Friend WithEvents txtctaac As System.Windows.Forms.TextBox
    Friend WithEvents txtctaad As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtctaing As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents e2 As System.Windows.Forms.RadioButton
    Friend WithEvents e1 As System.Windows.Forms.RadioButton
End Class
