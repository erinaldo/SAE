<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frmccosto
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frmccosto))
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.g_ing = New System.Windows.Forms.DataGridView
        Me.cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.total = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdpdf = New System.Windows.Forms.Button
        Me.txtut = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmdSalir = New System.Windows.Forms.Button
        Me.txtpres = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdBuscar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtnomcc = New System.Windows.Forms.TextBox
        Me.txtcc = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.g_gast = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_ting = New System.Windows.Forms.TextBox
        Me.txt_tgas = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel4.SuspendLayout()
        CType(Me.g_ing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.g_gast, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel4.Controls.Add(Me.Label27)
        Me.Panel4.Controls.Add(Me.Label30)
        Me.Panel4.Controls.Add(Me.Label31)
        Me.Panel4.Location = New System.Drawing.Point(6, 97)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(550, 19)
        Me.Panel4.TabIndex = 51
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(464, 4)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(43, 13)
        Me.Label27.TabIndex = 41
        Me.Label27.Text = "TOTAL"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(188, 4)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(89, 13)
        Me.Label30.TabIndex = 41
        Me.Label30.Text = "DESCRIPCION"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label31.Location = New System.Drawing.Point(16, 4)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(53, 13)
        Me.Label31.TabIndex = 40
        Me.Label31.Text = "CUENTA"
        '
        'g_ing
        '
        Me.g_ing.AllowUserToAddRows = False
        Me.g_ing.AllowUserToDeleteRows = False
        Me.g_ing.AllowUserToResizeColumns = False
        Me.g_ing.AllowUserToResizeRows = False
        Me.g_ing.BackgroundColor = System.Drawing.Color.White
        Me.g_ing.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.g_ing.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.g_ing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.g_ing.ColumnHeadersVisible = False
        Me.g_ing.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cuenta, Me.descripcion, Me.total})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.g_ing.DefaultCellStyle = DataGridViewCellStyle3
        Me.g_ing.Location = New System.Drawing.Point(6, 115)
        Me.g_ing.Name = "g_ing"
        Me.g_ing.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.g_ing.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.g_ing.RowHeadersVisible = False
        Me.g_ing.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.g_ing.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.g_ing.Size = New System.Drawing.Size(550, 158)
        Me.g_ing.TabIndex = 52
        '
        'cuenta
        '
        Me.cuenta.HeaderText = "cuenta"
        Me.cuenta.MinimumWidth = 80
        Me.cuenta.Name = "cuenta"
        Me.cuenta.ReadOnly = True
        Me.cuenta.Width = 80
        '
        'descripcion
        '
        Me.descripcion.HeaderText = "descripcion"
        Me.descripcion.MinimumWidth = 343
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ReadOnly = True
        Me.descripcion.Width = 343
        '
        'total
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.total.DefaultCellStyle = DataGridViewCellStyle2
        Me.total.HeaderText = "total"
        Me.total.MinimumWidth = 110
        Me.total.Name = "total"
        Me.total.ReadOnly = True
        Me.total.Width = 110
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdpdf)
        Me.GroupBox1.Controls.Add(Me.txtut)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.cmdSalir)
        Me.GroupBox1.Controls.Add(Me.txtpres)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cmdBuscar)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtnomcc)
        Me.GroupBox1.Controls.Add(Me.txtcc)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(557, 74)
        Me.GroupBox1.TabIndex = 53
        Me.GroupBox1.TabStop = False
        '
        'cmdpdf
        '
        Me.cmdpdf.Location = New System.Drawing.Point(376, 40)
        Me.cmdpdf.Name = "cmdpdf"
        Me.cmdpdf.Size = New System.Drawing.Size(62, 28)
        Me.cmdpdf.TabIndex = 47
        Me.cmdpdf.Text = "Ver pdf"
        Me.cmdpdf.UseVisualStyleBackColor = True
        '
        'txtut
        '
        Me.txtut.BackColor = System.Drawing.Color.White
        Me.txtut.Enabled = False
        Me.txtut.Location = New System.Drawing.Point(262, 40)
        Me.txtut.Name = "txtut"
        Me.txtut.ReadOnly = True
        Me.txtut.Size = New System.Drawing.Size(108, 20)
        Me.txtut.TabIndex = 46
        Me.txtut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(204, 43)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 13)
        Me.Label10.TabIndex = 45
        Me.Label10.Text = "UTILIDAD"
        '
        'cmdSalir
        '
        Me.cmdSalir.Image = Global.SAE.My.Resources.Resources.salir
        Me.cmdSalir.Location = New System.Drawing.Point(497, 9)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(47, 34)
        Me.cmdSalir.TabIndex = 44
        Me.ToolTip1.SetToolTip(Me.cmdSalir, "Salir")
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'txtpres
        '
        Me.txtpres.BackColor = System.Drawing.Color.White
        Me.txtpres.Enabled = False
        Me.txtpres.Location = New System.Drawing.Point(95, 40)
        Me.txtpres.Name = "txtpres"
        Me.txtpres.ReadOnly = True
        Me.txtpres.Size = New System.Drawing.Size(100, 20)
        Me.txtpres.TabIndex = 43
        Me.txtpres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(8, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 13)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "PRESUPUESTO"
        '
        'cmdBuscar
        '
        Me.cmdBuscar.Image = Global.SAE.My.Resources.Resources.buscar
        Me.cmdBuscar.Location = New System.Drawing.Point(444, 9)
        Me.cmdBuscar.Name = "cmdBuscar"
        Me.cmdBuscar.Size = New System.Drawing.Size(47, 34)
        Me.cmdBuscar.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.cmdBuscar, "Buscar")
        Me.cmdBuscar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Centro de Costo"
        '
        'txtnomcc
        '
        Me.txtnomcc.BackColor = System.Drawing.Color.White
        Me.txtnomcc.Enabled = False
        Me.txtnomcc.Location = New System.Drawing.Point(203, 14)
        Me.txtnomcc.Name = "txtnomcc"
        Me.txtnomcc.ReadOnly = True
        Me.txtnomcc.Size = New System.Drawing.Size(235, 20)
        Me.txtnomcc.TabIndex = 4
        '
        'txtcc
        '
        Me.txtcc.Location = New System.Drawing.Point(95, 14)
        Me.txtcc.Name = "txtcc"
        Me.txtcc.Size = New System.Drawing.Size(102, 20)
        Me.txtcc.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(6, 313)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(548, 19)
        Me.Panel1.TabIndex = 54
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(464, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "TOTAL"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(188, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "DESCRIPCION"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(16, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "CUENTA"
        '
        'g_gast
        '
        Me.g_gast.AllowUserToAddRows = False
        Me.g_gast.AllowUserToDeleteRows = False
        Me.g_gast.AllowUserToResizeColumns = False
        Me.g_gast.AllowUserToResizeRows = False
        Me.g_gast.BackgroundColor = System.Drawing.Color.White
        Me.g_gast.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.g_gast.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.g_gast.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.g_gast.ColumnHeadersVisible = False
        Me.g_gast.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.g_gast.DefaultCellStyle = DataGridViewCellStyle7
        Me.g_gast.Location = New System.Drawing.Point(6, 331)
        Me.g_gast.Name = "g_gast"
        Me.g_gast.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.g_gast.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.g_gast.RowHeadersVisible = False
        Me.g_gast.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.g_gast.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.g_gast.Size = New System.Drawing.Size(548, 176)
        Me.g_gast.TabIndex = 55
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "cuenta"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 80
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 80
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "descripcion"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 343
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 343
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn3.HeaderText = "total"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 110
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 110
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Purple
        Me.Label5.Location = New System.Drawing.Point(3, 297)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 13)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "GASTOS y/o COSTOS"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Purple
        Me.Label6.Location = New System.Drawing.Point(3, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "INGRESOS"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(393, 282)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 58
        Me.Label7.Text = "TOTAL"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(396, 516)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 59
        Me.Label8.Text = "TOTAL"
        '
        'txt_ting
        '
        Me.txt_ting.BackColor = System.Drawing.Color.White
        Me.txt_ting.Enabled = False
        Me.txt_ting.Location = New System.Drawing.Point(441, 279)
        Me.txt_ting.Name = "txt_ting"
        Me.txt_ting.ReadOnly = True
        Me.txt_ting.Size = New System.Drawing.Size(95, 20)
        Me.txt_ting.TabIndex = 60
        Me.txt_ting.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_tgas
        '
        Me.txt_tgas.BackColor = System.Drawing.Color.White
        Me.txt_tgas.Enabled = False
        Me.txt_tgas.Location = New System.Drawing.Point(441, 513)
        Me.txt_tgas.Name = "txt_tgas"
        Me.txt_tgas.ReadOnly = True
        Me.txt_tgas.Size = New System.Drawing.Size(95, 20)
        Me.txt_tgas.TabIndex = 61
        Me.txt_tgas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Frmccosto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(566, 538)
        Me.Controls.Add(Me.txt_tgas)
        Me.Controls.Add(Me.txt_ting)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.g_gast)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.g_ing)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frmccosto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Analisis por Centro de Costo"
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.g_ing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.g_gast, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents g_ing As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtcc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtnomcc As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents g_gast As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdBuscar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_ting As System.Windows.Forms.TextBox
    Friend WithEvents txt_tgas As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtpres As System.Windows.Forms.TextBox
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents txtut As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdpdf As System.Windows.Forms.Button
    Friend WithEvents cuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
