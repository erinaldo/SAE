﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelDocProveedor
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
        Me.ok = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmditems = New System.Windows.Forms.Button
        Me.txtcuenta = New System.Windows.Forms.TextBox
        Me.lbfila = New System.Windows.Forms.Label
        Me.lbform = New System.Windows.Forms.Label
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.Label5 = New System.Windows.Forms.Label
        Me.gitems = New System.Windows.Forms.DataGridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmbper = New System.Windows.Forms.ComboBox
        Me.cmbbuscar = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.buscar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.docu = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.doc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.total = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.numero = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.estado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupPanel1.SuspendLayout()
        CType(Me.gitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ok
        '
        Me.ok.Location = New System.Drawing.Point(652, 16)
        Me.ok.Name = "ok"
        Me.ok.Size = New System.Drawing.Size(45, 23)
        Me.ok.TabIndex = 1
        Me.ok.Text = "Ok"
        Me.ok.UseVisualStyleBackColor = True
        '
        'cmditems
        '
        Me.cmditems.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmditems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmditems.ForeColor = System.Drawing.Color.Transparent
        Me.cmditems.Image = Global.SAE.My.Resources.Resources.seleecionar
        Me.cmditems.Location = New System.Drawing.Point(328, 3)
        Me.cmditems.Name = "cmditems"
        Me.cmditems.Size = New System.Drawing.Size(72, 68)
        Me.cmditems.TabIndex = 0
        Me.cmditems.Text = "&S"
        Me.cmditems.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmditems, "seleccionar cliente  Alt+S")
        Me.cmditems.UseVisualStyleBackColor = False
        '
        'txtcuenta
        '
        Me.txtcuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcuenta.Location = New System.Drawing.Point(421, 18)
        Me.txtcuenta.MaxLength = 100
        Me.txtcuenta.Name = "txtcuenta"
        Me.txtcuenta.Size = New System.Drawing.Size(225, 20)
        Me.txtcuenta.TabIndex = 0
        '
        'lbfila
        '
        Me.lbfila.AutoSize = True
        Me.lbfila.Location = New System.Drawing.Point(90, 48)
        Me.lbfila.Name = "lbfila"
        Me.lbfila.Size = New System.Drawing.Size(20, 13)
        Me.lbfila.TabIndex = 70
        Me.lbfila.Text = "fila"
        Me.lbfila.Visible = False
        '
        'lbform
        '
        Me.lbform.AutoSize = True
        Me.lbform.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lbform.Location = New System.Drawing.Point(90, 26)
        Me.lbform.Name = "lbform"
        Me.lbform.Size = New System.Drawing.Size(52, 13)
        Me.lbform.TabIndex = 68
        Me.lbform.Text = "formulario"
        Me.lbform.Visible = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.lbfila)
        Me.GroupPanel1.Controls.Add(Me.lbform)
        Me.GroupPanel1.Controls.Add(Me.cmditems)
        Me.GroupPanel1.Location = New System.Drawing.Point(6, 399)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(741, 85)
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
        Me.GroupPanel1.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(140, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 15)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "BUSCAR POR "
        '
        'gitems
        '
        Me.gitems.AllowUserToDeleteRows = False
        Me.gitems.AllowUserToResizeColumns = False
        Me.gitems.AllowUserToResizeRows = False
        Me.gitems.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gitems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.gitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.buscar, Me.docu, Me.doc, Me.fecha, Me.cliente, Me.total, Me.tipo, Me.numero, Me.estado})
        Me.gitems.GridColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gitems.Location = New System.Drawing.Point(6, 61)
        Me.gitems.MultiSelect = False
        Me.gitems.Name = "gitems"
        Me.gitems.RowHeadersVisible = False
        Me.gitems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gitems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gitems.Size = New System.Drawing.Size(741, 335)
        Me.gitems.StandardTab = True
        Me.gitems.TabIndex = 10
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmbper)
        Me.GroupBox3.Controls.Add(Me.cmbbuscar)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.ok)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtcuenta)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(741, 52)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        '
        'cmbper
        '
        Me.cmbper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbper.Enabled = False
        Me.cmbper.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbper.FormattingEnabled = True
        Me.cmbper.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cmbper.Location = New System.Drawing.Point(80, 18)
        Me.cmbper.Name = "cmbper"
        Me.cmbper.Size = New System.Drawing.Size(51, 21)
        Me.cmbper.TabIndex = 75
        '
        'cmbbuscar
        '
        Me.cmbbuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbbuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbbuscar.FormattingEnabled = True
        Me.cmbbuscar.Items.AddRange(New Object() {"DOC INTERNO", "DOC EXTERNO", "FECHA(dd/mm/aaaa)", "PROVEEDOR"})
        Me.cmbbuscar.Location = New System.Drawing.Point(245, 18)
        Me.cmbbuscar.Name = "cmbbuscar"
        Me.cmbbuscar.Size = New System.Drawing.Size(170, 21)
        Me.cmbbuscar.TabIndex = 75
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 15)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "PERIODO"
        '
        'buscar
        '
        Me.buscar.Frozen = True
        Me.buscar.HeaderText = "BUSCAR"
        Me.buscar.MinimumWidth = 150
        Me.buscar.Name = "buscar"
        Me.buscar.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.buscar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.buscar.ToolTipText = "buscar por apellidos"
        Me.buscar.Visible = False
        Me.buscar.Width = 150
        '
        'docu
        '
        Me.docu.HeaderText = "DOC INTERNO"
        Me.docu.MinimumWidth = 110
        Me.docu.Name = "docu"
        Me.docu.Width = 110
        '
        'doc
        '
        Me.doc.HeaderText = "DOC EXTERNO"
        Me.doc.MaxInputLength = 300
        Me.doc.MinimumWidth = 110
        Me.doc.Name = "doc"
        Me.doc.ReadOnly = True
        Me.doc.Width = 110
        '
        'fecha
        '
        Me.fecha.HeaderText = "FECHA "
        Me.fecha.MinimumWidth = 80
        Me.fecha.Name = "fecha"
        Me.fecha.ReadOnly = True
        Me.fecha.Width = 80
        '
        'cliente
        '
        Me.cliente.HeaderText = "PROVEEDOR"
        Me.cliente.MinimumWidth = 300
        Me.cliente.Name = "cliente"
        Me.cliente.ReadOnly = True
        Me.cliente.Width = 300
        '
        'total
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.total.DefaultCellStyle = DataGridViewCellStyle1
        Me.total.HeaderText = "TOTAL FACTURA"
        Me.total.MinimumWidth = 120
        Me.total.Name = "total"
        Me.total.ReadOnly = True
        Me.total.Width = 120
        '
        'tipo
        '
        Me.tipo.HeaderText = "TIPO"
        Me.tipo.Name = "tipo"
        Me.tipo.Visible = False
        '
        'numero
        '
        Me.numero.HeaderText = "NUMERO"
        Me.numero.Name = "numero"
        Me.numero.Visible = False
        '
        'estado
        '
        Me.estado.HeaderText = "estado"
        Me.estado.Name = "estado"
        Me.estado.Visible = False
        '
        'FrmSelDocProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(752, 487)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.gitems)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSelDocProveedor"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Seleccionar Documentos de Proveedores      Seleccionar = Alt+S       Salir " & _
            "= Alt+F4"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.gitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ok As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmditems As System.Windows.Forms.Button
    Friend WithEvents txtcuenta As System.Windows.Forms.TextBox
    Friend WithEvents lbfila As System.Windows.Forms.Label
    Friend WithEvents lbform As System.Windows.Forms.Label
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents gitems As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbbuscar As System.Windows.Forms.ComboBox
    Friend WithEvents cmbper As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents buscar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents docu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents doc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents estado As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
