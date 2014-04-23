<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAumentarPrecios
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lb1 = New System.Windows.Forms.Label
        Me.rb2 = New System.Windows.Forms.RadioButton
        Me.rb1 = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lbprecio = New System.Windows.Forms.Label
        Me.lbiva = New System.Windows.Forms.Label
        Me.txtnom2 = New System.Windows.Forms.TextBox
        Me.txtnom1 = New System.Windows.Forms.TextBox
        Me.lbnivel = New System.Windows.Forms.Label
        Me.txtnom = New System.Windows.Forms.TextBox
        Me.txtcod = New System.Windows.Forms.TextBox
        Me.c3 = New System.Windows.Forms.RadioButton
        Me.txtcod2 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtcod1 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.c2 = New System.Windows.Forms.RadioButton
        Me.c1 = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.rbmod2 = New System.Windows.Forms.RadioButton
        Me.rbmod1 = New System.Windows.Forms.RadioButton
        Me.ChBase = New System.Windows.Forms.CheckBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtUtilidad = New System.Windows.Forms.TextBox
        Me.a3 = New System.Windows.Forms.RadioButton
        Me.txtprecio = New System.Windows.Forms.TextBox
        Me.a1 = New System.Windows.Forms.RadioButton
        Me.txtmonto = New System.Windows.Forms.TextBox
        Me.a2 = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtporcentaje = New System.Windows.Forms.TextBox
        Me.a4 = New System.Windows.Forms.RadioButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lba = New System.Windows.Forms.Label
        Me.p2 = New System.Windows.Forms.RadioButton
        Me.p1 = New System.Windows.Forms.RadioButton
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmditem = New System.Windows.Forms.Button
        Me.cmdcancelar = New System.Windows.Forms.Button
        Me.cmdguardar = New System.Windows.Forms.Button
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.txtlista = New System.Windows.Forms.TextBox
        Me.cblista = New System.Windows.Forms.ComboBox
        Me.rbl2 = New System.Windows.Forms.RadioButton
        Me.rbl1 = New System.Windows.Forms.RadioButton
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lb1)
        Me.GroupBox1.Controls.Add(Me.rb2)
        Me.GroupBox1.Controls.Add(Me.rb1)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(564, 81)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Modificar Precios de"
        '
        'lb1
        '
        Me.lb1.Location = New System.Drawing.Point(157, 27)
        Me.lb1.Name = "lb1"
        Me.lb1.Size = New System.Drawing.Size(337, 22)
        Me.lb1.TabIndex = 2
        Me.lb1.Text = "(Los precios seran aumentados desde el periodo 09/2011)"
        '
        'rb2
        '
        Me.rb2.AutoSize = True
        Me.rb2.Location = New System.Drawing.Point(16, 52)
        Me.rb2.Name = "rb2"
        Me.rb2.Size = New System.Drawing.Size(159, 17)
        Me.rb2.TabIndex = 1
        Me.rb2.Text = "Servicios / Items facturables"
        Me.rb2.UseVisualStyleBackColor = True
        '
        'rb1
        '
        Me.rb1.AutoSize = True
        Me.rb1.Checked = True
        Me.rb1.Location = New System.Drawing.Point(16, 25)
        Me.rb1.Name = "rb1"
        Me.rb1.Size = New System.Drawing.Size(135, 17)
        Me.rb1.TabIndex = 0
        Me.rb1.TabStop = True
        Me.rb1.Text = "Articulos de Inventarios"
        Me.rb1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbprecio)
        Me.GroupBox2.Controls.Add(Me.lbiva)
        Me.GroupBox2.Controls.Add(Me.txtnom2)
        Me.GroupBox2.Controls.Add(Me.txtnom1)
        Me.GroupBox2.Controls.Add(Me.lbnivel)
        Me.GroupBox2.Controls.Add(Me.txtnom)
        Me.GroupBox2.Controls.Add(Me.txtcod)
        Me.GroupBox2.Controls.Add(Me.c3)
        Me.GroupBox2.Controls.Add(Me.txtcod2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtcod1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.c2)
        Me.GroupBox2.Controls.Add(Me.c1)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 174)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(564, 104)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Modificar a"
        '
        'lbprecio
        '
        Me.lbprecio.AutoSize = True
        Me.lbprecio.Location = New System.Drawing.Point(175, 10)
        Me.lbprecio.Name = "lbprecio"
        Me.lbprecio.Size = New System.Drawing.Size(28, 13)
        Me.lbprecio.TabIndex = 71
        Me.lbprecio.Text = "0,00"
        Me.lbprecio.Visible = False
        '
        'lbiva
        '
        Me.lbiva.AutoSize = True
        Me.lbiva.Location = New System.Drawing.Point(130, 10)
        Me.lbiva.Name = "lbiva"
        Me.lbiva.Size = New System.Drawing.Size(21, 13)
        Me.lbiva.TabIndex = 70
        Me.lbiva.Text = "iva"
        Me.lbiva.Visible = False
        '
        'txtnom2
        '
        Me.txtnom2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnom2.Enabled = False
        Me.txtnom2.Location = New System.Drawing.Point(337, 49)
        Me.txtnom2.Name = "txtnom2"
        Me.txtnom2.ReadOnly = True
        Me.txtnom2.Size = New System.Drawing.Size(216, 20)
        Me.txtnom2.TabIndex = 69
        '
        'txtnom1
        '
        Me.txtnom1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnom1.Enabled = False
        Me.txtnom1.Location = New System.Drawing.Point(337, 25)
        Me.txtnom1.Name = "txtnom1"
        Me.txtnom1.ReadOnly = True
        Me.txtnom1.Size = New System.Drawing.Size(216, 20)
        Me.txtnom1.TabIndex = 68
        '
        'lbnivel
        '
        Me.lbnivel.AutoSize = True
        Me.lbnivel.Location = New System.Drawing.Point(85, 10)
        Me.lbnivel.Name = "lbnivel"
        Me.lbnivel.Size = New System.Drawing.Size(29, 13)
        Me.lbnivel.TabIndex = 67
        Me.lbnivel.Text = "nivel"
        Me.lbnivel.Visible = False
        '
        'txtnom
        '
        Me.txtnom.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnom.Enabled = False
        Me.txtnom.Location = New System.Drawing.Point(244, 78)
        Me.txtnom.Name = "txtnom"
        Me.txtnom.ReadOnly = True
        Me.txtnom.Size = New System.Drawing.Size(309, 20)
        Me.txtnom.TabIndex = 66
        '
        'txtcod
        '
        Me.txtcod.Enabled = False
        Me.txtcod.Location = New System.Drawing.Point(133, 78)
        Me.txtcod.Name = "txtcod"
        Me.txtcod.Size = New System.Drawing.Size(105, 20)
        Me.txtcod.TabIndex = 7
        '
        'c3
        '
        Me.c3.AutoSize = True
        Me.c3.Location = New System.Drawing.Point(15, 77)
        Me.c3.Name = "c3"
        Me.c3.Size = New System.Drawing.Size(99, 17)
        Me.c3.TabIndex = 6
        Me.c3.Text = "Un Solo Codigo"
        Me.c3.UseVisualStyleBackColor = True
        '
        'txtcod2
        '
        Me.txtcod2.Enabled = False
        Me.txtcod2.Location = New System.Drawing.Point(225, 50)
        Me.txtcod2.Name = "txtcod2"
        Me.txtcod2.Size = New System.Drawing.Size(105, 20)
        Me.txtcod2.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(139, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Codigo Final"
        '
        'txtcod1
        '
        Me.txtcod1.Enabled = False
        Me.txtcod1.Location = New System.Drawing.Point(226, 26)
        Me.txtcod1.Name = "txtcod1"
        Me.txtcod1.Size = New System.Drawing.Size(105, 20)
        Me.txtcod1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(134, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Codigo Inicial"
        '
        'c2
        '
        Me.c2.AutoSize = True
        Me.c2.Location = New System.Drawing.Point(16, 52)
        Me.c2.Name = "c2"
        Me.c2.Size = New System.Drawing.Size(113, 17)
        Me.c2.TabIndex = 1
        Me.c2.Text = "Rango de Codigos"
        Me.c2.UseVisualStyleBackColor = True
        '
        'c1
        '
        Me.c1.AutoSize = True
        Me.c1.Checked = True
        Me.c1.Location = New System.Drawing.Point(16, 26)
        Me.c1.Name = "c1"
        Me.c1.Size = New System.Drawing.Size(111, 17)
        Me.c1.TabIndex = 0
        Me.c1.TabStop = True
        Me.c1.Text = "Todos los codigos"
        Me.c1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox6)
        Me.GroupBox3.Controls.Add(Me.GroupBox5)
        Me.GroupBox3.Location = New System.Drawing.Point(4, 278)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(564, 111)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tipo de Modificación"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.rbmod2)
        Me.GroupBox6.Controls.Add(Me.rbmod1)
        Me.GroupBox6.Controls.Add(Me.ChBase)
        Me.GroupBox6.Location = New System.Drawing.Point(11, 13)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(270, 90)
        Me.GroupBox6.TabIndex = 0
        Me.GroupBox6.TabStop = False
        '
        'rbmod2
        '
        Me.rbmod2.AutoSize = True
        Me.rbmod2.Location = New System.Drawing.Point(141, 15)
        Me.rbmod2.Name = "rbmod2"
        Me.rbmod2.Size = New System.Drawing.Size(123, 17)
        Me.rbmod2.TabIndex = 2
        Me.rbmod2.Text = "Disminuir Valores ( - )"
        Me.rbmod2.UseVisualStyleBackColor = True
        '
        'rbmod1
        '
        Me.rbmod1.AutoSize = True
        Me.rbmod1.Checked = True
        Me.rbmod1.Location = New System.Drawing.Point(5, 15)
        Me.rbmod1.Name = "rbmod1"
        Me.rbmod1.Size = New System.Drawing.Size(129, 17)
        Me.rbmod1.TabIndex = 1
        Me.rbmod1.TabStop = True
        Me.rbmod1.Text = "Aumentar Valores ( + )"
        Me.rbmod1.UseVisualStyleBackColor = True
        '
        'ChBase
        '
        Me.ChBase.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.ChBase.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.ChBase.Location = New System.Drawing.Point(5, 44)
        Me.ChBase.Name = "ChBase"
        Me.ChBase.Size = New System.Drawing.Size(241, 30)
        Me.ChBase.TabIndex = 3
        Me.ChBase.Text = "Tener como Base el Precio de la Lista 1 para las demas Listas"
        Me.ChBase.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.ChBase.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.txtUtilidad)
        Me.GroupBox5.Controls.Add(Me.a3)
        Me.GroupBox5.Controls.Add(Me.txtprecio)
        Me.GroupBox5.Controls.Add(Me.a1)
        Me.GroupBox5.Controls.Add(Me.txtmonto)
        Me.GroupBox5.Controls.Add(Me.a2)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.txtporcentaje)
        Me.GroupBox5.Controls.Add(Me.a4)
        Me.GroupBox5.Location = New System.Drawing.Point(283, 13)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(270, 90)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(168, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(19, 15)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "%"
        '
        'txtUtilidad
        '
        Me.txtUtilidad.Enabled = False
        Me.txtUtilidad.Location = New System.Drawing.Point(117, 69)
        Me.txtUtilidad.MaxLength = 6
        Me.txtUtilidad.Name = "txtUtilidad"
        Me.txtUtilidad.Size = New System.Drawing.Size(47, 20)
        Me.txtUtilidad.TabIndex = 8
        Me.txtUtilidad.Text = "0,00"
        Me.txtUtilidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'a3
        '
        Me.a3.AutoSize = True
        Me.a3.Enabled = False
        Me.a3.Location = New System.Drawing.Point(7, 51)
        Me.a3.Name = "a3"
        Me.a3.Size = New System.Drawing.Size(99, 17)
        Me.a3.TabIndex = 5
        Me.a3.Text = "Precio (Sin IVA)"
        Me.a3.UseVisualStyleBackColor = True
        '
        'txtprecio
        '
        Me.txtprecio.Location = New System.Drawing.Point(117, 50)
        Me.txtprecio.Name = "txtprecio"
        Me.txtprecio.Size = New System.Drawing.Size(129, 20)
        Me.txtprecio.TabIndex = 6
        Me.txtprecio.Text = "0,00"
        Me.txtprecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'a1
        '
        Me.a1.AutoSize = True
        Me.a1.Checked = True
        Me.a1.Location = New System.Drawing.Point(6, 10)
        Me.a1.Name = "a1"
        Me.a1.Size = New System.Drawing.Size(55, 17)
        Me.a1.TabIndex = 0
        Me.a1.TabStop = True
        Me.a1.Text = "Monto"
        Me.a1.UseVisualStyleBackColor = True
        '
        'txtmonto
        '
        Me.txtmonto.Location = New System.Drawing.Point(117, 10)
        Me.txtmonto.Name = "txtmonto"
        Me.txtmonto.Size = New System.Drawing.Size(129, 20)
        Me.txtmonto.TabIndex = 2
        Me.txtmonto.Text = "0,00"
        Me.txtmonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'a2
        '
        Me.a2.AutoSize = True
        Me.a2.Location = New System.Drawing.Point(6, 31)
        Me.a2.Name = "a2"
        Me.a2.Size = New System.Drawing.Size(76, 17)
        Me.a2.TabIndex = 1
        Me.a2.Text = "Porcentaje"
        Me.a2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(168, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "%"
        '
        'txtporcentaje
        '
        Me.txtporcentaje.Enabled = False
        Me.txtporcentaje.Location = New System.Drawing.Point(117, 31)
        Me.txtporcentaje.MaxLength = 6
        Me.txtporcentaje.Name = "txtporcentaje"
        Me.txtporcentaje.Size = New System.Drawing.Size(47, 20)
        Me.txtporcentaje.TabIndex = 3
        Me.txtporcentaje.Text = "0,00"
        Me.txtporcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'a4
        '
        Me.a4.AutoSize = True
        Me.a4.Location = New System.Drawing.Point(7, 70)
        Me.a4.Name = "a4"
        Me.a4.Size = New System.Drawing.Size(114, 17)
        Me.a4.TabIndex = 7
        Me.a4.Text = "Porcentaje Utilidad"
        Me.a4.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lba)
        Me.GroupBox4.Controls.Add(Me.p2)
        Me.GroupBox4.Controls.Add(Me.p1)
        Me.GroupBox4.Location = New System.Drawing.Point(4, 391)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(564, 81)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Aproximar Precios"
        '
        'lba
        '
        Me.lba.AutoSize = True
        Me.lba.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lba.ForeColor = System.Drawing.Color.DarkRed
        Me.lba.Location = New System.Drawing.Point(175, 41)
        Me.lba.Name = "lba"
        Me.lba.Size = New System.Drawing.Size(319, 16)
        Me.lba.TabIndex = 2
        Me.lba.Text = "Modificando Lista de Precios Favor Espere..."
        '
        'p2
        '
        Me.p2.AutoSize = True
        Me.p2.Location = New System.Drawing.Point(16, 54)
        Me.p2.Name = "p2"
        Me.p2.Size = New System.Drawing.Size(146, 17)
        Me.p2.TabIndex = 1
        Me.p2.Text = "Sin Decimales  (1.000,00)"
        Me.p2.UseVisualStyleBackColor = True
        '
        'p1
        '
        Me.p1.AutoSize = True
        Me.p1.Checked = True
        Me.p1.Location = New System.Drawing.Point(16, 26)
        Me.p1.Name = "p1"
        Me.p1.Size = New System.Drawing.Size(148, 17)
        Me.p1.TabIndex = 0
        Me.p1.TabStop = True
        Me.p1.Text = "Con 2 decimales  (999,99)"
        Me.p1.UseVisualStyleBackColor = True
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmditem)
        Me.GroupPanel1.Controls.Add(Me.cmdcancelar)
        Me.GroupPanel1.Controls.Add(Me.cmdguardar)
        Me.GroupPanel1.Location = New System.Drawing.Point(4, 475)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(564, 78)
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
        Me.GroupPanel1.TabIndex = 34
        '
        'cmditem
        '
        Me.cmditem.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmditem.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmditem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmditem.ForeColor = System.Drawing.Color.Transparent
        Me.cmditem.Image = Global.SAE.My.Resources.Resources.notas2
        Me.cmditem.Location = New System.Drawing.Point(240, 3)
        Me.cmditem.Name = "cmditem"
        Me.cmditem.Size = New System.Drawing.Size(72, 68)
        Me.cmditem.TabIndex = 2
        Me.cmditem.Text = "&c"
        Me.cmditem.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmditem.UseVisualStyleBackColor = False
        '
        'cmdcancelar
        '
        Me.cmdcancelar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdcancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdcancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancelar.ForeColor = System.Drawing.Color.Transparent
        Me.cmdcancelar.Image = Global.SAE.My.Resources.Resources.cparam
        Me.cmdcancelar.Location = New System.Drawing.Point(315, 3)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(72, 68)
        Me.cmdcancelar.TabIndex = 1
        Me.cmdcancelar.Text = "&c"
        Me.cmdcancelar.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdcancelar, "Salir sin guardar")
        Me.cmdcancelar.UseVisualStyleBackColor = False
        '
        'cmdguardar
        '
        Me.cmdguardar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdguardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdguardar.ForeColor = System.Drawing.Color.Transparent
        Me.cmdguardar.Image = Global.SAE.My.Resources.Resources.gparam
        Me.cmdguardar.Location = New System.Drawing.Point(166, 3)
        Me.cmdguardar.Name = "cmdguardar"
        Me.cmdguardar.Size = New System.Drawing.Size(72, 68)
        Me.cmdguardar.TabIndex = 0
        Me.cmdguardar.Text = "      &g"
        Me.cmdguardar.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdguardar, "Guardar Cambios")
        Me.cmdguardar.UseVisualStyleBackColor = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.txtlista)
        Me.GroupBox7.Controls.Add(Me.cblista)
        Me.GroupBox7.Controls.Add(Me.rbl2)
        Me.GroupBox7.Controls.Add(Me.rbl1)
        Me.GroupBox7.Location = New System.Drawing.Point(4, 87)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(564, 81)
        Me.GroupBox7.TabIndex = 35
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Aplicar a"
        '
        'txtlista
        '
        Me.txtlista.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtlista.Enabled = False
        Me.txtlista.Location = New System.Drawing.Point(207, 52)
        Me.txtlista.Name = "txtlista"
        Me.txtlista.ReadOnly = True
        Me.txtlista.Size = New System.Drawing.Size(346, 20)
        Me.txtlista.TabIndex = 65
        '
        'cblista
        '
        Me.cblista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cblista.Enabled = False
        Me.cblista.FormattingEnabled = True
        Me.cblista.Location = New System.Drawing.Point(136, 52)
        Me.cblista.Name = "cblista"
        Me.cblista.Size = New System.Drawing.Size(65, 21)
        Me.cblista.TabIndex = 64
        '
        'rbl2
        '
        Me.rbl2.AutoSize = True
        Me.rbl2.Location = New System.Drawing.Point(16, 52)
        Me.rbl2.Name = "rbl2"
        Me.rbl2.Size = New System.Drawing.Size(118, 17)
        Me.rbl2.TabIndex = 1
        Me.rbl2.Text = "Una lista de precios"
        Me.rbl2.UseVisualStyleBackColor = True
        '
        'rbl1
        '
        Me.rbl1.AutoSize = True
        Me.rbl1.Checked = True
        Me.rbl1.Location = New System.Drawing.Point(16, 26)
        Me.rbl1.Name = "rbl1"
        Me.rbl1.Size = New System.Drawing.Size(149, 17)
        Me.rbl1.TabIndex = 0
        Me.rbl1.TabStop = True
        Me.rbl1.Text = "Todas las listas de precios"
        Me.rbl1.UseVisualStyleBackColor = True
        '
        'FrmAumentarPrecios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CancelButton = Me.cmdcancelar
        Me.ClientSize = New System.Drawing.Size(574, 558)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAumentarPrecios"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "   SAE Modificar Precios"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rb2 As System.Windows.Forms.RadioButton
    Friend WithEvents rb1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents c2 As System.Windows.Forms.RadioButton
    Friend WithEvents c1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents a2 As System.Windows.Forms.RadioButton
    Friend WithEvents a1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents p2 As System.Windows.Forms.RadioButton
    Friend WithEvents p1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdcancelar As System.Windows.Forms.Button
    Friend WithEvents cmdguardar As System.Windows.Forms.Button
    Friend WithEvents txtcod2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtcod1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtmonto As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtporcentaje As System.Windows.Forms.TextBox
    Friend WithEvents lb1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents rbmod2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbmod1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents rbl2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbl1 As System.Windows.Forms.RadioButton
    Friend WithEvents txtlista As System.Windows.Forms.TextBox
    Friend WithEvents cblista As System.Windows.Forms.ComboBox
    Friend WithEvents lba As System.Windows.Forms.Label
    Friend WithEvents ChBase As System.Windows.Forms.CheckBox
    Friend WithEvents txtnom As System.Windows.Forms.TextBox
    Friend WithEvents txtcod As System.Windows.Forms.TextBox
    Friend WithEvents c3 As System.Windows.Forms.RadioButton
    Friend WithEvents lbnivel As System.Windows.Forms.Label
    Friend WithEvents txtnom2 As System.Windows.Forms.TextBox
    Friend WithEvents txtnom1 As System.Windows.Forms.TextBox
    Friend WithEvents a3 As System.Windows.Forms.RadioButton
    Friend WithEvents txtprecio As System.Windows.Forms.TextBox
    Friend WithEvents lbiva As System.Windows.Forms.Label
    Friend WithEvents lbprecio As System.Windows.Forms.Label
    Friend WithEvents cmditem As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtUtilidad As System.Windows.Forms.TextBox
    Friend WithEvents a4 As System.Windows.Forms.RadioButton
End Class
