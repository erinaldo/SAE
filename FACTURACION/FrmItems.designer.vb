<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmItems
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gitems = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtnumfac = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txttipo2 = New System.Windows.Forms.TextBox
        Me.txttipo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.lbExistencia = New System.Windows.Forms.Label
        Me.lbParSalida = New System.Windows.Forms.Label
        Me.lbeditarnit = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbnit = New System.Windows.Forms.Label
        Me.lbbodega = New System.Windows.Forms.Label
        Me.lbiva = New System.Windows.Forms.Label
        Me.LbTipoMov = New System.Windows.Forms.Label
        Me.lbform = New System.Windows.Forms.Label
        Me.cmddel = New System.Windows.Forms.Button
        Me.cmdadd = New System.Windows.Forms.Button
        Me.cmd_descp = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtfecha = New System.Windows.Forms.DateTimePicker
        Me.cmd_cod_bar = New System.Windows.Forms.Button
        Me.cmd_refe = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbdesc = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.num = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tipo = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descrip = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cant = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.precio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bodega = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctainv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctacven = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctaing = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctaiva = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.iva = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.costo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descuento = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.disponible = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.precio2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.gitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gitems
        '
        Me.gitems.AllowUserToDeleteRows = False
        Me.gitems.AllowUserToResizeRows = False
        Me.gitems.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gitems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.gitems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.gitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.num, Me.tipo, Me.codigo, Me.descrip, Me.cant, Me.precio, Me.bodega, Me.cc, Me.ctainv, Me.ctacven, Me.ctaing, Me.ctaiva, Me.iva, Me.costo, Me.descuento, Me.nit, Me.disponible, Me.precio2})
        Me.gitems.GridColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gitems.Location = New System.Drawing.Point(8, 83)
        Me.gitems.MultiSelect = False
        Me.gitems.Name = "gitems"
        Me.gitems.RowHeadersVisible = False
        Me.gitems.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.gitems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gitems.Size = New System.Drawing.Size(891, 367)
        Me.gitems.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(530, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Fecha"
        '
        'txtnumfac
        '
        Me.txtnumfac.BackColor = System.Drawing.Color.White
        Me.txtnumfac.Enabled = False
        Me.txtnumfac.Location = New System.Drawing.Point(426, 19)
        Me.txtnumfac.Name = "txtnumfac"
        Me.txtnumfac.ReadOnly = True
        Me.txtnumfac.Size = New System.Drawing.Size(87, 20)
        Me.txtnumfac.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(379, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Número"
        '
        'txttipo2
        '
        Me.txttipo2.BackColor = System.Drawing.Color.White
        Me.txttipo2.Enabled = False
        Me.txttipo2.Location = New System.Drawing.Point(91, 19)
        Me.txttipo2.Name = "txttipo2"
        Me.txttipo2.ReadOnly = True
        Me.txttipo2.Size = New System.Drawing.Size(262, 20)
        Me.txttipo2.TabIndex = 1
        Me.txttipo2.TabStop = False
        '
        'txttipo
        '
        Me.txttipo.BackColor = System.Drawing.Color.White
        Me.txttipo.Enabled = False
        Me.txttipo.Location = New System.Drawing.Point(57, 19)
        Me.txttipo.Name = "txttipo"
        Me.txttipo.ReadOnly = True
        Me.txttipo.Size = New System.Drawing.Size(28, 20)
        Me.txttipo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Tipo"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.lbExistencia)
        Me.GroupPanel1.Controls.Add(Me.lbParSalida)
        Me.GroupPanel1.Controls.Add(Me.lbeditarnit)
        Me.GroupPanel1.Controls.Add(Me.Label5)
        Me.GroupPanel1.Controls.Add(Me.lbnit)
        Me.GroupPanel1.Controls.Add(Me.lbbodega)
        Me.GroupPanel1.Controls.Add(Me.lbiva)
        Me.GroupPanel1.Controls.Add(Me.LbTipoMov)
        Me.GroupPanel1.Controls.Add(Me.lbform)
        Me.GroupPanel1.Controls.Add(Me.cmddel)
        Me.GroupPanel1.Controls.Add(Me.cmdadd)
        Me.GroupPanel1.Controls.Add(Me.cmd_descp)
        Me.GroupPanel1.Controls.Add(Me.Button1)
        Me.GroupPanel1.Location = New System.Drawing.Point(8, 456)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(891, 85)
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
        Me.GroupPanel1.TabIndex = 70
        '
        'lbExistencia
        '
        Me.lbExistencia.AutoSize = True
        Me.lbExistencia.Location = New System.Drawing.Point(660, 55)
        Me.lbExistencia.Name = "lbExistencia"
        Me.lbExistencia.Size = New System.Drawing.Size(17, 13)
        Me.lbExistencia.TabIndex = 80
        Me.lbExistencia.Text = "SI"
        Me.lbExistencia.Visible = False
        '
        'lbParSalida
        '
        Me.lbParSalida.AutoSize = True
        Me.lbParSalida.Location = New System.Drawing.Point(728, 46)
        Me.lbParSalida.Name = "lbParSalida"
        Me.lbParSalida.Size = New System.Drawing.Size(21, 13)
        Me.lbParSalida.TabIndex = 79
        Me.lbParSalida.Text = "CS"
        Me.lbParSalida.Visible = False
        '
        'lbeditarnit
        '
        Me.lbeditarnit.AutoSize = True
        Me.lbeditarnit.BackColor = System.Drawing.Color.Transparent
        Me.lbeditarnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbeditarnit.ForeColor = System.Drawing.Color.IndianRed
        Me.lbeditarnit.Location = New System.Drawing.Point(569, 12)
        Me.lbeditarnit.Name = "lbeditarnit"
        Me.lbeditarnit.Size = New System.Drawing.Size(308, 13)
        Me.lbeditarnit.TabIndex = 11
        Me.lbeditarnit.Text = "PARA FACTURAR A OTRO N.I.T  PRESIONE Alt + N"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.IndianRed
        Me.Label5.Location = New System.Drawing.Point(14, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(307, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "PARA EDITAR LA DESCRIPCION PRESIONE Alt + D"
        '
        'lbnit
        '
        Me.lbnit.AutoSize = True
        Me.lbnit.Location = New System.Drawing.Point(582, 47)
        Me.lbnit.Name = "lbnit"
        Me.lbnit.Size = New System.Drawing.Size(24, 13)
        Me.lbnit.TabIndex = 7
        Me.lbnit.Text = "nitc"
        Me.lbnit.Visible = False
        '
        'lbbodega
        '
        Me.lbbodega.AutoSize = True
        Me.lbbodega.Location = New System.Drawing.Point(257, 20)
        Me.lbbodega.Name = "lbbodega"
        Me.lbbodega.Size = New System.Drawing.Size(13, 13)
        Me.lbbodega.TabIndex = 6
        Me.lbbodega.Text = "1"
        Me.lbbodega.Visible = False
        '
        'lbiva
        '
        Me.lbiva.AutoSize = True
        Me.lbiva.Location = New System.Drawing.Point(257, 47)
        Me.lbiva.Name = "lbiva"
        Me.lbiva.Size = New System.Drawing.Size(23, 13)
        Me.lbiva.TabIndex = 5
        Me.lbiva.Text = "NO"
        Me.lbiva.Visible = False
        '
        'LbTipoMov
        '
        Me.LbTipoMov.AutoSize = True
        Me.LbTipoMov.Location = New System.Drawing.Point(123, 47)
        Me.LbTipoMov.Name = "LbTipoMov"
        Me.LbTipoMov.Size = New System.Drawing.Size(48, 13)
        Me.LbTipoMov.TabIndex = 4
        Me.LbTipoMov.Text = "entradas"
        Me.LbTipoMov.Visible = False
        '
        'lbform
        '
        Me.lbform.AutoSize = True
        Me.lbform.Location = New System.Drawing.Point(123, 20)
        Me.lbform.Name = "lbform"
        Me.lbform.Size = New System.Drawing.Size(52, 13)
        Me.lbform.TabIndex = 3
        Me.lbform.Text = "formulario"
        Me.lbform.Visible = False
        '
        'cmddel
        '
        Me.cmddel.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmddel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddel.ForeColor = System.Drawing.Color.Transparent
        Me.cmddel.Image = Global.SAE.My.Resources.Resources.del
        Me.cmddel.Location = New System.Drawing.Point(460, 5)
        Me.cmddel.Name = "cmddel"
        Me.cmddel.Size = New System.Drawing.Size(72, 68)
        Me.cmddel.TabIndex = 2
        Me.cmddel.Text = "&Q"
        Me.cmddel.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmddel, "Quitar item Alt + Q")
        Me.cmddel.UseVisualStyleBackColor = False
        '
        'cmdadd
        '
        Me.cmdadd.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdadd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdadd.ForeColor = System.Drawing.Color.Transparent
        Me.cmdadd.Image = Global.SAE.My.Resources.Resources.add
        Me.cmdadd.Location = New System.Drawing.Point(386, 6)
        Me.cmdadd.Name = "cmdadd"
        Me.cmdadd.Size = New System.Drawing.Size(72, 68)
        Me.cmdadd.TabIndex = 1
        Me.cmdadd.Text = "&A"
        Me.cmdadd.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdadd, "Agregar a factura Alt + A")
        Me.cmdadd.UseVisualStyleBackColor = False
        '
        'cmd_descp
        '
        Me.cmd_descp.Location = New System.Drawing.Point(405, 29)
        Me.cmd_descp.Name = "cmd_descp"
        Me.cmd_descp.Size = New System.Drawing.Size(53, 31)
        Me.cmd_descp.TabIndex = 8
        Me.cmd_descp.Text = "&D"
        Me.cmd_descp.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(483, 39)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(49, 29)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "&N"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtfecha
        '
        Me.txtfecha.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtfecha.CustomFormat = "yyyy/dd/mm"
        Me.txtfecha.Enabled = False
        Me.txtfecha.Location = New System.Drawing.Point(575, 19)
        Me.txtfecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.txtfecha.Name = "txtfecha"
        Me.txtfecha.Size = New System.Drawing.Size(205, 20)
        Me.txtfecha.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.txtfecha, "fecha del pedido")
        Me.txtfecha.Value = New Date(2010, 1, 14, 0, 0, 0, 0)
        '
        'cmd_cod_bar
        '
        Me.cmd_cod_bar.Location = New System.Drawing.Point(213, 45)
        Me.cmd_cod_bar.Name = "cmd_cod_bar"
        Me.cmd_cod_bar.Size = New System.Drawing.Size(185, 23)
        Me.cmd_cod_bar.TabIndex = 5
        Me.cmd_cod_bar.Text = "Buscar Por &Codigo de Barras Alt + C"
        Me.ToolTip1.SetToolTip(Me.cmd_cod_bar, "Buscar Articulos Por Codigo de Barras Alt + C")
        Me.cmd_cod_bar.UseVisualStyleBackColor = True
        '
        'cmd_refe
        '
        Me.cmd_refe.Location = New System.Drawing.Point(20, 45)
        Me.cmd_refe.Name = "cmd_refe"
        Me.cmd_refe.Size = New System.Drawing.Size(185, 23)
        Me.cmd_refe.TabIndex = 4
        Me.cmd_refe.Text = "Buscar Por &Referencia Alt + R"
        Me.ToolTip1.SetToolTip(Me.cmd_refe, "Buscar Articulos Por Codigo de Referencia Alt + R")
        Me.cmd_refe.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(404, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 13)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = "Traer Items Con Descripción "
        '
        'cbdesc
        '
        Me.cbdesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbdesc.FormattingEnabled = True
        Me.cbdesc.Items.AddRange(New Object() {"NORMAL", "DETALLADA"})
        Me.cbdesc.Location = New System.Drawing.Point(547, 45)
        Me.cbdesc.Name = "cbdesc"
        Me.cbdesc.Size = New System.Drawing.Size(133, 21)
        Me.cbdesc.TabIndex = 6
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmd_refe)
        Me.GroupBox1.Controls.Add(Me.cmd_cod_bar)
        Me.GroupBox1.Controls.Add(Me.txtfecha)
        Me.GroupBox1.Controls.Add(Me.cbdesc)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txttipo2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtnumfac)
        Me.GroupBox1.Controls.Add(Me.txttipo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(891, 74)
        Me.GroupBox1.TabIndex = 74
        Me.GroupBox1.TabStop = False
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn1.Frozen = True
        Me.DataGridViewTextBoxColumn1.HeaderText = "   ITEM"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 63
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 63
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.Frozen = True
        Me.DataGridViewTextBoxColumn2.HeaderText = "CODIGO"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 90
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 90
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.Frozen = True
        Me.DataGridViewTextBoxColumn3.HeaderText = "DESCRIPCIÓN"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 280
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.Width = 280
        '
        'DataGridViewTextBoxColumn4
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.Format = "N1"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn4.Frozen = True
        Me.DataGridViewTextBoxColumn4.HeaderText = "CANTIDAD"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 80
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 80
        '
        'DataGridViewTextBoxColumn5
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn5.Frozen = True
        Me.DataGridViewTextBoxColumn5.HeaderText = "PRECIO"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.Format = "N0"
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn6.Frozen = True
        Me.DataGridViewTextBoxColumn6.HeaderText = "BODEGA"
        Me.DataGridViewTextBoxColumn6.MinimumWidth = 60
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 60
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.Frozen = True
        Me.DataGridViewTextBoxColumn7.HeaderText = "C. COMISIONABLE"
        Me.DataGridViewTextBoxColumn7.MinimumWidth = 120
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 120
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "CTA INVENTATIO"
        Me.DataGridViewTextBoxColumn8.MinimumWidth = 110
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Visible = False
        Me.DataGridViewTextBoxColumn8.Width = 110
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "CTA COS. VENTAS."
        Me.DataGridViewTextBoxColumn9.MinimumWidth = 112
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Visible = False
        Me.DataGridViewTextBoxColumn9.Width = 112
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "CTA INGRESO"
        Me.DataGridViewTextBoxColumn10.MinimumWidth = 110
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Visible = False
        Me.DataGridViewTextBoxColumn10.Width = 110
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "CTA IVA"
        Me.DataGridViewTextBoxColumn11.MinimumWidth = 95
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Visible = False
        Me.DataGridViewTextBoxColumn11.Width = 95
        '
        'DataGridViewTextBoxColumn12
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn12.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn12.HeaderText = "  % IVA"
        Me.DataGridViewTextBoxColumn12.MinimumWidth = 60
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Visible = False
        Me.DataGridViewTextBoxColumn12.Width = 60
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "costo"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Visible = False
        '
        'DataGridViewTextBoxColumn14
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.Format = "N2"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.DataGridViewTextBoxColumn14.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewTextBoxColumn14.HeaderText = "DESCUENTO %"
        Me.DataGridViewTextBoxColumn14.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "NIT"
        Me.DataGridViewTextBoxColumn15.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.Visible = False
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.HeaderText = "disponible"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.Visible = False
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.HeaderText = "precio2"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.Visible = False
        '
        'num
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.num.DefaultCellStyle = DataGridViewCellStyle1
        Me.num.Frozen = True
        Me.num.HeaderText = "   ITEM"
        Me.num.MinimumWidth = 63
        Me.num.Name = "num"
        Me.num.ReadOnly = True
        Me.num.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.num.Visible = False
        Me.num.Width = 63
        '
        'tipo
        '
        Me.tipo.Frozen = True
        Me.tipo.HeaderText = "TIPO"
        Me.tipo.Items.AddRange(New Object() {"I", "S"})
        Me.tipo.MinimumWidth = 50
        Me.tipo.Name = "tipo"
        Me.tipo.Width = 50
        '
        'codigo
        '
        Me.codigo.Frozen = True
        Me.codigo.HeaderText = "CODIGO"
        Me.codigo.MinimumWidth = 90
        Me.codigo.Name = "codigo"
        Me.codigo.Width = 90
        '
        'descrip
        '
        Me.descrip.Frozen = True
        Me.descrip.HeaderText = "DESCRIPCIÓN"
        Me.descrip.MinimumWidth = 280
        Me.descrip.Name = "descrip"
        Me.descrip.ReadOnly = True
        Me.descrip.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.descrip.Width = 280
        '
        'cant
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "N1"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.cant.DefaultCellStyle = DataGridViewCellStyle2
        Me.cant.Frozen = True
        Me.cant.HeaderText = "CANTIDAD"
        Me.cant.MinimumWidth = 80
        Me.cant.Name = "cant"
        Me.cant.Width = 80
        '
        'precio
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.precio.DefaultCellStyle = DataGridViewCellStyle3
        Me.precio.Frozen = True
        Me.precio.HeaderText = "PRECIO"
        Me.precio.MinimumWidth = 100
        Me.precio.Name = "precio"
        '
        'bodega
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Format = "N0"
        Me.bodega.DefaultCellStyle = DataGridViewCellStyle4
        Me.bodega.Frozen = True
        Me.bodega.HeaderText = "BODEGA"
        Me.bodega.MinimumWidth = 60
        Me.bodega.Name = "bodega"
        Me.bodega.Width = 60
        '
        'cc
        '
        Me.cc.Frozen = True
        Me.cc.HeaderText = "C. COMISIONABLE"
        Me.cc.MinimumWidth = 120
        Me.cc.Name = "cc"
        Me.cc.Width = 120
        '
        'ctainv
        '
        Me.ctainv.HeaderText = "CTA INVENTATIO"
        Me.ctainv.MinimumWidth = 110
        Me.ctainv.Name = "ctainv"
        Me.ctainv.ReadOnly = True
        Me.ctainv.Visible = False
        Me.ctainv.Width = 110
        '
        'ctacven
        '
        Me.ctacven.HeaderText = "CTA COS. VENTAS."
        Me.ctacven.MinimumWidth = 112
        Me.ctacven.Name = "ctacven"
        Me.ctacven.Visible = False
        Me.ctacven.Width = 112
        '
        'ctaing
        '
        Me.ctaing.HeaderText = "CTA INGRESO"
        Me.ctaing.MinimumWidth = 110
        Me.ctaing.Name = "ctaing"
        Me.ctaing.ReadOnly = True
        Me.ctaing.Visible = False
        Me.ctaing.Width = 110
        '
        'ctaiva
        '
        Me.ctaiva.HeaderText = "CTA IVA"
        Me.ctaiva.MinimumWidth = 95
        Me.ctaiva.Name = "ctaiva"
        Me.ctaiva.ReadOnly = True
        Me.ctaiva.Visible = False
        Me.ctaiva.Width = 95
        '
        'iva
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.iva.DefaultCellStyle = DataGridViewCellStyle5
        Me.iva.HeaderText = "  % IVA"
        Me.iva.MinimumWidth = 60
        Me.iva.Name = "iva"
        Me.iva.ReadOnly = True
        Me.iva.Visible = False
        Me.iva.Width = 60
        '
        'costo
        '
        Me.costo.HeaderText = "costo"
        Me.costo.Name = "costo"
        Me.costo.Visible = False
        '
        'descuento
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.descuento.DefaultCellStyle = DataGridViewCellStyle6
        Me.descuento.HeaderText = "DESCUENTO %"
        Me.descuento.MinimumWidth = 100
        Me.descuento.Name = "descuento"
        '
        'nit
        '
        Me.nit.HeaderText = "NIT"
        Me.nit.MinimumWidth = 100
        Me.nit.Name = "nit"
        Me.nit.Visible = False
        '
        'disponible
        '
        Me.disponible.HeaderText = "disponible"
        Me.disponible.Name = "disponible"
        Me.disponible.Visible = False
        '
        'precio2
        '
        Me.precio2.HeaderText = "precio2"
        Me.precio2.Name = "precio2"
        Me.precio2.Visible = False
        '
        'FrmItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(904, 545)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.gitems)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmItems"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE  ITEMS DEL DOCUMENTO  Alt+A=AGREGAR,  Alt+Q=QUITAR,  Alt +D= AGREGAR SERIAL" & _
            " A LA DESCRIPCION,   Alt + F4=SALIR "
        CType(Me.gitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gitems As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtnumfac As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txttipo2 As System.Windows.Forms.TextBox
    Friend WithEvents txttipo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdadd As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmddel As System.Windows.Forms.Button
    Friend WithEvents lbform As System.Windows.Forms.Label
    Friend WithEvents txtfecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents LbTipoMov As System.Windows.Forms.Label
    Friend WithEvents lbiva As System.Windows.Forms.Label
    Friend WithEvents lbbodega As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbdesc As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_cod_bar As System.Windows.Forms.Button
    Friend WithEvents cmd_refe As System.Windows.Forms.Button
    Friend WithEvents lbnit As System.Windows.Forms.Label
    Friend WithEvents cmd_descp As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lbeditarnit As System.Windows.Forms.Label
    Friend WithEvents lbParSalida As System.Windows.Forms.Label
    Friend WithEvents lbExistencia As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents num As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tipo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descrip As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents precio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bodega As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctainv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctacven As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctaing As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctaiva As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents iva As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents costo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descuento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents disponible As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents precio2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
