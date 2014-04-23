<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEgresoNomina
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEgresoNomina))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbtercero = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lbcuenta = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.grilla = New System.Windows.Forms.DataGridView
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Debitos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Creditos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Base = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Nit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dg = New System.Windows.Forms.DataGridViewButtonColumn
        Me.lbsel = New System.Windows.Forms.Label
        Me.cmdTodos = New System.Windows.Forms.Button
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.CmdBuscar = New System.Windows.Forms.Button
        Me.txtperiodo = New System.Windows.Forms.TextBox
        Me.txtdia = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtnumero = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtnomdoc = New System.Windows.Forms.TextBox
        Me.txtdoc = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbper = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbtercero)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lbcuenta)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.grilla)
        Me.GroupBox1.Controls.Add(Me.lbsel)
        Me.GroupBox1.Controls.Add(Me.cmdTodos)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.txtperiodo)
        Me.GroupBox1.Controls.Add(Me.txtdia)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtnumero)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtnomdoc)
        Me.GroupBox1.Controls.Add(Me.txtdoc)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbper)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(850, 335)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'lbtercero
        '
        Me.lbtercero.AutoSize = True
        Me.lbtercero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbtercero.Location = New System.Drawing.Point(90, 311)
        Me.lbtercero.Name = "lbtercero"
        Me.lbtercero.Size = New System.Drawing.Size(71, 15)
        Me.lbtercero.TabIndex = 77
        Me.lbtercero.Text = "++++++++"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 311)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 15)
        Me.Label6.TabIndex = 76
        Me.Label6.Text = "TERCERO:"
        '
        'lbcuenta
        '
        Me.lbcuenta.AutoSize = True
        Me.lbcuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcuenta.Location = New System.Drawing.Point(85, 287)
        Me.lbcuenta.Name = "lbcuenta"
        Me.lbcuenta.Size = New System.Drawing.Size(71, 15)
        Me.lbcuenta.TabIndex = 75
        Me.lbcuenta.Text = "++++++++"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 287)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 15)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "CUENTA:"
        '
        'grilla
        '
        Me.grilla.AllowDrop = True
        Me.grilla.AllowUserToResizeColumns = False
        Me.grilla.AllowUserToResizeRows = False
        Me.grilla.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Descripcion, Me.Debitos, Me.Creditos, Me.Cuenta, Me.Base, Me.Nit, Me.cc, Me.dg})
        Me.grilla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.grilla.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.grilla.Location = New System.Drawing.Point(6, 122)
        Me.grilla.MultiSelect = False
        Me.grilla.Name = "grilla"
        Me.grilla.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.grilla.RowHeadersVisible = False
        Me.grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grilla.Size = New System.Drawing.Size(838, 152)
        Me.grilla.TabIndex = 73
        '
        'Descripcion
        '
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Descripcion.DefaultCellStyle = DataGridViewCellStyle1
        Me.Descripcion.FillWeight = 180.0!
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.MaxInputLength = 50
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Descripcion.Width = 250
        '
        'Debitos
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.ForestGreen
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Debitos.DefaultCellStyle = DataGridViewCellStyle2
        Me.Debitos.HeaderText = "Debitos"
        Me.Debitos.MaxInputLength = 30
        Me.Debitos.Name = "Debitos"
        Me.Debitos.ReadOnly = True
        Me.Debitos.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Debitos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Creditos
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkOrange
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Creditos.DefaultCellStyle = DataGridViewCellStyle3
        Me.Creditos.HeaderText = "Creditos"
        Me.Creditos.MaxInputLength = 30
        Me.Creditos.Name = "Creditos"
        Me.Creditos.ReadOnly = True
        Me.Creditos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Cuenta
        '
        Me.Cuenta.FillWeight = 80.0!
        Me.Cuenta.HeaderText = "Cuenta"
        Me.Cuenta.MaxInputLength = 12
        Me.Cuenta.Name = "Cuenta"
        Me.Cuenta.ReadOnly = True
        Me.Cuenta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cuenta.Width = 80
        '
        'Base
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Base.DefaultCellStyle = DataGridViewCellStyle4
        Me.Base.FillWeight = 80.0!
        Me.Base.HeaderText = "Base"
        Me.Base.MaxInputLength = 30
        Me.Base.Name = "Base"
        Me.Base.ReadOnly = True
        Me.Base.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Base.Width = 80
        '
        'Nit
        '
        Me.Nit.HeaderText = "Nit"
        Me.Nit.MaxInputLength = 20
        Me.Nit.MinimumWidth = 105
        Me.Nit.Name = "Nit"
        Me.Nit.ReadOnly = True
        Me.Nit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Nit.Width = 105
        '
        'cc
        '
        Me.cc.HeaderText = "cc"
        Me.cc.Name = "cc"
        Me.cc.ReadOnly = True
        Me.cc.Visible = False
        '
        'dg
        '
        Me.dg.HeaderText = "Desenglobar"
        Me.dg.Name = "dg"
        Me.dg.ReadOnly = True
        Me.dg.Text = "Desenglobar"
        Me.dg.ToolTipText = "Desenglobar Cuenta Contable"
        '
        'lbsel
        '
        Me.lbsel.AutoSize = True
        Me.lbsel.Location = New System.Drawing.Point(482, 20)
        Me.lbsel.Name = "lbsel"
        Me.lbsel.Size = New System.Drawing.Size(19, 13)
        Me.lbsel.TabIndex = 72
        Me.lbsel.Text = "no"
        Me.lbsel.Visible = False
        '
        'cmdTodos
        '
        Me.cmdTodos.Image = Global.SAE.My.Resources.Resources.DataTables
        Me.cmdTodos.Location = New System.Drawing.Point(311, 70)
        Me.cmdTodos.Name = "cmdTodos"
        Me.cmdTodos.Size = New System.Drawing.Size(40, 31)
        Me.cmdTodos.TabIndex = 7
        Me.cmdTodos.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cmdCancelar)
        Me.GroupBox5.Controls.Add(Me.CmdBuscar)
        Me.GroupBox5.Location = New System.Drawing.Point(659, 19)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(181, 97)
        Me.GroupBox5.TabIndex = 8
        Me.GroupBox5.TabStop = False
        '
        'cmdCancelar
        '
        Me.cmdCancelar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdCancelar.Image = Global.SAE.My.Resources.Resources.cparam
        Me.cmdCancelar.Location = New System.Drawing.Point(98, 15)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 73)
        Me.cmdCancelar.TabIndex = 8
        Me.cmdCancelar.UseVisualStyleBackColor = False
        '
        'CmdBuscar
        '
        Me.CmdBuscar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CmdBuscar.Image = Global.SAE.My.Resources.Resources.buscar_doc
        Me.CmdBuscar.Location = New System.Drawing.Point(12, 15)
        Me.CmdBuscar.Name = "CmdBuscar"
        Me.CmdBuscar.Size = New System.Drawing.Size(73, 73)
        Me.CmdBuscar.TabIndex = 6
        Me.CmdBuscar.UseVisualStyleBackColor = False
        '
        'txtperiodo
        '
        Me.txtperiodo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtperiodo.Enabled = False
        Me.txtperiodo.Location = New System.Drawing.Point(590, 76)
        Me.txtperiodo.Name = "txtperiodo"
        Me.txtperiodo.ReadOnly = True
        Me.txtperiodo.Size = New System.Drawing.Size(54, 20)
        Me.txtperiodo.TabIndex = 47
        Me.txtperiodo.Text = "/00/0000"
        '
        'txtdia
        '
        Me.txtdia.Enabled = False
        Me.txtdia.Location = New System.Drawing.Point(563, 76)
        Me.txtdia.MaxLength = 2
        Me.txtdia.Name = "txtdia"
        Me.txtdia.Size = New System.Drawing.Size(29, 20)
        Me.txtdia.TabIndex = 46
        Me.txtdia.Text = "00"
        Me.txtdia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(419, 77)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(140, 15)
        Me.Label10.TabIndex = 48
        Me.Label10.Text = "Fecha (dd/mm/aaaa)"
        '
        'txtnumero
        '
        Me.txtnumero.Location = New System.Drawing.Point(179, 77)
        Me.txtnumero.MaxLength = 20
        Me.txtnumero.Name = "txtnumero"
        Me.txtnumero.Size = New System.Drawing.Size(126, 20)
        Me.txtnumero.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Numero"
        '
        'txtnomdoc
        '
        Me.txtnomdoc.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnomdoc.Enabled = False
        Me.txtnomdoc.Location = New System.Drawing.Point(239, 47)
        Me.txtnomdoc.Name = "txtnomdoc"
        Me.txtnomdoc.ReadOnly = True
        Me.txtnomdoc.Size = New System.Drawing.Size(404, 20)
        Me.txtnomdoc.TabIndex = 4
        '
        'txtdoc
        '
        Me.txtdoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdoc.Location = New System.Drawing.Point(179, 47)
        Me.txtdoc.MaxLength = 2
        Me.txtdoc.Name = "txtdoc"
        Me.txtdoc.ReadOnly = True
        Me.txtdoc.Size = New System.Drawing.Size(54, 20)
        Me.txtdoc.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tipo Documento"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(157, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Buscar en el Periodo "
        '
        'cbper
        '
        Me.cbper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbper.FormattingEnabled = True
        Me.cbper.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cbper.Location = New System.Drawing.Point(179, 17)
        Me.cbper.Name = "cbper"
        Me.cbper.Size = New System.Drawing.Size(44, 21)
        Me.cbper.TabIndex = 0
        '
        'FrmEgresoNomina
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(862, 343)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEgresoNomina"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Desenglobar Egresos de Nomina"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbsel As System.Windows.Forms.Label
    Friend WithEvents cmdTodos As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdBuscar As System.Windows.Forms.Button
    Friend WithEvents txtperiodo As System.Windows.Forms.TextBox
    Friend WithEvents txtdia As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtnumero As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtnomdoc As System.Windows.Forms.TextBox
    Friend WithEvents txtdoc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbper As System.Windows.Forms.ComboBox
    Friend WithEvents grilla As System.Windows.Forms.DataGridView
    Friend WithEvents lbtercero As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbcuenta As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Debitos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Creditos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Base As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dg As System.Windows.Forms.DataGridViewButtonColumn
End Class
