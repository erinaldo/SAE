<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOrdenesDePago
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOrdenesDePago))
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmdgenerar = New DevComponents.DotNetBar.ButtonX
        Me.Label3 = New System.Windows.Forms.Label
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX
        Me.TabControlPanel3 = New DevComponents.DotNetBar.TabControlPanel
        Me.TabControl4 = New DevComponents.DotNetBar.TabControl
        Me.TabControlPanel17 = New DevComponents.DotNetBar.TabControlPanel
        Me.cmd_g_o = New DevComponents.DotNetBar.ButtonX
        Me.cmd_analisis = New DevComponents.DotNetBar.ButtonX
        Me.cmd_cpp_inf_pro = New DevComponents.DotNetBar.ButtonX
        Me.cmd_comp_cpp = New DevComponents.DotNetBar.ButtonX
        Me.cmd_plan_pagos = New DevComponents.DotNetBar.ButtonX
        Me.Label24 = New System.Windows.Forms.Label
        Me.TabItem15 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel5 = New DevComponents.DotNetBar.TabControlPanel
        Me.ButtonX4 = New DevComponents.DotNetBar.ButtonX
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX
        Me.cdmlibmay = New DevComponents.DotNetBar.ButtonX
        Me.Button1 = New System.Windows.Forms.Button
        Me.Contable = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabItem2 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.TabControl1 = New DevComponents.DotNetBar.TabControl
        Me.TabControlPanel4 = New DevComponents.DotNetBar.TabControlPanel
        Me.cmddesa = New DevComponents.DotNetBar.ButtonX
        Me.ButtonX6 = New DevComponents.DotNetBar.ButtonX
        Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdcierre = New DevComponents.DotNetBar.ButtonX
        Me.TabItem3 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel
        Me.ButtonX7 = New DevComponents.DotNetBar.ButtonX
        Me.cmdEgresoOrden = New DevComponents.DotNetBar.ButtonX
        Me.cmdOt = New DevComponents.DotNetBar.ButtonX
        Me.cmdCPP = New DevComponents.DotNetBar.ButtonX
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel
        Me.ButtonX5 = New DevComponents.DotNetBar.ButtonX
        Me.cmddoc = New DevComponents.DotNetBar.ButtonX
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.datosbac = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.ButtonX8 = New DevComponents.DotNetBar.ButtonX
        Me.salir = New System.Windows.Forms.Button
        Me.cmdayuda = New System.Windows.Forms.Button
        Me.cmdsoptec = New System.Windows.Forms.Button
        Me.cmdweb = New System.Windows.Forms.Button
        Me.cmdbackup = New System.Windows.Forms.Button
        Me.cmdperio = New System.Windows.Forms.Button
        Me.cmdcompa = New System.Windows.Forms.Button
        Me.TabControlPanel3.SuspendLayout()
        CType(Me.TabControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl4.SuspendLayout()
        Me.TabControlPanel17.SuspendLayout()
        Me.TabControlPanel5.SuspendLayout()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabControlPanel4.SuspendLayout()
        Me.TabControlPanel2.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label14.Location = New System.Drawing.Point(55, 10)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(627, 42)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "_____________________________"
        '
        'cmdgenerar
        '
        Me.cmdgenerar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdgenerar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdgenerar.Location = New System.Drawing.Point(105, 94)
        Me.cmdgenerar.Name = "cmdgenerar"
        Me.cmdgenerar.Size = New System.Drawing.Size(229, 36)
        Me.cmdgenerar.TabIndex = 0
        Me.cmdgenerar.Text = "&Ordenes de Pagos"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(171, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(370, 31)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Ordenes de Pagos (Informes)"
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(268, 134)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(192, 36)
        Me.ButtonX1.TabIndex = 22
        Me.ButtonX1.Text = "&Reprocesar"
        '
        'TabControlPanel3
        '
        Me.TabControlPanel3.Controls.Add(Me.Label3)
        Me.TabControlPanel3.Controls.Add(Me.Label14)
        Me.TabControlPanel3.Controls.Add(Me.TabControl4)
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
        Me.TabControlPanel3.TabItem = Me.TabItem2
        '
        'TabControl4
        '
        Me.TabControl4.CanReorderTabs = True
        Me.TabControl4.Controls.Add(Me.TabControlPanel5)
        Me.TabControl4.Controls.Add(Me.TabControlPanel17)
        Me.TabControl4.Location = New System.Drawing.Point(10, 55)
        Me.TabControl4.Name = "TabControl4"
        Me.TabControl4.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl4.SelectedTabIndex = 1
        Me.TabControl4.Size = New System.Drawing.Size(715, 209)
        Me.TabControl4.TabIndex = 55
        Me.TabControl4.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl4.Tabs.Add(Me.TabItem15)
        Me.TabControl4.Tabs.Add(Me.Contable)
        Me.TabControl4.Text = "Cuentas Por Pagar"
        '
        'TabControlPanel17
        '
        Me.TabControlPanel17.Controls.Add(Me.cmd_g_o)
        Me.TabControlPanel17.Controls.Add(Me.cmd_analisis)
        Me.TabControlPanel17.Controls.Add(Me.cmd_cpp_inf_pro)
        Me.TabControlPanel17.Controls.Add(Me.cmd_comp_cpp)
        Me.TabControlPanel17.Controls.Add(Me.cmd_plan_pagos)
        Me.TabControlPanel17.Controls.Add(Me.Label24)
        Me.TabControlPanel17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel17.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel17.Name = "TabControlPanel17"
        Me.TabControlPanel17.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel17.Size = New System.Drawing.Size(715, 183)
        Me.TabControlPanel17.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel17.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel17.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel17.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel17.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel17.Style.GradientAngle = 90
        Me.TabControlPanel17.TabIndex = 3
        Me.TabControlPanel17.TabItem = Me.TabItem15
        '
        'cmd_g_o
        '
        Me.cmd_g_o.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmd_g_o.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmd_g_o.Location = New System.Drawing.Point(370, 92)
        Me.cmd_g_o.Name = "cmd_g_o"
        Me.cmd_g_o.Size = New System.Drawing.Size(209, 36)
        Me.cmd_g_o.TabIndex = 5
        Me.cmd_g_o.Text = "Comprobantes de Otros Egresos"
        '
        'cmd_analisis
        '
        Me.cmd_analisis.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmd_analisis.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmd_analisis.Location = New System.Drawing.Point(144, 92)
        Me.cmd_analisis.Name = "cmd_analisis"
        Me.cmd_analisis.Size = New System.Drawing.Size(209, 36)
        Me.cmd_analisis.TabIndex = 1
        Me.cmd_analisis.Text = "Analisis de Cuentas por Pagar"
        '
        'cmd_cpp_inf_pro
        '
        Me.cmd_cpp_inf_pro.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmd_cpp_inf_pro.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmd_cpp_inf_pro.Location = New System.Drawing.Point(144, 50)
        Me.cmd_cpp_inf_pro.Name = "cmd_cpp_inf_pro"
        Me.cmd_cpp_inf_pro.Size = New System.Drawing.Size(209, 36)
        Me.cmd_cpp_inf_pro.TabIndex = 0
        Me.cmd_cpp_inf_pro.Text = "Movimiento por Proveedor"
        '
        'cmd_comp_cpp
        '
        Me.cmd_comp_cpp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmd_comp_cpp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmd_comp_cpp.Location = New System.Drawing.Point(370, 50)
        Me.cmd_comp_cpp.Name = "cmd_comp_cpp"
        Me.cmd_comp_cpp.Size = New System.Drawing.Size(209, 36)
        Me.cmd_comp_cpp.TabIndex = 4
        Me.cmd_comp_cpp.Text = "Comprobante de Cuentas por Pagar"
        '
        'cmd_plan_pagos
        '
        Me.cmd_plan_pagos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmd_plan_pagos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmd_plan_pagos.Location = New System.Drawing.Point(258, 132)
        Me.cmd_plan_pagos.Name = "cmd_plan_pagos"
        Me.cmd_plan_pagos.Size = New System.Drawing.Size(209, 36)
        Me.cmd_plan_pagos.TabIndex = 2
        Me.cmd_plan_pagos.Text = "Plan Semanal de Pagos"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(187, 5)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(354, 31)
        Me.Label24.TabIndex = 15
        Me.Label24.Text = "Informes Cuentas por Pagar"
        '
        'TabItem15
        '
        Me.TabItem15.AttachedControl = Me.TabControlPanel17
        Me.TabItem15.Name = "TabItem15"
        Me.TabItem15.Text = "Cuentas Por Pagar"
        '
        'TabControlPanel5
        '
        Me.TabControlPanel5.Controls.Add(Me.ButtonX8)
        Me.TabControlPanel5.Controls.Add(Me.ButtonX4)
        Me.TabControlPanel5.Controls.Add(Me.ButtonX2)
        Me.TabControlPanel5.Controls.Add(Me.cdmlibmay)
        Me.TabControlPanel5.Controls.Add(Me.Button1)
        Me.TabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel5.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel5.Name = "TabControlPanel5"
        Me.TabControlPanel5.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel5.Size = New System.Drawing.Size(715, 183)
        Me.TabControlPanel5.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel5.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel5.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel5.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel5.Style.GradientAngle = 90
        Me.TabControlPanel5.TabIndex = 4
        Me.TabControlPanel5.TabItem = Me.Contable
        '
        'ButtonX4
        '
        Me.ButtonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX4.Location = New System.Drawing.Point(400, 36)
        Me.ButtonX4.Name = "ButtonX4"
        Me.ButtonX4.Size = New System.Drawing.Size(192, 36)
        Me.ButtonX4.TabIndex = 58
        Me.ButtonX4.Text = "&Resumen de Deducciones"
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Location = New System.Drawing.Point(157, 77)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(192, 36)
        Me.ButtonX2.TabIndex = 57
        Me.ButtonX2.Text = "&Ordenes de Pago"
        '
        'cdmlibmay
        '
        Me.cdmlibmay.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cdmlibmay.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cdmlibmay.Location = New System.Drawing.Point(157, 36)
        Me.cdmlibmay.Name = "cdmlibmay"
        Me.cdmlibmay.Size = New System.Drawing.Size(192, 36)
        Me.cdmlibmay.TabIndex = 56
        Me.cdmlibmay.Text = "Libro &Auxiliares (Contable)"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(255, 84)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(30, 27)
        Me.Button1.TabIndex = 59
        Me.Button1.Text = "&LLenar MovPresupuesto"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Contable
        '
        Me.Contable.AttachedControl = Me.TabControlPanel5
        Me.Contable.Name = "Contable"
        Me.Contable.Text = "Contable"
        '
        'TabItem2
        '
        Me.TabItem2.AttachedControl = Me.TabControlPanel3
        Me.TabItem2.Name = "TabItem2"
        Me.TabItem2.Text = "Informes"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(171, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(378, 31)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Ordenes de Pagos (Procesos)"
        '
        'TabControl1
        '
        Me.TabControl1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TabControl1.CanReorderTabs = True
        Me.TabControl1.CloseButtonVisible = True
        Me.TabControl1.Controls.Add(Me.TabControlPanel3)
        Me.TabControl1.Controls.Add(Me.TabControlPanel1)
        Me.TabControl1.Controls.Add(Me.TabControlPanel2)
        Me.TabControl1.Controls.Add(Me.TabControlPanel4)
        Me.TabControl1.Location = New System.Drawing.Point(7, 96)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl1.SelectedTabIndex = 1
        Me.TabControl1.Size = New System.Drawing.Size(733, 300)
        Me.TabControl1.TabIndex = 7
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.datosbac)
        Me.TabControl1.Tabs.Add(Me.TabItem1)
        Me.TabControl1.Tabs.Add(Me.TabItem2)
        Me.TabControl1.Tabs.Add(Me.TabItem3)
        Me.TabControl1.Text = "TabControl1"
        '
        'TabControlPanel4
        '
        Me.TabControlPanel4.Controls.Add(Me.cmddesa)
        Me.TabControlPanel4.Controls.Add(Me.ButtonX6)
        Me.TabControlPanel4.Controls.Add(Me.ButtonX3)
        Me.TabControlPanel4.Controls.Add(Me.ButtonX1)
        Me.TabControlPanel4.Controls.Add(Me.Label4)
        Me.TabControlPanel4.Controls.Add(Me.Label5)
        Me.TabControlPanel4.Controls.Add(Me.cmdcierre)
        Me.TabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel4.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel4.Name = "TabControlPanel4"
        Me.TabControlPanel4.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel4.Size = New System.Drawing.Size(733, 274)
        Me.TabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel4.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel4.Style.GradientAngle = 90
        Me.TabControlPanel4.TabIndex = 4
        Me.TabControlPanel4.TabItem = Me.TabItem3
        '
        'cmddesa
        '
        Me.cmddesa.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmddesa.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmddesa.Location = New System.Drawing.Point(268, 218)
        Me.cmddesa.Name = "cmddesa"
        Me.cmddesa.Size = New System.Drawing.Size(192, 36)
        Me.cmddesa.TabIndex = 25
        Me.cmddesa.Text = "Desaprobar &CE Orden"
        '
        'ButtonX6
        '
        Me.ButtonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX6.Location = New System.Drawing.Point(268, 176)
        Me.ButtonX6.Name = "ButtonX6"
        Me.ButtonX6.Size = New System.Drawing.Size(192, 36)
        Me.ButtonX6.TabIndex = 24
        Me.ButtonX6.Text = "&Desenglobar Nomina"
        '
        'ButtonX3
        '
        Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX3.Location = New System.Drawing.Point(268, 89)
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Size = New System.Drawing.Size(192, 36)
        Me.ButtonX3.TabIndex = 23
        Me.ButtonX3.Text = "&Modificar Causaciones"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label5.Location = New System.Drawing.Point(59, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(627, 42)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "_____________________________"
        '
        'cmdcierre
        '
        Me.cmdcierre.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdcierre.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdcierre.Location = New System.Drawing.Point(268, 92)
        Me.cmdcierre.Name = "cmdcierre"
        Me.cmdcierre.Size = New System.Drawing.Size(192, 36)
        Me.cmdcierre.TabIndex = 19
        Me.cmdcierre.Text = "&Cierre de Año"
        Me.cmdcierre.Visible = False
        '
        'TabItem3
        '
        Me.TabItem3.AttachedControl = Me.TabControlPanel4
        Me.TabItem3.Name = "TabItem3"
        Me.TabItem3.Text = "Procesos"
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.ButtonX7)
        Me.TabControlPanel2.Controls.Add(Me.cmdEgresoOrden)
        Me.TabControlPanel2.Controls.Add(Me.cmdOt)
        Me.TabControlPanel2.Controls.Add(Me.cmdCPP)
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
        Me.TabControlPanel2.TabItem = Me.TabItem1
        '
        'ButtonX7
        '
        Me.ButtonX7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX7.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX7.Location = New System.Drawing.Point(247, 175)
        Me.ButtonX7.Name = "ButtonX7"
        Me.ButtonX7.Size = New System.Drawing.Size(226, 36)
        Me.ButtonX7.TabIndex = 25
        Me.ButtonX7.Text = "Otros &Ingresos"
        Me.ButtonX7.Tooltip = "Cuentas ReteCree"
        '
        'cmdEgresoOrden
        '
        Me.cmdEgresoOrden.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdEgresoOrden.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdEgresoOrden.Location = New System.Drawing.Point(105, 132)
        Me.cmdEgresoOrden.Name = "cmdEgresoOrden"
        Me.cmdEgresoOrden.Size = New System.Drawing.Size(229, 36)
        Me.cmdEgresoOrden.TabIndex = 24
        Me.cmdEgresoOrden.Text = "&Egreso - Orden de Pago"
        '
        'cmdOt
        '
        Me.cmdOt.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdOt.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdOt.Location = New System.Drawing.Point(369, 133)
        Me.cmdOt.Name = "cmdOt"
        Me.cmdOt.Size = New System.Drawing.Size(247, 36)
        Me.cmdOt.TabIndex = 23
        Me.cmdOt.Text = "Comprobantes de Otros &Egresos"
        '
        'cmdCPP
        '
        Me.cmdCPP.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmdCPP.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmdCPP.Location = New System.Drawing.Point(369, 94)
        Me.cmdCPP.Name = "cmdCPP"
        Me.cmdCPP.Size = New System.Drawing.Size(247, 36)
        Me.cmdCPP.TabIndex = 22
        Me.cmdCPP.Text = "Comprobantes de pagos de &Cuentas Por Pagar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(156, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(442, 31)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Ordenes de Pagos (Transacciones)"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label13.Location = New System.Drawing.Point(61, 35)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(627, 42)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "_____________________________"
        '
        'TabItem1
        '
        Me.TabItem1.AttachedControl = Me.TabControlPanel2
        Me.TabItem1.Name = "TabItem1"
        Me.TabItem1.Text = "Transacciones"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.ButtonX5)
        Me.TabControlPanel1.Controls.Add(Me.cmddoc)
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
        'ButtonX5
        '
        Me.ButtonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX5.Location = New System.Drawing.Point(266, 157)
        Me.ButtonX5.Name = "ButtonX5"
        Me.ButtonX5.Size = New System.Drawing.Size(192, 36)
        Me.ButtonX5.TabIndex = 18
        Me.ButtonX5.Text = "Parametros " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "&Otros Doc"
        '
        'cmddoc
        '
        Me.cmddoc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.cmddoc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.cmddoc.Location = New System.Drawing.Point(266, 114)
        Me.cmddoc.Name = "cmddoc"
        Me.cmddoc.Size = New System.Drawing.Size(192, 36)
        Me.cmddoc.TabIndex = 17
        Me.cmddoc.Text = "&Parametros"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(164, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(439, 31)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Ordenes de Pagos (Datos Basicos)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label7.Location = New System.Drawing.Point(55, 31)
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
        Me.GroupPanel1.Location = New System.Drawing.Point(7, 7)
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
        Me.GroupPanel1.TabIndex = 6
        '
        'ButtonX8
        '
        Me.ButtonX8.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX8.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX8.Location = New System.Drawing.Point(400, 77)
        Me.ButtonX8.Name = "ButtonX8"
        Me.ButtonX8.Size = New System.Drawing.Size(192, 36)
        Me.ButtonX8.TabIndex = 60
        Me.ButtonX8.Text = "&Egresos - Rubros"
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
        'FrmOrdenesDePago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(744, 404)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmOrdenesDePago"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SAE Ordenes De Pago"
        Me.TabControlPanel3.ResumeLayout(False)
        Me.TabControlPanel3.PerformLayout()
        CType(Me.TabControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl4.ResumeLayout(False)
        Me.TabControlPanel17.ResumeLayout(False)
        Me.TabControlPanel17.PerformLayout()
        Me.TabControlPanel5.ResumeLayout(False)
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabControlPanel4.ResumeLayout(False)
        Me.TabControlPanel4.PerformLayout()
        Me.TabControlPanel2.ResumeLayout(False)
        Me.TabControlPanel2.PerformLayout()
        Me.TabControlPanel1.ResumeLayout(False)
        Me.TabControlPanel1.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmdgenerar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TabControlPanel3 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem2 As DevComponents.DotNetBar.TabItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents salir As System.Windows.Forms.Button
    Friend WithEvents cmdayuda As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents cmddoc As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents datosbac As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents cmdOt As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdCPP As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel4 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdcierre As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TabItem3 As DevComponents.DotNetBar.TabItem
    Friend WithEvents cmdweb As System.Windows.Forms.Button
    Friend WithEvents cmdperio As System.Windows.Forms.Button
    Friend WithEvents cmdcompa As System.Windows.Forms.Button
    Friend WithEvents cmdsoptec As System.Windows.Forms.Button
    Friend WithEvents cmdbackup As System.Windows.Forms.Button
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TabControl4 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel17 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents cmd_g_o As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmd_analisis As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmd_cpp_inf_pro As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmd_comp_cpp As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmd_plan_pagos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TabItem15 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel5 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents Contable As DevComponents.DotNetBar.TabItem
    Friend WithEvents cdmlibmay As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmdEgresoOrden As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX4 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ButtonX5 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX7 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX6 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmddesa As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX8 As DevComponents.DotNetBar.ButtonX
End Class
