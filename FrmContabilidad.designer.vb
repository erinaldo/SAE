<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmContabilidad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmContabilidad))
        Me.TabControlPanel4 = New DevComponents.DotNetBar.TabControlPanel
        Me.cmdbloper = New DevComponents.DotNetBar.ButtonX
        Me.cmdactcc = New DevComponents.DotNetBar.ButtonX
        Me.cmdfinano = New DevComponents.DotNetBar.ButtonX
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.proceso = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.permiso = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel5 = New DevComponents.DotNetBar.TabControlPanel
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.TabControlPanel3 = New DevComponents.DotNetBar.TabControlPanel
        Me.ButtonX6 = New DevComponents.DotNetBar.ButtonX
        Me.ButtonX5 = New DevComponents.DotNetBar.ButtonX
        Me.ButtonX4 = New DevComponents.DotNetBar.ButtonX
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX
        Me.cmdMov = New DevComponents.DotNetBar.ButtonX
        Me.cmdAnti = New DevComponents.DotNetBar.ButtonX
        Me.cmdTri = New DevComponents.DotNetBar.ButtonX
        Me.cmdanexosB = New DevComponents.DotNetBar.ButtonX
        Me.cmdinven = New DevComponents.DotNetBar.ButtonX
        Me.cmdPB = New DevComponents.DotNetBar.ButtonX
        Me.cdmestres = New DevComponents.DotNetBar.ButtonX
        Me.cdmlibmay = New DevComponents.DotNetBar.ButtonX
        Me.cmdbalgra = New DevComponents.DotNetBar.ButtonX
        Me.cmdcc = New DevComponents.DotNetBar.ButtonX
        Me.Label3 = New System.Windows.Forms.Label
        Me.info = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.mimenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.QueEsEsroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.salir = New System.Windows.Forms.Button
        Me.cmdayuda = New System.Windows.Forms.Button
        Me.cmdsoptec = New System.Windows.Forms.Button
        Me.cmdweb = New System.Windows.Forms.Button
        Me.cmdbackup = New System.Windows.Forms.Button
        Me.cmdperio = New System.Windows.Forms.Button
        Me.cmdcompa = New System.Windows.Forms.Button
        Me.tra = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel
        Me.ButtonX7 = New DevComponents.DotNetBar.ButtonX
        Me.cdotrosdoc = New DevComponents.DotNetBar.ButtonX
        Me.cmdNumPag = New DevComponents.DotNetBar.ButtonX
        Me.cmdsaldo = New DevComponents.DotNetBar.ButtonX
        Me.cmdgenerar = New DevComponents.DotNetBar.ButtonX
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel
        Me.TabConta = New DevComponents.DotNetBar.TabControl
        Me.TabControlPanel6 = New DevComponents.DotNetBar.TabControlPanel
        Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX
        Me.cdCopiarPUC = New DevComponents.DotNetBar.ButtonX
        Me.cdmadapPUC = New DevComponents.DotNetBar.ButtonX
        Me.cmddoc = New DevComponents.DotNetBar.ButtonX
        Me.cmdfactnormal = New DevComponents.DotNetBar.ButtonX
        Me.TabItem5 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel7 = New DevComponents.DotNetBar.TabControlPanel
        Me.cmdcopiar = New DevComponents.DotNetBar.ButtonX
        Me.cmdcatalogo = New DevComponents.DotNetBar.ButtonX
        Me.catacuenta = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel8 = New DevComponents.DotNetBar.TabControlPanel
        Me.cmdinfo_c_c = New DevComponents.DotNetBar.ButtonX
        Me.cdmcentro = New DevComponents.DotNetBar.ButtonX
        Me.Tabcentro = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.datosbac = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControl1 = New DevComponents.DotNetBar.TabControl
        Me.Tool = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControlPanel4.SuspendLayout()
        Me.TabControlPanel5.SuspendLayout()
        Me.TabControlPanel3.SuspendLayout()
        Me.mimenu.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.TabControlPanel2.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        CType(Me.TabConta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabConta.SuspendLayout()
        Me.TabControlPanel6.SuspendLayout()
        Me.TabControlPanel7.SuspendLayout()
        Me.TabControlPanel8.SuspendLayout()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControlPanel4
        '
        Me.TabControlPanel4.Controls.Add(Me.cmdbloper)
        Me.TabControlPanel4.Controls.Add(Me.cmdactcc)
        Me.TabControlPanel4.Controls.Add(Me.cmdfinano)
        Me.TabControlPanel4.Controls.Add(Me.Label4)
        Me.TabControlPanel4.Controls.Add(Me.Label15)
        Me.TabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel4.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel4.Name = "TabControlPanel4"
        Me.TabControlPanel4.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel4.Size = New System.Drawing.Size(733, 306)
        Me.TabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel4.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel4.Style.GradientAngle = 90
        Me.TabControlPanel4.TabIndex = 4
        Me.TabControlPanel4.TabItem = Me.proceso
        '
        'cmdbloper
        '
        Me.cmdbloper.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdbloper.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdbloper.Location = New System.Drawing.Point(270, 108)
        Me.cmdbloper.Name = "cmdbloper"
        Me.cmdbloper.Size = New System.Drawing.Size(192, 36)
        Me.cmdbloper.TabIndex = 24
        Me.cmdbloper.Text = "&Bloquear Periodos"
        '
        'cmdactcc
        '
        Me.cmdactcc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdactcc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdactcc.Enabled = False
        Me.cmdactcc.Location = New System.Drawing.Point(270, 193)
        Me.cmdactcc.Name = "cmdactcc"
        Me.cmdactcc.Size = New System.Drawing.Size(192, 36)
        Me.cmdactcc.TabIndex = 23
        Me.cmdactcc.Text = "&Actualización Catalogo de Cuentas"
        Me.cmdactcc.Visible = False
        '
        'cmdfinano
        '
        Me.cmdfinano.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdfinano.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdfinano.Location = New System.Drawing.Point(270, 150)
        Me.cmdfinano.Name = "cmdfinano"
        Me.cmdfinano.Size = New System.Drawing.Size(192, 36)
        Me.cmdfinano.TabIndex = 21
        Me.cmdfinano.Text = "&Proceso Fin de Año"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(211, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(304, 31)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Contabilidad (Procesos)"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label15.Location = New System.Drawing.Point(56, 26)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(627, 42)
        Me.Label15.TabIndex = 13
        Me.Label15.Text = "_____________________________"
        '
        'proceso
        '
        Me.proceso.AttachedControl = Me.TabControlPanel4
        Me.proceso.Name = "proceso"
        Me.proceso.Text = "Procesos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(160, 97)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(423, 24)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "NO TIENES PERMISOS PARA ESTA INTERFAZ"
        '
        'permiso
        '
        Me.permiso.AttachedControl = Me.TabControlPanel5
        Me.permiso.Name = "permiso"
        Me.permiso.Text = "Permisos"
        Me.permiso.Visible = False
        '
        'TabControlPanel5
        '
        Me.TabControlPanel5.Controls.Add(Me.Label5)
        Me.TabControlPanel5.Controls.Add(Me.Label16)
        Me.TabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel5.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel5.Name = "TabControlPanel5"
        Me.TabControlPanel5.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel5.Size = New System.Drawing.Size(733, 306)
        Me.TabControlPanel5.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel5.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel5.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel5.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel5.Style.GradientAngle = 90
        Me.TabControlPanel5.TabIndex = 5
        Me.TabControlPanel5.TabItem = Me.permiso
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label16.Location = New System.Drawing.Point(50, 10)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(627, 42)
        Me.Label16.TabIndex = 13
        Me.Label16.Text = "_____________________________"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label14.Location = New System.Drawing.Point(55, 5)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(627, 42)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "_____________________________"
        '
        'TabControlPanel3
        '
        Me.TabControlPanel3.Controls.Add(Me.ButtonX6)
        Me.TabControlPanel3.Controls.Add(Me.ButtonX5)
        Me.TabControlPanel3.Controls.Add(Me.ButtonX4)
        Me.TabControlPanel3.Controls.Add(Me.ButtonX2)
        Me.TabControlPanel3.Controls.Add(Me.ButtonX1)
        Me.TabControlPanel3.Controls.Add(Me.cmdMov)
        Me.TabControlPanel3.Controls.Add(Me.cmdAnti)
        Me.TabControlPanel3.Controls.Add(Me.cmdTri)
        Me.TabControlPanel3.Controls.Add(Me.cmdanexosB)
        Me.TabControlPanel3.Controls.Add(Me.cmdinven)
        Me.TabControlPanel3.Controls.Add(Me.cmdPB)
        Me.TabControlPanel3.Controls.Add(Me.cdmestres)
        Me.TabControlPanel3.Controls.Add(Me.cdmlibmay)
        Me.TabControlPanel3.Controls.Add(Me.cmdbalgra)
        Me.TabControlPanel3.Controls.Add(Me.cmdcc)
        Me.TabControlPanel3.Controls.Add(Me.Label3)
        Me.TabControlPanel3.Controls.Add(Me.Label14)
        Me.TabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel3.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel3.Name = "TabControlPanel3"
        Me.TabControlPanel3.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel3.Size = New System.Drawing.Size(733, 306)
        Me.TabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel3.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel3.Style.GradientAngle = 90
        Me.TabControlPanel3.TabIndex = 3
        Me.TabControlPanel3.TabItem = Me.info
        '
        'ButtonX6
        '
        Me.ButtonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX6.Location = New System.Drawing.Point(485, 242)
        Me.ButtonX6.Name = "ButtonX6"
        Me.ButtonX6.Size = New System.Drawing.Size(192, 36)
        Me.ButtonX6.TabIndex = 34
        Me.ButtonX6.Text = "Estado de Resultado - Publico"
        '
        'ButtonX5
        '
        Me.ButtonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX5.Location = New System.Drawing.Point(266, 243)
        Me.ButtonX5.Name = "ButtonX5"
        Me.ButtonX5.Size = New System.Drawing.Size(192, 36)
        Me.ButtonX5.TabIndex = 33
        Me.ButtonX5.Text = "Balance General - Publico"
        '
        'ButtonX4
        '
        Me.ButtonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX4.Location = New System.Drawing.Point(51, 243)
        Me.ButtonX4.Name = "ButtonX4"
        Me.ButtonX4.Size = New System.Drawing.Size(192, 36)
        Me.ButtonX4.TabIndex = 32
        Me.ButtonX4.Text = "CGN"
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Location = New System.Drawing.Point(485, 198)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(192, 36)
        Me.ButtonX2.TabIndex = 31
        Me.ButtonX2.Text = "&Utilidad Diaria"
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(485, 115)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(192, 36)
        Me.ButtonX1.TabIndex = 30
        Me.ButtonX1.Text = "&Cheques "
        '
        'cmdMov
        '
        Me.cmdMov.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdMov.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdMov.Location = New System.Drawing.Point(485, 75)
        Me.cmdMov.Name = "cmdMov"
        Me.cmdMov.Size = New System.Drawing.Size(192, 36)
        Me.cmdMov.TabIndex = 29
        Me.cmdMov.Text = "&Movimientos"
        '
        'cmdAnti
        '
        Me.cmdAnti.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdAnti.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdAnti.Location = New System.Drawing.Point(485, 157)
        Me.cmdAnti.Name = "cmdAnti"
        Me.cmdAnti.Size = New System.Drawing.Size(192, 36)
        Me.cmdAnti.TabIndex = 28
        Me.cmdAnti.Text = "&Anticipos"
        '
        'cmdTri
        '
        Me.cmdTri.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdTri.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdTri.Location = New System.Drawing.Point(266, 201)
        Me.cmdTri.Name = "cmdTri"
        Me.cmdTri.Size = New System.Drawing.Size(192, 36)
        Me.cmdTri.TabIndex = 27
        Me.cmdTri.Text = "&Tributarios"
        '
        'cmdanexosB
        '
        Me.cmdanexosB.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdanexosB.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdanexosB.Location = New System.Drawing.Point(51, 201)
        Me.cmdanexosB.Name = "cmdanexosB"
        Me.cmdanexosB.Size = New System.Drawing.Size(192, 36)
        Me.cmdanexosB.TabIndex = 26
        Me.cmdanexosB.Text = "Libro &Diario"
        '
        'cmdinven
        '
        Me.cmdinven.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdinven.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdinven.Location = New System.Drawing.Point(51, 75)
        Me.cmdinven.Name = "cmdinven"
        Me.cmdinven.Size = New System.Drawing.Size(192, 36)
        Me.cmdinven.TabIndex = 25
        Me.cmdinven.Text = "&Inventarios y Balances"
        '
        'cmdPB
        '
        Me.cmdPB.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdPB.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdPB.Location = New System.Drawing.Point(51, 159)
        Me.cmdPB.Name = "cmdPB"
        Me.cmdPB.Size = New System.Drawing.Size(192, 36)
        Me.cmdPB.TabIndex = 24
        Me.cmdPB.Text = "Balance de &Prueba"
        '
        'cdmestres
        '
        Me.cdmestres.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cdmestres.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cdmestres.Location = New System.Drawing.Point(266, 159)
        Me.cdmestres.Name = "cdmestres"
        Me.cdmestres.Size = New System.Drawing.Size(192, 36)
        Me.cdmestres.TabIndex = 23
        Me.cdmestres.Text = "&Estado de Resultados"
        '
        'cdmlibmay
        '
        Me.cdmlibmay.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cdmlibmay.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cdmlibmay.Location = New System.Drawing.Point(266, 117)
        Me.cdmlibmay.Name = "cdmlibmay"
        Me.cdmlibmay.Size = New System.Drawing.Size(192, 36)
        Me.cdmlibmay.TabIndex = 22
        Me.cdmlibmay.Text = "&Libro Mayor y de Balance"
        '
        'cmdbalgra
        '
        Me.cmdbalgra.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdbalgra.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdbalgra.Location = New System.Drawing.Point(51, 117)
        Me.cmdbalgra.Name = "cmdbalgra"
        Me.cmdbalgra.Size = New System.Drawing.Size(192, 36)
        Me.cmdbalgra.TabIndex = 21
        Me.cmdbalgra.Text = "&Balance General"
        '
        'cmdcc
        '
        Me.cmdcc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdcc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdcc.Location = New System.Drawing.Point(266, 75)
        Me.cmdcc.Name = "cmdcc"
        Me.cmdcc.Size = New System.Drawing.Size(192, 36)
        Me.cmdcc.TabIndex = 18
        Me.cmdcc.Text = "Libros &Auxiliares"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(222, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(296, 31)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Contabilidad (Informes)"
        '
        'info
        '
        Me.info.AttachedControl = Me.TabControlPanel3
        Me.info.Name = "info"
        Me.info.Text = "Informes"
        '
        'mimenu
        '
        Me.mimenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QueEsEsroToolStripMenuItem})
        Me.mimenu.Name = "mimenu"
        Me.mimenu.Size = New System.Drawing.Size(146, 26)
        '
        'QueEsEsroToolStripMenuItem
        '
        Me.QueEsEsroToolStripMenuItem.Name = "QueEsEsroToolStripMenuItem"
        Me.QueEsEsroToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.QueEsEsroToolStripMenuItem.Text = "¿Que es esto?"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.salir)
        Me.GroupPanel1.Controls.Add(Me.cmdayuda)
        Me.GroupPanel1.Controls.Add(Me.cmdsoptec)
        Me.GroupPanel1.Controls.Add(Me.cmdweb)
        Me.GroupPanel1.Controls.Add(Me.cmdbackup)
        Me.GroupPanel1.Controls.Add(Me.cmdperio)
        Me.GroupPanel1.Controls.Add(Me.cmdcompa)
        Me.GroupPanel1.Location = New System.Drawing.Point(3, 6)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(733, 85)
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
        Me.GroupPanel1.TabIndex = 1
        '
        'salir
        '
        Me.salir.BackColor = System.Drawing.Color.White
        Me.salir.Image = Global.SAE.My.Resources.Resources.atras
        Me.salir.Location = New System.Drawing.Point(533, 8)
        Me.salir.Name = "salir"
        Me.salir.Size = New System.Drawing.Size(66, 68)
        Me.salir.TabIndex = 14
        Me.Tool.SetToolTip(Me.salir, "retornar")
        Me.salir.UseVisualStyleBackColor = False
        '
        'cmdayuda
        '
        Me.cmdayuda.BackColor = System.Drawing.Color.White
        Me.cmdayuda.Image = Global.SAE.My.Resources.Resources.ayuda
        Me.cmdayuda.Location = New System.Drawing.Point(461, 8)
        Me.cmdayuda.Name = "cmdayuda"
        Me.cmdayuda.Size = New System.Drawing.Size(66, 68)
        Me.cmdayuda.TabIndex = 13
        Me.cmdayuda.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Tool.SetToolTip(Me.cmdayuda, "ayuda")
        Me.cmdayuda.UseVisualStyleBackColor = False
        '
        'cmdsoptec
        '
        Me.cmdsoptec.BackColor = System.Drawing.Color.White
        Me.cmdsoptec.Image = Global.SAE.My.Resources.Resources.soporte
        Me.cmdsoptec.Location = New System.Drawing.Point(389, 8)
        Me.cmdsoptec.Name = "cmdsoptec"
        Me.cmdsoptec.Size = New System.Drawing.Size(66, 68)
        Me.cmdsoptec.TabIndex = 12
        Me.Tool.SetToolTip(Me.cmdsoptec, "soporte tecnico")
        Me.cmdsoptec.UseVisualStyleBackColor = False
        '
        'cmdweb
        '
        Me.cmdweb.BackColor = System.Drawing.Color.White
        Me.cmdweb.Image = Global.SAE.My.Resources.Resources.web
        Me.cmdweb.Location = New System.Drawing.Point(317, 8)
        Me.cmdweb.Name = "cmdweb"
        Me.cmdweb.Size = New System.Drawing.Size(66, 68)
        Me.cmdweb.TabIndex = 11
        Me.Tool.SetToolTip(Me.cmdweb, "explorador web")
        Me.cmdweb.UseVisualStyleBackColor = False
        '
        'cmdbackup
        '
        Me.cmdbackup.BackColor = System.Drawing.Color.White
        Me.cmdbackup.Image = Global.SAE.My.Resources.Resources.backup
        Me.cmdbackup.Location = New System.Drawing.Point(246, 8)
        Me.cmdbackup.Name = "cmdbackup"
        Me.cmdbackup.Size = New System.Drawing.Size(66, 68)
        Me.cmdbackup.TabIndex = 10
        Me.Tool.SetToolTip(Me.cmdbackup, "copia de seguridad")
        Me.cmdbackup.UseVisualStyleBackColor = False
        '
        'cmdperio
        '
        Me.cmdperio.BackColor = System.Drawing.Color.White
        Me.cmdperio.Image = Global.SAE.My.Resources.Resources.periodo
        Me.cmdperio.Location = New System.Drawing.Point(174, 8)
        Me.cmdperio.Name = "cmdperio"
        Me.cmdperio.Size = New System.Drawing.Size(66, 68)
        Me.cmdperio.TabIndex = 9
        Me.cmdperio.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Tool.SetToolTip(Me.cmdperio, "abrir período")
        Me.cmdperio.UseVisualStyleBackColor = False
        '
        'cmdcompa
        '
        Me.cmdcompa.BackColor = System.Drawing.Color.White
        Me.cmdcompa.Image = Global.SAE.My.Resources.Resources.abrir2
        Me.cmdcompa.Location = New System.Drawing.Point(102, 8)
        Me.cmdcompa.Name = "cmdcompa"
        Me.cmdcompa.Size = New System.Drawing.Size(66, 68)
        Me.cmdcompa.TabIndex = 8
        Me.Tool.SetToolTip(Me.cmdcompa, "abrir otra compañia")
        Me.cmdcompa.UseVisualStyleBackColor = False
        '
        'tra
        '
        Me.tra.AttachedControl = Me.TabControlPanel2
        Me.tra.Name = "tra"
        Me.tra.Text = "Transacciones"
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.ButtonX7)
        Me.TabControlPanel2.Controls.Add(Me.cdotrosdoc)
        Me.TabControlPanel2.Controls.Add(Me.cmdNumPag)
        Me.TabControlPanel2.Controls.Add(Me.cmdsaldo)
        Me.TabControlPanel2.Controls.Add(Me.cmdgenerar)
        Me.TabControlPanel2.Controls.Add(Me.Label2)
        Me.TabControlPanel2.Controls.Add(Me.Label13)
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(733, 306)
        Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.GradientAngle = 90
        Me.TabControlPanel2.TabIndex = 2
        Me.TabControlPanel2.TabItem = Me.tra
        '
        'ButtonX7
        '
        Me.ButtonX7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX7.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX7.Location = New System.Drawing.Point(273, 189)
        Me.ButtonX7.Name = "ButtonX7"
        Me.ButtonX7.Size = New System.Drawing.Size(192, 36)
        Me.ButtonX7.TabIndex = 15
        Me.ButtonX7.Text = "&Asignar Cuentas a Rubros"
        '
        'cdotrosdoc
        '
        Me.cdotrosdoc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cdotrosdoc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cdotrosdoc.Location = New System.Drawing.Point(380, 148)
        Me.cdotrosdoc.Name = "cdotrosdoc"
        Me.cdotrosdoc.Size = New System.Drawing.Size(192, 36)
        Me.cdotrosdoc.TabIndex = 14
        Me.cdotrosdoc.Text = "&Otros Documentos"
        Me.cdotrosdoc.Tooltip = "Otros documentos Alt + O"
        '
        'cmdNumPag
        '
        Me.cmdNumPag.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdNumPag.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdNumPag.Location = New System.Drawing.Point(380, 105)
        Me.cmdNumPag.Name = "cmdNumPag"
        Me.cmdNumPag.Size = New System.Drawing.Size(192, 36)
        Me.cmdNumPag.TabIndex = 13
        Me.cmdNumPag.Text = "&Numeración de Páginas"
        Me.cmdNumPag.Tooltip = "numeracion de paginas"
        '
        'cmdsaldo
        '
        Me.cmdsaldo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdsaldo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdsaldo.Location = New System.Drawing.Point(179, 105)
        Me.cmdsaldo.Name = "cmdsaldo"
        Me.cmdsaldo.Size = New System.Drawing.Size(192, 36)
        Me.cmdsaldo.TabIndex = 1
        Me.cmdsaldo.Text = "&Saldos Iniciales"
        '
        'cmdgenerar
        '
        Me.cmdgenerar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdgenerar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdgenerar.Location = New System.Drawing.Point(179, 147)
        Me.cmdgenerar.Name = "cmdgenerar"
        Me.cmdgenerar.Size = New System.Drawing.Size(192, 36)
        Me.cmdgenerar.TabIndex = 0
        Me.cmdgenerar.Text = "&Generar Documentos"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(218, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(368, 31)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Contabilidad (Transacciones)"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label13.Location = New System.Drawing.Point(76, 21)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(627, 42)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "_____________________________"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.TabConta)
        Me.TabControlPanel1.Controls.Add(Me.Label1)
        Me.TabControlPanel1.Controls.Add(Me.Label7)
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(733, 306)
        Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = 90
        Me.TabControlPanel1.TabIndex = 1
        Me.TabControlPanel1.TabItem = Me.datosbac
        '
        'TabConta
        '
        Me.TabConta.CanReorderTabs = True
        Me.TabConta.Controls.Add(Me.TabControlPanel6)
        Me.TabConta.Controls.Add(Me.TabControlPanel7)
        Me.TabConta.Controls.Add(Me.TabControlPanel8)
        Me.TabConta.Location = New System.Drawing.Point(14, 58)
        Me.TabConta.Name = "TabConta"
        Me.TabConta.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabConta.SelectedTabIndex = 0
        Me.TabConta.Size = New System.Drawing.Size(715, 209)
        Me.TabConta.TabIndex = 20
        Me.TabConta.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabConta.Tabs.Add(Me.TabItem5)
        Me.TabConta.Tabs.Add(Me.catacuenta)
        Me.TabConta.Tabs.Add(Me.Tabcentro)
        Me.TabConta.Text = "Notas y Observaciones"
        '
        'TabControlPanel6
        '
        Me.TabControlPanel6.Controls.Add(Me.ButtonX3)
        Me.TabControlPanel6.Controls.Add(Me.cdCopiarPUC)
        Me.TabControlPanel6.Controls.Add(Me.cdmadapPUC)
        Me.TabControlPanel6.Controls.Add(Me.cmddoc)
        Me.TabControlPanel6.Controls.Add(Me.cmdfactnormal)
        Me.TabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel6.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel6.Name = "TabControlPanel6"
        Me.TabControlPanel6.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel6.Size = New System.Drawing.Size(715, 183)
        Me.TabControlPanel6.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel6.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel6.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel6.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel6.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel6.Style.GradientAngle = 90
        Me.TabControlPanel6.TabIndex = 6
        Me.TabControlPanel6.TabItem = Me.TabItem5
        '
        'ButtonX3
        '
        Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX3.Location = New System.Drawing.Point(259, 112)
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Size = New System.Drawing.Size(192, 36)
        Me.ButtonX3.TabIndex = 22
        Me.ButtonX3.Text = "&Cuentas ReteCree"
        Me.ButtonX3.Tooltip = "Cuentas ReteCree"
        '
        'cdCopiarPUC
        '
        Me.cdCopiarPUC.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cdCopiarPUC.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cdCopiarPUC.Location = New System.Drawing.Point(369, 69)
        Me.cdCopiarPUC.Name = "cdCopiarPUC"
        Me.cdCopiarPUC.Size = New System.Drawing.Size(192, 36)
        Me.cdCopiarPUC.TabIndex = 21
        Me.cdCopiarPUC.Text = "&Copiar de Otra Compañia"
        '
        'cdmadapPUC
        '
        Me.cdmadapPUC.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cdmadapPUC.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cdmadapPUC.Location = New System.Drawing.Point(369, 27)
        Me.cdmadapPUC.Name = "cdmadapPUC"
        Me.cdmadapPUC.Size = New System.Drawing.Size(192, 36)
        Me.cdmadapPUC.TabIndex = 20
        Me.cdmadapPUC.Text = "&Adaptacion del PUC"
        '
        'cmddoc
        '
        Me.cmddoc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmddoc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmddoc.Location = New System.Drawing.Point(162, 27)
        Me.cmddoc.Name = "cmddoc"
        Me.cmddoc.Size = New System.Drawing.Size(192, 36)
        Me.cmddoc.TabIndex = 16
        Me.cmddoc.Text = "&Definir Documentos"
        '
        'cmdfactnormal
        '
        Me.cmdfactnormal.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdfactnormal.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdfactnormal.Location = New System.Drawing.Point(162, 69)
        Me.cmdfactnormal.Name = "cmdfactnormal"
        Me.cmdfactnormal.Size = New System.Drawing.Size(192, 36)
        Me.cmdfactnormal.TabIndex = 18
        Me.cmdfactnormal.Text = "&Niveles De Cuentas"
        '
        'TabItem5
        '
        Me.TabItem5.AttachedControl = Me.TabControlPanel6
        Me.TabItem5.Name = "TabItem5"
        Me.TabItem5.Text = "Información General"
        '
        'TabControlPanel7
        '
        Me.TabControlPanel7.Controls.Add(Me.cmdcopiar)
        Me.TabControlPanel7.Controls.Add(Me.cmdcatalogo)
        Me.TabControlPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel7.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel7.Name = "TabControlPanel7"
        Me.TabControlPanel7.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel7.Size = New System.Drawing.Size(715, 183)
        Me.TabControlPanel7.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel7.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel7.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel7.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel7.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel7.Style.GradientAngle = 90
        Me.TabControlPanel7.TabIndex = 7
        Me.TabControlPanel7.TabItem = Me.catacuenta
        '
        'cmdcopiar
        '
        Me.cmdcopiar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdcopiar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdcopiar.Enabled = False
        Me.cmdcopiar.Location = New System.Drawing.Point(259, 93)
        Me.cmdcopiar.Name = "cmdcopiar"
        Me.cmdcopiar.Size = New System.Drawing.Size(192, 36)
        Me.cmdcopiar.TabIndex = 21
        Me.cmdcopiar.Text = "Copiar &Plan Contable"
        Me.cmdcopiar.Visible = False
        '
        'cmdcatalogo
        '
        Me.cmdcatalogo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdcatalogo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdcatalogo.Location = New System.Drawing.Point(259, 51)
        Me.cmdcatalogo.Name = "cmdcatalogo"
        Me.cmdcatalogo.Size = New System.Drawing.Size(192, 36)
        Me.cmdcatalogo.TabIndex = 20
        Me.cmdcatalogo.Text = "&Catalogo de Cuentas"
        '
        'catacuenta
        '
        Me.catacuenta.AttachedControl = Me.TabControlPanel7
        Me.catacuenta.Name = "catacuenta"
        Me.catacuenta.Text = "Catálogo Cuentas"
        '
        'TabControlPanel8
        '
        Me.TabControlPanel8.Controls.Add(Me.cmdinfo_c_c)
        Me.TabControlPanel8.Controls.Add(Me.cdmcentro)
        Me.TabControlPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel8.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel8.Name = "TabControlPanel8"
        Me.TabControlPanel8.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel8.Size = New System.Drawing.Size(715, 183)
        Me.TabControlPanel8.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel8.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel8.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel8.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel8.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel8.Style.GradientAngle = 90
        Me.TabControlPanel8.TabIndex = 8
        Me.TabControlPanel8.TabItem = Me.Tabcentro
        '
        'cmdinfo_c_c
        '
        Me.cmdinfo_c_c.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdinfo_c_c.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdinfo_c_c.Location = New System.Drawing.Point(248, 96)
        Me.cmdinfo_c_c.Name = "cmdinfo_c_c"
        Me.cmdinfo_c_c.Size = New System.Drawing.Size(192, 36)
        Me.cmdinfo_c_c.TabIndex = 22
        Me.cmdinfo_c_c.Text = "&Informes Centros de Costo"
        '
        'cdmcentro
        '
        Me.cdmcentro.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cdmcentro.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cdmcentro.Location = New System.Drawing.Point(248, 54)
        Me.cdmcentro.Name = "cdmcentro"
        Me.cdmcentro.Size = New System.Drawing.Size(192, 36)
        Me.cdmcentro.TabIndex = 21
        Me.cdmcentro.Text = "&Centros de Costo"
        '
        'Tabcentro
        '
        Me.Tabcentro.AttachedControl = Me.TabControlPanel8
        Me.Tabcentro.Name = "Tabcentro"
        Me.Tabcentro.Text = "Centros de Costo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(195, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(365, 31)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Contabilidad (Datos Basicos)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label7.Location = New System.Drawing.Point(54, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(627, 42)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "_____________________________"
        '
        'datosbac
        '
        Me.datosbac.AttachedControl = Me.TabControlPanel1
        Me.datosbac.Name = "datosbac"
        Me.datosbac.Text = "Datos Basicos"
        '
        'TabControl1
        '
        Me.TabControl1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TabControl1.CanReorderTabs = True
        Me.TabControl1.CloseButtonVisible = True
        Me.TabControl1.Controls.Add(Me.TabControlPanel2)
        Me.TabControl1.Controls.Add(Me.TabControlPanel1)
        Me.TabControl1.Controls.Add(Me.TabControlPanel3)
        Me.TabControl1.Controls.Add(Me.TabControlPanel4)
        Me.TabControl1.Controls.Add(Me.TabControlPanel5)
        Me.TabControl1.Location = New System.Drawing.Point(3, 97)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl1.SelectedTabIndex = 1
        Me.TabControl1.Size = New System.Drawing.Size(733, 332)
        Me.TabControl1.TabIndex = 0
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.datosbac)
        Me.TabControl1.Tabs.Add(Me.tra)
        Me.TabControl1.Tabs.Add(Me.info)
        Me.TabControl1.Tabs.Add(Me.proceso)
        Me.TabControl1.Tabs.Add(Me.permiso)
        Me.TabControl1.Text = "TabControl1"
        '
        'FrmContabilidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(739, 430)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmContabilidad"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SAE Contabilidad"
        Me.TabControlPanel4.ResumeLayout(False)
        Me.TabControlPanel4.PerformLayout()
        Me.TabControlPanel5.ResumeLayout(False)
        Me.TabControlPanel5.PerformLayout()
        Me.TabControlPanel3.ResumeLayout(False)
        Me.TabControlPanel3.PerformLayout()
        Me.mimenu.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.TabControlPanel2.ResumeLayout(False)
        Me.TabControlPanel2.PerformLayout()
        Me.TabControlPanel1.ResumeLayout(False)
        Me.TabControlPanel1.PerformLayout()
        CType(Me.TabConta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabConta.ResumeLayout(False)
        Me.TabControlPanel6.ResumeLayout(False)
        Me.TabControlPanel7.ResumeLayout(False)
        Me.TabControlPanel8.ResumeLayout(False)
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControlPanel4 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents proceso As DevComponents.DotNetBar.TabItem
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents permiso As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel5 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Tool As System.Windows.Forms.ToolTip
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TabControlPanel3 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents info As DevComponents.DotNetBar.TabItem
    Friend WithEvents mimenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents QueEsEsroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents salir As System.Windows.Forms.Button
    Friend WithEvents cmdayuda As System.Windows.Forms.Button
    Friend WithEvents cmdsoptec As System.Windows.Forms.Button
    Friend WithEvents cmdweb As System.Windows.Forms.Button
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdbackup As System.Windows.Forms.Button
    Friend WithEvents cmdperio As System.Windows.Forms.Button
    Friend WithEvents cmdcompa As System.Windows.Forms.Button
    Friend WithEvents tra As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents datosbac As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
    Friend WithEvents cmdfactnormal As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmddoc As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdgenerar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdcc As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TabConta As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel6 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem5 As DevComponents.DotNetBar.TabItem
    Friend WithEvents cmdbloper As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdactcc As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdfinano As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdsaldo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdbalgra As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cdmadapPUC As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TabControlPanel7 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents cmdcatalogo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents catacuenta As DevComponents.DotNetBar.TabItem
    Friend WithEvents cmdcopiar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TabControlPanel8 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents Tabcentro As DevComponents.DotNetBar.TabItem
    Friend WithEvents cdmcentro As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cdmestres As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cdmlibmay As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdTri As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdanexosB As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdinven As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdPB As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdinfo_c_c As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdNumPag As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cdotrosdoc As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cdCopiarPUC As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdAnti As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdMov As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX4 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX5 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX6 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX7 As DevComponents.DotNetBar.ButtonX
End Class
