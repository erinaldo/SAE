<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCartera
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCartera))
        Me.TabControl1 = New DevComponents.DotNetBar.TabControl
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel
        Me.TabConta = New DevComponents.DotNetBar.TabControl
        Me.TabControlPanel6 = New DevComponents.DotNetBar.TabControlPanel
        Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX
        Me.cmd_SaldoIniciales = New DevComponents.DotNetBar.ButtonX
        Me.cmddoc = New DevComponents.DotNetBar.ButtonX
        Me.cmdfactnormal = New DevComponents.DotNetBar.ButtonX
        Me.TabItem5 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.datosbac = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel3 = New DevComponents.DotNetBar.TabControlPanel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TabControl2 = New DevComponents.DotNetBar.TabControl
        Me.TabControlPanel4 = New DevComponents.DotNetBar.TabControlPanel
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX
        Me.cmd_ven_plan = New DevComponents.DotNetBar.ButtonX
        Me.cmd_ven_est = New DevComponents.DotNetBar.ButtonX
        Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel7 = New DevComponents.DotNetBar.TabControlPanel
        Me.cmdRecC = New DevComponents.DotNetBar.ButtonX
        Me.cmdMC = New DevComponents.DotNetBar.ButtonX
        Me.TabItem2 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel8 = New DevComponents.DotNetBar.TabControlPanel
        Me.cmd_car_ciud = New DevComponents.DotNetBar.ButtonX
        Me.cmd_conp_fac = New DevComponents.DotNetBar.ButtonX
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX
        Me.cmd_ven_clie = New DevComponents.DotNetBar.ButtonX
        Me.TabItem3 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.info = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel5 = New DevComponents.DotNetBar.TabControlPanel
        Me.TabControl4 = New DevComponents.DotNetBar.TabControl
        Me.TabControlPanel21 = New DevComponents.DotNetBar.TabControlPanel
        Me.cmdbalgral = New DevComponents.DotNetBar.ButtonX
        Me.cmdestres = New DevComponents.DotNetBar.ButtonX
        Me.TabItem18 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel10 = New DevComponents.DotNetBar.TabControlPanel
        Me.cmdAp = New DevComponents.DotNetBar.ButtonX
        Me.cmddes = New DevComponents.DotNetBar.ButtonX
        Me.TabItem4 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.pro = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel9 = New DevComponents.DotNetBar.TabControlPanel
        Me.Label10 = New System.Windows.Forms.Label
        Me.permisos = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel
        Me.cmd_OtrosIngresos = New DevComponents.DotNetBar.ButtonX
        Me.cmdsaldo = New DevComponents.DotNetBar.ButtonX
        Me.cmdgenerar = New DevComponents.DotNetBar.ButtonX
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.tra = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.salir = New System.Windows.Forms.Button
        Me.cmdayuda = New System.Windows.Forms.Button
        Me.cmdsoptec = New System.Windows.Forms.Button
        Me.cmdweb = New System.Windows.Forms.Button
        Me.cmdbackup = New System.Windows.Forms.Button
        Me.cmdperio = New System.Windows.Forms.Button
        Me.cmdcompa = New System.Windows.Forms.Button
        Me.ButtonX4 = New DevComponents.DotNetBar.ButtonX
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        CType(Me.TabConta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabConta.SuspendLayout()
        Me.TabControlPanel6.SuspendLayout()
        Me.TabControlPanel3.SuspendLayout()
        CType(Me.TabControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl2.SuspendLayout()
        Me.TabControlPanel4.SuspendLayout()
        Me.TabControlPanel7.SuspendLayout()
        Me.TabControlPanel8.SuspendLayout()
        Me.TabControlPanel5.SuspendLayout()
        CType(Me.TabControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl4.SuspendLayout()
        Me.TabControlPanel21.SuspendLayout()
        Me.TabControlPanel10.SuspendLayout()
        Me.TabControlPanel9.SuspendLayout()
        Me.TabControlPanel2.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TabControl1.CanReorderTabs = True
        Me.TabControl1.CloseButtonVisible = True
        Me.TabControl1.Controls.Add(Me.TabControlPanel3)
        Me.TabControl1.Controls.Add(Me.TabControlPanel1)
        Me.TabControl1.Controls.Add(Me.TabControlPanel5)
        Me.TabControl1.Controls.Add(Me.TabControlPanel9)
        Me.TabControl1.Controls.Add(Me.TabControlPanel2)
        Me.TabControl1.Location = New System.Drawing.Point(7, 99)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl1.SelectedTabIndex = 1
        Me.TabControl1.Size = New System.Drawing.Size(733, 300)
        Me.TabControl1.TabIndex = 2
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.datosbac)
        Me.TabControl1.Tabs.Add(Me.tra)
        Me.TabControl1.Tabs.Add(Me.info)
        Me.TabControl1.Tabs.Add(Me.pro)
        Me.TabControl1.Tabs.Add(Me.permisos)
        Me.TabControl1.Text = "TabControl1"
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
        Me.TabControlPanel1.Size = New System.Drawing.Size(733, 274)
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
        Me.TabConta.Location = New System.Drawing.Point(14, 58)
        Me.TabConta.Name = "TabConta"
        Me.TabConta.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabConta.SelectedTabIndex = 0
        Me.TabConta.Size = New System.Drawing.Size(715, 209)
        Me.TabConta.TabIndex = 20
        Me.TabConta.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabConta.Tabs.Add(Me.TabItem5)
        Me.TabConta.Text = "Notas y Observaciones"
        '
        'TabControlPanel6
        '
        Me.TabControlPanel6.Controls.Add(Me.ButtonX3)
        Me.TabControlPanel6.Controls.Add(Me.cmd_SaldoIniciales)
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
        Me.ButtonX3.Location = New System.Drawing.Point(385, 35)
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Size = New System.Drawing.Size(192, 36)
        Me.ButtonX3.TabIndex = 19
        Me.ButtonX3.Text = "C&onceptos Comisionables"
        '
        'cmd_SaldoIniciales
        '
        Me.cmd_SaldoIniciales.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmd_SaldoIniciales.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmd_SaldoIniciales.Location = New System.Drawing.Point(132, 77)
        Me.cmd_SaldoIniciales.Name = "cmd_SaldoIniciales"
        Me.cmd_SaldoIniciales.Size = New System.Drawing.Size(192, 36)
        Me.cmd_SaldoIniciales.TabIndex = 19
        Me.cmd_SaldoIniciales.Text = "&Saldos Iniciales"
        '
        'cmddoc
        '
        Me.cmddoc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmddoc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmddoc.Location = New System.Drawing.Point(132, 35)
        Me.cmddoc.Name = "cmddoc"
        Me.cmddoc.Size = New System.Drawing.Size(192, 36)
        Me.cmddoc.TabIndex = 16
        Me.cmddoc.Text = "&Parametros Generales"
        '
        'cmdfactnormal
        '
        Me.cmdfactnormal.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdfactnormal.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdfactnormal.Location = New System.Drawing.Point(385, 77)
        Me.cmdfactnormal.Name = "cmdfactnormal"
        Me.cmdfactnormal.Size = New System.Drawing.Size(192, 36)
        Me.cmdfactnormal.TabIndex = 18
        Me.cmdfactnormal.Text = "&Comisiones por Recaudo"
        '
        'TabItem5
        '
        Me.TabItem5.AttachedControl = Me.TabControlPanel6
        Me.TabItem5.Name = "TabItem5"
        Me.TabItem5.Text = "Información General"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(195, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(303, 31)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Cartera - Datos Basicos"
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
        'TabControlPanel3
        '
        Me.TabControlPanel3.Controls.Add(Me.Label3)
        Me.TabControlPanel3.Controls.Add(Me.Label4)
        Me.TabControlPanel3.Controls.Add(Me.TabControl2)
        Me.TabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel3.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel3.Name = "TabControlPanel3"
        Me.TabControlPanel3.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel3.Size = New System.Drawing.Size(733, 274)
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(219, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(234, 31)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Cartera - Informes"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(59, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(627, 42)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "_____________________________"
        '
        'TabControl2
        '
        Me.TabControl2.CanReorderTabs = True
        Me.TabControl2.Controls.Add(Me.TabControlPanel8)
        Me.TabControl2.Controls.Add(Me.TabControlPanel7)
        Me.TabControl2.Controls.Add(Me.TabControlPanel4)
        Me.TabControl2.Location = New System.Drawing.Point(7, 56)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl2.SelectedTabIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(715, 209)
        Me.TabControl2.TabIndex = 25
        Me.TabControl2.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl2.Tabs.Add(Me.TabItem1)
        Me.TabControl2.Tabs.Add(Me.TabItem2)
        Me.TabControl2.Tabs.Add(Me.TabItem3)
        Me.TabControl2.Text = "Notas y Observaciones"
        '
        'TabControlPanel4
        '
        Me.TabControlPanel4.Controls.Add(Me.ButtonX1)
        Me.TabControlPanel4.Controls.Add(Me.cmd_ven_plan)
        Me.TabControlPanel4.Controls.Add(Me.cmd_ven_est)
        Me.TabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel4.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel4.Name = "TabControlPanel4"
        Me.TabControlPanel4.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel4.Size = New System.Drawing.Size(715, 183)
        Me.TabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel4.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel4.Style.GradientAngle = 90
        Me.TabControlPanel4.TabIndex = 6
        Me.TabControlPanel4.TabItem = Me.TabItem1
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(254, 125)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(192, 36)
        Me.ButtonX1.TabIndex = 21
        Me.ButtonX1.Text = "&Analisis por vencimiento"
        '
        'cmd_ven_plan
        '
        Me.cmd_ven_plan.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmd_ven_plan.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmd_ven_plan.Location = New System.Drawing.Point(254, 37)
        Me.cmd_ven_plan.Name = "cmd_ven_plan"
        Me.cmd_ven_plan.Size = New System.Drawing.Size(192, 36)
        Me.cmd_ven_plan.TabIndex = 20
        Me.cmd_ven_plan.Text = "&Plan de Cobro a Clientes"
        '
        'cmd_ven_est
        '
        Me.cmd_ven_est.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmd_ven_est.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmd_ven_est.Location = New System.Drawing.Point(254, 82)
        Me.cmd_ven_est.Name = "cmd_ven_est"
        Me.cmd_ven_est.Size = New System.Drawing.Size(192, 36)
        Me.cmd_ven_est.TabIndex = 19
        Me.cmd_ven_est.Text = "&Estado de Cuenta"
        '
        'TabItem1
        '
        Me.TabItem1.AttachedControl = Me.TabControlPanel4
        Me.TabItem1.Name = "TabItem1"
        Me.TabItem1.Text = "Vencimientos"
        '
        'TabControlPanel7
        '
        Me.TabControlPanel7.Controls.Add(Me.cmdRecC)
        Me.TabControlPanel7.Controls.Add(Me.cmdMC)
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
        Me.TabControlPanel7.TabItem = Me.TabItem2
        '
        'cmdRecC
        '
        Me.cmdRecC.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdRecC.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdRecC.Location = New System.Drawing.Point(228, 85)
        Me.cmdRecC.Name = "cmdRecC"
        Me.cmdRecC.Size = New System.Drawing.Size(229, 41)
        Me.cmdRecC.TabIndex = 27
        Me.cmdRecC.Text = "&Recibos de Cartera"
        '
        'cmdMC
        '
        Me.cmdMC.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdMC.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdMC.Location = New System.Drawing.Point(228, 38)
        Me.cmdMC.Name = "cmdMC"
        Me.cmdMC.Size = New System.Drawing.Size(229, 41)
        Me.cmdMC.TabIndex = 26
        Me.cmdMC.Text = "&Cartera por Clientes"
        '
        'TabItem2
        '
        Me.TabItem2.AttachedControl = Me.TabControlPanel7
        Me.TabItem2.Name = "TabItem2"
        Me.TabItem2.Text = "Movimentos"
        '
        'TabControlPanel8
        '
        Me.TabControlPanel8.Controls.Add(Me.ButtonX4)
        Me.TabControlPanel8.Controls.Add(Me.cmd_car_ciud)
        Me.TabControlPanel8.Controls.Add(Me.cmd_conp_fac)
        Me.TabControlPanel8.Controls.Add(Me.ButtonX2)
        Me.TabControlPanel8.Controls.Add(Me.cmd_ven_clie)
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
        Me.TabControlPanel8.TabItem = Me.TabItem3
        '
        'cmd_car_ciud
        '
        Me.cmd_car_ciud.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmd_car_ciud.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmd_car_ciud.Location = New System.Drawing.Point(356, 29)
        Me.cmd_car_ciud.Name = "cmd_car_ciud"
        Me.cmd_car_ciud.Size = New System.Drawing.Size(218, 38)
        Me.cmd_car_ciud.TabIndex = 27
        Me.cmd_car_ciud.Text = " Cartera por Ciudad"
        '
        'cmd_conp_fac
        '
        Me.cmd_conp_fac.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmd_conp_fac.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmd_conp_fac.Location = New System.Drawing.Point(356, 73)
        Me.cmd_conp_fac.Name = "cmd_conp_fac"
        Me.cmd_conp_fac.Size = New System.Drawing.Size(218, 39)
        Me.cmd_conp_fac.TabIndex = 26
        Me.cmd_conp_fac.Text = "Cartera por Concepto de Facturacion"
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Location = New System.Drawing.Point(128, 73)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(214, 39)
        Me.ButtonX2.TabIndex = 25
        Me.ButtonX2.Text = " &Clientes en Mora"
        '
        'cmd_ven_clie
        '
        Me.cmd_ven_clie.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmd_ven_clie.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmd_ven_clie.Location = New System.Drawing.Point(127, 29)
        Me.cmd_ven_clie.Name = "cmd_ven_clie"
        Me.cmd_ven_clie.Size = New System.Drawing.Size(215, 38)
        Me.cmd_ven_clie.TabIndex = 24
        Me.cmd_ven_clie.Text = "Una &Factura"
        '
        'TabItem3
        '
        Me.TabItem3.AttachedControl = Me.TabControlPanel8
        Me.TabItem3.Name = "TabItem3"
        Me.TabItem3.Text = "Consultas"
        '
        'info
        '
        Me.info.AttachedControl = Me.TabControlPanel3
        Me.info.Name = "info"
        Me.info.Text = "Informes"
        '
        'TabControlPanel5
        '
        Me.TabControlPanel5.Controls.Add(Me.TabControl4)
        Me.TabControlPanel5.Controls.Add(Me.Label5)
        Me.TabControlPanel5.Controls.Add(Me.Label16)
        Me.TabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel5.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel5.Name = "TabControlPanel5"
        Me.TabControlPanel5.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel5.Size = New System.Drawing.Size(733, 274)
        Me.TabControlPanel5.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel5.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel5.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel5.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel5.Style.GradientAngle = 90
        Me.TabControlPanel5.TabIndex = 5
        Me.TabControlPanel5.TabItem = Me.pro
        '
        'TabControl4
        '
        Me.TabControl4.CanReorderTabs = True
        Me.TabControl4.Controls.Add(Me.TabControlPanel21)
        Me.TabControl4.Controls.Add(Me.TabControlPanel10)
        Me.TabControl4.Location = New System.Drawing.Point(10, 55)
        Me.TabControl4.Name = "TabControl4"
        Me.TabControl4.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl4.SelectedTabIndex = 0
        Me.TabControl4.Size = New System.Drawing.Size(715, 209)
        Me.TabControl4.TabIndex = 14
        Me.TabControl4.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl4.Tabs.Add(Me.TabItem18)
        Me.TabControl4.Tabs.Add(Me.TabItem4)
        Me.TabControl4.Text = "Notas y Observaciones"
        '
        'TabControlPanel21
        '
        Me.TabControlPanel21.Controls.Add(Me.cmdbalgral)
        Me.TabControlPanel21.Controls.Add(Me.cmdestres)
        Me.TabControlPanel21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel21.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel21.Name = "TabControlPanel21"
        Me.TabControlPanel21.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel21.Size = New System.Drawing.Size(715, 183)
        Me.TabControlPanel21.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel21.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel21.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel21.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel21.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel21.Style.GradientAngle = 90
        Me.TabControlPanel21.TabIndex = 6
        Me.TabControlPanel21.TabItem = Me.TabItem18
        '
        'cmdbalgral
        '
        Me.cmdbalgral.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdbalgral.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdbalgral.Location = New System.Drawing.Point(255, 92)
        Me.cmdbalgral.Name = "cmdbalgral"
        Me.cmdbalgral.Size = New System.Drawing.Size(192, 36)
        Me.cmdbalgral.TabIndex = 20
        Me.cmdbalgral.Text = "&Cierre Anual"
        '
        'cmdestres
        '
        Me.cmdestres.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdestres.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdestres.Location = New System.Drawing.Point(255, 50)
        Me.cmdestres.Name = "cmdestres"
        Me.cmdestres.Size = New System.Drawing.Size(192, 36)
        Me.cmdestres.TabIndex = 19
        Me.cmdestres.Text = "&Actualizar Saldos"
        '
        'TabItem18
        '
        Me.TabItem18.AttachedControl = Me.TabControlPanel21
        Me.TabItem18.Name = "TabItem18"
        Me.TabItem18.Text = "Procesos Especiales"
        '
        'TabControlPanel10
        '
        Me.TabControlPanel10.Controls.Add(Me.cmdAp)
        Me.TabControlPanel10.Controls.Add(Me.cmddes)
        Me.TabControlPanel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel10.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel10.Name = "TabControlPanel10"
        Me.TabControlPanel10.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel10.Size = New System.Drawing.Size(715, 183)
        Me.TabControlPanel10.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel10.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel10.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel10.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel10.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel10.Style.GradientAngle = 90
        Me.TabControlPanel10.TabIndex = 7
        Me.TabControlPanel10.TabItem = Me.TabItem4
        '
        'cmdAp
        '
        Me.cmdAp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdAp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdAp.Location = New System.Drawing.Point(240, 47)
        Me.cmdAp.Name = "cmdAp"
        Me.cmdAp.Size = New System.Drawing.Size(208, 36)
        Me.cmdAp.TabIndex = 5
        Me.cmdAp.Text = "&Aprobar documentos"
        '
        'cmddes
        '
        Me.cmddes.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmddes.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmddes.Location = New System.Drawing.Point(239, 89)
        Me.cmddes.Name = "cmddes"
        Me.cmddes.Size = New System.Drawing.Size(208, 36)
        Me.cmddes.TabIndex = 6
        Me.cmddes.Text = "&Desaprobar Recibo de Cartera"
        '
        'TabItem4
        '
        Me.TabItem4.AttachedControl = Me.TabControlPanel10
        Me.TabItem4.Name = "TabItem4"
        Me.TabItem4.Text = "Procesos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(204, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(279, 31)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Cartera Administrador"
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
        'pro
        '
        Me.pro.AttachedControl = Me.TabControlPanel5
        Me.pro.Name = "pro"
        Me.pro.Text = "Administrador"
        Me.pro.Visible = False
        '
        'TabControlPanel9
        '
        Me.TabControlPanel9.Controls.Add(Me.Label10)
        Me.TabControlPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel9.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel9.Name = "TabControlPanel9"
        Me.TabControlPanel9.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel9.Size = New System.Drawing.Size(733, 274)
        Me.TabControlPanel9.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel9.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel9.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel9.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel9.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel9.Style.GradientAngle = 90
        Me.TabControlPanel9.TabIndex = 6
        Me.TabControlPanel9.TabItem = Me.permisos
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(155, 125)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(423, 24)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "NO TIENES PERMISOS PARA ESTA INTERFAZ"
        '
        'permisos
        '
        Me.permisos.AttachedControl = Me.TabControlPanel9
        Me.permisos.Name = "permisos"
        Me.permisos.Text = "Permisos"
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.cmd_OtrosIngresos)
        Me.TabControlPanel2.Controls.Add(Me.cmdsaldo)
        Me.TabControlPanel2.Controls.Add(Me.cmdgenerar)
        Me.TabControlPanel2.Controls.Add(Me.Label2)
        Me.TabControlPanel2.Controls.Add(Me.Label13)
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(733, 274)
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
        'cmd_OtrosIngresos
        '
        Me.cmd_OtrosIngresos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmd_OtrosIngresos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmd_OtrosIngresos.Location = New System.Drawing.Point(249, 151)
        Me.cmd_OtrosIngresos.Name = "cmd_OtrosIngresos"
        Me.cmd_OtrosIngresos.Size = New System.Drawing.Size(209, 36)
        Me.cmd_OtrosIngresos.TabIndex = 2
        Me.cmd_OtrosIngresos.Text = "&Otros Ingresos"
        '
        'cmdsaldo
        '
        Me.cmdsaldo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdsaldo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdsaldo.Location = New System.Drawing.Point(249, 193)
        Me.cmdsaldo.Name = "cmdsaldo"
        Me.cmdsaldo.Size = New System.Drawing.Size(209, 36)
        Me.cmdsaldo.TabIndex = 1
        Me.cmdsaldo.Text = "&Facturas Pendientes"
        Me.cmdsaldo.Visible = False
        '
        'cmdgenerar
        '
        Me.cmdgenerar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdgenerar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdgenerar.Location = New System.Drawing.Point(249, 109)
        Me.cmdgenerar.Name = "cmdgenerar"
        Me.cmdgenerar.Size = New System.Drawing.Size(209, 36)
        Me.cmdgenerar.TabIndex = 0
        Me.cmdgenerar.Text = "&Recibos de Cartera"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(229, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(251, 31)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Cartera  - Registros"
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
        'tra
        '
        Me.tra.AttachedControl = Me.TabControlPanel2
        Me.tra.Name = "tra"
        Me.tra.Text = "Transacciones"
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
        Me.GroupPanel1.Location = New System.Drawing.Point(7, 8)
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
        Me.GroupPanel1.TabIndex = 3
        '
        'salir
        '
        Me.salir.BackColor = System.Drawing.Color.White
        Me.salir.Image = Global.SAE.My.Resources.Resources.atras
        Me.salir.Location = New System.Drawing.Point(533, 8)
        Me.salir.Name = "salir"
        Me.salir.Size = New System.Drawing.Size(66, 68)
        Me.salir.TabIndex = 14
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
        Me.cmdcompa.UseVisualStyleBackColor = False
        '
        'ButtonX4
        '
        Me.ButtonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX4.Location = New System.Drawing.Point(258, 118)
        Me.ButtonX4.Name = "ButtonX4"
        Me.ButtonX4.Size = New System.Drawing.Size(209, 37)
        Me.ButtonX4.TabIndex = 28
        Me.ButtonX4.Text = " &Comisiones por Recaudo"
        '
        'FrmCartera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(745, 406)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCartera"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  SAE Cartera"
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabControlPanel1.ResumeLayout(False)
        Me.TabControlPanel1.PerformLayout()
        CType(Me.TabConta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabConta.ResumeLayout(False)
        Me.TabControlPanel6.ResumeLayout(False)
        Me.TabControlPanel3.ResumeLayout(False)
        Me.TabControlPanel3.PerformLayout()
        CType(Me.TabControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl2.ResumeLayout(False)
        Me.TabControlPanel4.ResumeLayout(False)
        Me.TabControlPanel7.ResumeLayout(False)
        Me.TabControlPanel8.ResumeLayout(False)
        Me.TabControlPanel5.ResumeLayout(False)
        Me.TabControlPanel5.PerformLayout()
        CType(Me.TabControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl4.ResumeLayout(False)
        Me.TabControlPanel21.ResumeLayout(False)
        Me.TabControlPanel10.ResumeLayout(False)
        Me.TabControlPanel9.ResumeLayout(False)
        Me.TabControlPanel9.PerformLayout()
        Me.TabControlPanel2.ResumeLayout(False)
        Me.TabControlPanel2.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabConta As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel6 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents cmddoc As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdfactnormal As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TabItem5 As DevComponents.DotNetBar.TabItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents datosbac As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel3 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents info As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents cmdsaldo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdgenerar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tra As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel5 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabControl4 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel21 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents cmdbalgral As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdestres As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TabItem18 As DevComponents.DotNetBar.TabItem
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents pro As DevComponents.DotNetBar.TabItem
    Friend WithEvents cmd_ven_plan As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmd_ven_est As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmd_SaldoIniciales As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmd_OtrosIngresos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmd_ven_clie As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TabControlPanel9 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents permisos As DevComponents.DotNetBar.TabItem
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmdcompa As System.Windows.Forms.Button
    Friend WithEvents cmdperio As System.Windows.Forms.Button
    Friend WithEvents cmdbackup As System.Windows.Forms.Button
    Friend WithEvents cmdweb As System.Windows.Forms.Button
    Friend WithEvents cmdsoptec As System.Windows.Forms.Button
    Friend WithEvents cmdayuda As System.Windows.Forms.Button
    Friend WithEvents salir As System.Windows.Forms.Button
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TabControl2 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel4 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel8 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem3 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel7 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem2 As DevComponents.DotNetBar.TabItem
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmd_conp_fac As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmd_car_ciud As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdMC As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdRecC As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TabControlPanel10 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents cmdAp As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmddes As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TabItem4 As DevComponents.DotNetBar.TabItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX4 As DevComponents.DotNetBar.ButtonX
End Class
