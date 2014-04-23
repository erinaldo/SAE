<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGestionLista
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
        Me.lbnroobs = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.lbestado = New System.Windows.Forms.Label
        Me.Gbotones = New System.Windows.Forms.GroupBox
        Me.cmdcancelar = New System.Windows.Forms.Button
        Me.cmdguardar = New System.Windows.Forms.Button
        Me.CmdEliminar = New System.Windows.Forms.Button
        Me.cmdNuevo = New System.Windows.Forms.Button
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdmodificar = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.gitems = New System.Windows.Forms.DataGridView
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lbform = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtnombre = New System.Windows.Forms.TextBox
        Me.txtnum = New System.Windows.Forms.TextBox
        Me.lbtope = New System.Windows.Forms.Label
        Me.Gbotones.SuspendLayout()
        CType(Me.gitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbnroobs
        '
        Me.lbnroobs.AutoSize = True
        Me.lbnroobs.BackColor = System.Drawing.Color.Transparent
        Me.lbnroobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnroobs.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbnroobs.Location = New System.Drawing.Point(300, 296)
        Me.lbnroobs.Name = "lbnroobs"
        Me.lbnroobs.Size = New System.Drawing.Size(14, 13)
        Me.lbnroobs.TabIndex = 81
        Me.lbnroobs.Text = "0"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label38.Location = New System.Drawing.Point(217, 295)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(82, 13)
        Me.Label38.TabIndex = 80
        Me.Label38.Text = "Registro Nro."
        '
        'lbestado
        '
        Me.lbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbestado.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbestado.Location = New System.Drawing.Point(7, 296)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(108, 22)
        Me.lbestado.TabIndex = 79
        Me.lbestado.Text = "NULO"
        '
        'Gbotones
        '
        Me.Gbotones.Controls.Add(Me.cmdcancelar)
        Me.Gbotones.Controls.Add(Me.cmdguardar)
        Me.Gbotones.Controls.Add(Me.CmdEliminar)
        Me.Gbotones.Controls.Add(Me.cmdNuevo)
        Me.Gbotones.Controls.Add(Me.cmdsalir)
        Me.Gbotones.Controls.Add(Me.cmdmodificar)
        Me.Gbotones.Location = New System.Drawing.Point(4, 236)
        Me.Gbotones.Name = "Gbotones"
        Me.Gbotones.Size = New System.Drawing.Size(331, 56)
        Me.Gbotones.TabIndex = 78
        Me.Gbotones.TabStop = False
        '
        'cmdcancelar
        '
        Me.cmdcancelar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdcancelar.Image = Global.SAE.My.Resources.Resources.cancelar
        Me.cmdcancelar.Location = New System.Drawing.Point(113, 12)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(52, 38)
        Me.cmdcancelar.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.cmdcancelar, "Cancelar")
        Me.cmdcancelar.UseVisualStyleBackColor = False
        '
        'cmdguardar
        '
        Me.cmdguardar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdguardar.Image = Global.SAE.My.Resources.Resources.guardar
        Me.cmdguardar.Location = New System.Drawing.Point(61, 12)
        Me.cmdguardar.Name = "cmdguardar"
        Me.cmdguardar.Size = New System.Drawing.Size(52, 38)
        Me.cmdguardar.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.cmdguardar, "Guardar")
        Me.cmdguardar.UseVisualStyleBackColor = False
        '
        'CmdEliminar
        '
        Me.CmdEliminar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.CmdEliminar.Enabled = False
        Me.CmdEliminar.Image = Global.SAE.My.Resources.Resources.eliminar
        Me.CmdEliminar.Location = New System.Drawing.Point(217, 12)
        Me.CmdEliminar.Name = "CmdEliminar"
        Me.CmdEliminar.Size = New System.Drawing.Size(52, 38)
        Me.CmdEliminar.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.CmdEliminar, "Eliminar")
        Me.CmdEliminar.UseVisualStyleBackColor = False
        '
        'cmdNuevo
        '
        Me.cmdNuevo.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdNuevo.Image = Global.SAE.My.Resources.Resources.nuevo
        Me.cmdNuevo.Location = New System.Drawing.Point(9, 12)
        Me.cmdNuevo.Name = "cmdNuevo"
        Me.cmdNuevo.Size = New System.Drawing.Size(52, 38)
        Me.cmdNuevo.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.cmdNuevo, "Nuevo")
        Me.cmdNuevo.UseVisualStyleBackColor = False
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.salir
        Me.cmdsalir.Location = New System.Drawing.Point(269, 12)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(52, 38)
        Me.cmdsalir.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.cmdsalir, "Salir")
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'cmdmodificar
        '
        Me.cmdmodificar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdmodificar.Image = Global.SAE.My.Resources.Resources.editar
        Me.cmdmodificar.Location = New System.Drawing.Point(165, 12)
        Me.cmdmodificar.Name = "cmdmodificar"
        Me.cmdmodificar.Size = New System.Drawing.Size(52, 38)
        Me.cmdmodificar.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.cmdmodificar, "Editar")
        Me.cmdmodificar.UseVisualStyleBackColor = False
        '
        'gitems
        '
        Me.gitems.AllowUserToAddRows = False
        Me.gitems.AllowUserToDeleteRows = False
        Me.gitems.AllowUserToResizeColumns = False
        Me.gitems.AllowUserToResizeRows = False
        Me.gitems.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gitems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.gitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.nombre})
        Me.gitems.GridColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gitems.Location = New System.Drawing.Point(4, 29)
        Me.gitems.MultiSelect = False
        Me.gitems.Name = "gitems"
        Me.gitems.RowHeadersVisible = False
        Me.gitems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gitems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gitems.Size = New System.Drawing.Size(331, 151)
        Me.gitems.StandardTab = True
        Me.gitems.TabIndex = 0
        '
        'ID
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.ID.DefaultCellStyle = DataGridViewCellStyle1
        Me.ID.Frozen = True
        Me.ID.HeaderText = "No."
        Me.ID.MinimumWidth = 50
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Width = 50
        '
        'nombre
        '
        Me.nombre.Frozen = True
        Me.nombre.HeaderText = "DESCRIPCIÓN  (Doble clic para seleccionar)"
        Me.nombre.MaxInputLength = 300
        Me.nombre.MinimumWidth = 260
        Me.nombre.Name = "nombre"
        Me.nombre.ReadOnly = True
        Me.nombre.Width = 260
        '
        'lbform
        '
        Me.lbform.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbform.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbform.Location = New System.Drawing.Point(84, 4)
        Me.lbform.Name = "lbform"
        Me.lbform.Size = New System.Drawing.Size(159, 22)
        Me.lbform.TabIndex = 83
        Me.lbform.Text = "TIPO DE GESTION"
        Me.lbform.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtnombre)
        Me.GroupBox1.Controls.Add(Me.txtnum)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 180)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(331, 56)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(73, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Descripción"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Numero"
        '
        'txtnombre
        '
        Me.txtnombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnombre.Location = New System.Drawing.Point(73, 30)
        Me.txtnombre.MaxLength = 70
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.Size = New System.Drawing.Size(241, 20)
        Me.txtnombre.TabIndex = 1
        '
        'txtnum
        '
        Me.txtnum.Enabled = False
        Me.txtnum.Location = New System.Drawing.Point(17, 30)
        Me.txtnum.MaxLength = 4
        Me.txtnum.Name = "txtnum"
        Me.txtnum.ReadOnly = True
        Me.txtnum.Size = New System.Drawing.Size(50, 20)
        Me.txtnum.TabIndex = 0
        Me.txtnum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbtope
        '
        Me.lbtope.AutoSize = True
        Me.lbtope.ForeColor = System.Drawing.Color.Brown
        Me.lbtope.Location = New System.Drawing.Point(7, 318)
        Me.lbtope.Name = "lbtope"
        Me.lbtope.Size = New System.Drawing.Size(157, 13)
        Me.lbtope.TabIndex = 84
        Me.lbtope.Text = "* Solo puede crear 30 bodegas."
        '
        'FrmGestionLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(342, 338)
        Me.Controls.Add(Me.lbtope)
        Me.Controls.Add(Me.lbform)
        Me.Controls.Add(Me.gitems)
        Me.Controls.Add(Me.lbnroobs)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.lbestado)
        Me.Controls.Add(Me.Gbotones)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmGestionLista"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE"
        Me.Gbotones.ResumeLayout(False)
        CType(Me.gitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbnroobs As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents lbestado As System.Windows.Forms.Label
    Friend WithEvents Gbotones As System.Windows.Forms.GroupBox
    Friend WithEvents CmdEliminar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdNuevo As System.Windows.Forms.Button
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdmodificar As System.Windows.Forms.Button
    Friend WithEvents gitems As System.Windows.Forms.DataGridView
    Friend WithEvents lbform As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtnombre As System.Windows.Forms.TextBox
    Friend WithEvents txtnum As System.Windows.Forms.TextBox
    Friend WithEvents cmdcancelar As System.Windows.Forms.Button
    Friend WithEvents cmdguardar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbtope As System.Windows.Forms.Label
End Class
