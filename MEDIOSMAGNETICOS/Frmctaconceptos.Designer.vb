<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frmctaconceptos
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frmctaconceptos))
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtcon = New System.Windows.Forms.TextBox
        Me.cmbcon = New System.Windows.Forms.ComboBox
        Me.txtdesfor = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbForm = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.gcuenta = New System.Windows.Forms.DataGridView
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmddel = New System.Windows.Forms.Button
        Me.cmdadd = New System.Windows.Forms.Button
        Me.cbtmv = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.sl = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.GroupBox1.SuspendLayout()
        CType(Me.gcuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Brown
        Me.Label2.Location = New System.Drawing.Point(71, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(441, 18)
        Me.Label2.TabIndex = 90
        Me.Label2.Text = "ASIGNAR CUENTAS A CONCEPTOS"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbtmv)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtcon)
        Me.GroupBox1.Controls.Add(Me.cmbcon)
        Me.GroupBox1.Controls.Add(Me.txtdesfor)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbForm)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(528, 138)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtcon
        '
        Me.txtcon.BackColor = System.Drawing.Color.White
        Me.txtcon.Location = New System.Drawing.Point(98, 73)
        Me.txtcon.Multiline = True
        Me.txtcon.Name = "txtcon"
        Me.txtcon.ReadOnly = True
        Me.txtcon.Size = New System.Drawing.Size(418, 32)
        Me.txtcon.TabIndex = 4
        '
        'cmbcon
        '
        Me.cmbcon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbcon.FormattingEnabled = True
        Me.cmbcon.Location = New System.Drawing.Point(9, 73)
        Me.cmbcon.Name = "cmbcon"
        Me.cmbcon.Size = New System.Drawing.Size(83, 21)
        Me.cmbcon.TabIndex = 3
        '
        'txtdesfor
        '
        Me.txtdesfor.BackColor = System.Drawing.Color.White
        Me.txtdesfor.Location = New System.Drawing.Point(99, 33)
        Me.txtdesfor.Multiline = True
        Me.txtdesfor.Name = "txtdesfor"
        Me.txtdesfor.ReadOnly = True
        Me.txtdesfor.Size = New System.Drawing.Size(417, 35)
        Me.txtdesfor.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Conceptos"
        '
        'cmbForm
        '
        Me.cmbForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbForm.FormattingEnabled = True
        Me.cmbForm.Location = New System.Drawing.Point(10, 33)
        Me.cmbForm.Name = "cmbForm"
        Me.cmbForm.Size = New System.Drawing.Size(83, 21)
        Me.cmbForm.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Formatos"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Brown
        Me.Label17.Location = New System.Drawing.Point(136, 14)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(336, 16)
        Me.Label17.TabIndex = 91
        Me.Label17.Text = "_________________________________________"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.IndianRed
        Me.Label4.Location = New System.Drawing.Point(11, 320)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(335, 13)
        Me.Label4.TabIndex = 94
        Me.Label4.Text = "* Doble clic para escoger cuentas - Tecla borrar para eliminar una Fila"
        '
        'gcuenta
        '
        Me.gcuenta.AllowUserToDeleteRows = False
        Me.gcuenta.AllowUserToResizeRows = False
        Me.gcuenta.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gcuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gcuenta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cta, Me.descripcion, Me.sl})
        Me.gcuenta.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gcuenta.Location = New System.Drawing.Point(6, 176)
        Me.gcuenta.Name = "gcuenta"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gcuenta.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gcuenta.RowHeadersVisible = False
        Me.gcuenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gcuenta.Size = New System.Drawing.Size(524, 139)
        Me.gcuenta.TabIndex = 5
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmddel)
        Me.GroupPanel1.Controls.Add(Me.cmdadd)
        Me.GroupPanel1.Location = New System.Drawing.Point(6, 338)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(528, 85)
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
        'cmddel
        '
        Me.cmddel.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmddel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddel.ForeColor = System.Drawing.Color.Transparent
        Me.cmddel.Image = Global.SAE.My.Resources.Resources.back
        Me.cmddel.Location = New System.Drawing.Point(243, 4)
        Me.cmddel.Name = "cmddel"
        Me.cmddel.Size = New System.Drawing.Size(72, 68)
        Me.cmddel.TabIndex = 2
        Me.cmddel.Text = "&q"
        Me.cmddel.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmddel.UseVisualStyleBackColor = False
        '
        'cmdadd
        '
        Me.cmdadd.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdadd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdadd.ForeColor = System.Drawing.Color.Transparent
        Me.cmdadd.Image = Global.SAE.My.Resources.Resources.add
        Me.cmdadd.Location = New System.Drawing.Point(165, 4)
        Me.cmdadd.Name = "cmdadd"
        Me.cmdadd.Size = New System.Drawing.Size(72, 68)
        Me.cmdadd.TabIndex = 1
        Me.cmdadd.Text = "&a"
        Me.cmdadd.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdadd.UseVisualStyleBackColor = False
        '
        'cbtmv
        '
        Me.cbtmv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbtmv.FormattingEnabled = True
        Me.cbtmv.Items.AddRange(New Object() {"SALDO", "DEBITO", "CREDITO"})
        Me.cbtmv.Location = New System.Drawing.Point(99, 111)
        Me.cbtmv.Name = "cbtmv"
        Me.cbtmv.Size = New System.Drawing.Size(113, 21)
        Me.cbtmv.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Mostrar Valor"
        '
        'cta
        '
        Me.cta.HeaderText = "CUENTA"
        Me.cta.MinimumWidth = 100
        Me.cta.Name = "cta"
        Me.cta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'descripcion
        '
        Me.descripcion.HeaderText = "DESCRIPCION"
        Me.descripcion.MinimumWidth = 300
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ReadOnly = True
        Me.descripcion.Width = 300
        '
        'sl
        '
        Me.sl.HeaderText = "MOVIMIENTO"
        Me.sl.Items.AddRange(New Object() {"SALDO", "DEBITO", "CREDITO"})
        Me.sl.Name = "sl"
        Me.sl.ReadOnly = True
        '
        'Frmctaconceptos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(542, 429)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.gcuenta)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label17)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frmctaconceptos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gestion de Cuentas por Conceptos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.gcuenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtdesfor As System.Windows.Forms.TextBox
    Friend WithEvents cmbForm As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtcon As System.Windows.Forms.TextBox
    Friend WithEvents cmbcon As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gcuenta As System.Windows.Forms.DataGridView
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmddel As System.Windows.Forms.Button
    Friend WithEvents cmdadd As System.Windows.Forms.Button
    Friend WithEvents cbtmv As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sl As System.Windows.Forms.DataGridViewComboBoxColumn
End Class
