<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNucleoFami
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNucleoFami))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.grilla = New System.Windows.Forms.DataGridView
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtcodG = New System.Windows.Forms.TextBox
        Me.txtpor = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtGrupo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CmdEditar = New System.Windows.Forms.Button
        Me.CmdListo = New System.Windows.Forms.Button
        Me.CmdSalir = New System.Windows.Forms.Button
        Me.CmdCancelar = New System.Windows.Forms.Button
        Me.CmdEliminar = New System.Windows.Forms.Button
        Me.CmdMostrar = New System.Windows.Forms.Button
        Me.cmdNuevo = New System.Windows.Forms.Button
        Me.lbestado = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.grilla)
        Me.GroupBox1.Controls.Add(Me.txtcodG)
        Me.GroupBox1.Controls.Add(Me.txtpor)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtGrupo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 21)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(507, 273)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'grilla
        '
        Me.grilla.AllowUserToDeleteRows = False
        Me.grilla.BackgroundColor = System.Drawing.Color.White
        Me.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.nombre, Me.fc})
        Me.grilla.GridColor = System.Drawing.Color.DimGray
        Me.grilla.Location = New System.Drawing.Point(9, 76)
        Me.grilla.Name = "grilla"
        Me.grilla.RowHeadersVisible = False
        Me.grilla.Size = New System.Drawing.Size(473, 176)
        Me.grilla.TabIndex = 78
        '
        'id
        '
        Me.id.HeaderText = "CC"
        Me.id.MinimumWidth = 100
        Me.id.Name = "id"
        '
        'nombre
        '
        Me.nombre.HeaderText = "NOMBRE"
        Me.nombre.MinimumWidth = 250
        Me.nombre.Name = "nombre"
        Me.nombre.Width = 250
        '
        'fc
        '
        Me.fc.HeaderText = "FECHA"
        Me.fc.Name = "fc"
        Me.fc.Visible = False
        '
        'txtcodG
        '
        Me.txtcodG.Location = New System.Drawing.Point(127, 20)
        Me.txtcodG.Name = "txtcodG"
        Me.txtcodG.Size = New System.Drawing.Size(135, 20)
        Me.txtcodG.TabIndex = 1
        '
        'txtpor
        '
        Me.txtpor.Location = New System.Drawing.Point(432, 21)
        Me.txtpor.Name = "txtpor"
        Me.txtpor.Size = New System.Drawing.Size(50, 20)
        Me.txtpor.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 15)
        Me.Label4.TabIndex = 78
        Me.Label4.Text = "Codigo del Grupo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(305, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Porcentaje Descuento" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtGrupo
        '
        Me.txtGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGrupo.Location = New System.Drawing.Point(127, 50)
        Me.txtGrupo.Name = "txtGrupo"
        Me.txtGrupo.Size = New System.Drawing.Size(355, 20)
        Me.txtGrupo.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre del Grupo"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox2.Controls.Add(Me.CmdEditar)
        Me.GroupBox2.Controls.Add(Me.CmdListo)
        Me.GroupBox2.Controls.Add(Me.CmdSalir)
        Me.GroupBox2.Controls.Add(Me.CmdCancelar)
        Me.GroupBox2.Controls.Add(Me.CmdEliminar)
        Me.GroupBox2.Controls.Add(Me.CmdMostrar)
        Me.GroupBox2.Controls.Add(Me.cmdNuevo)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 294)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(507, 56)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'CmdEditar
        '
        Me.CmdEditar.Image = Global.SAE.My.Resources.Resources.editar
        Me.CmdEditar.Location = New System.Drawing.Point(218, 12)
        Me.CmdEditar.Name = "CmdEditar"
        Me.CmdEditar.Size = New System.Drawing.Size(52, 38)
        Me.CmdEditar.TabIndex = 4
        Me.CmdEditar.UseVisualStyleBackColor = True
        '
        'CmdListo
        '
        Me.CmdListo.Image = Global.SAE.My.Resources.Resources.guardar
        Me.CmdListo.Location = New System.Drawing.Point(112, 12)
        Me.CmdListo.Name = "CmdListo"
        Me.CmdListo.Size = New System.Drawing.Size(52, 38)
        Me.CmdListo.TabIndex = 2
        Me.CmdListo.UseVisualStyleBackColor = True
        '
        'CmdSalir
        '
        Me.CmdSalir.Image = Global.SAE.My.Resources.Resources.salir
        Me.CmdSalir.Location = New System.Drawing.Point(377, 12)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(52, 38)
        Me.CmdSalir.TabIndex = 7
        Me.CmdSalir.UseVisualStyleBackColor = True
        '
        'CmdCancelar
        '
        Me.CmdCancelar.Image = Global.SAE.My.Resources.Resources.cancelar
        Me.CmdCancelar.Location = New System.Drawing.Point(165, 12)
        Me.CmdCancelar.Name = "CmdCancelar"
        Me.CmdCancelar.Size = New System.Drawing.Size(52, 38)
        Me.CmdCancelar.TabIndex = 3
        Me.CmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdEliminar
        '
        Me.CmdEliminar.Enabled = False
        Me.CmdEliminar.Image = Global.SAE.My.Resources.Resources.eliminar
        Me.CmdEliminar.Location = New System.Drawing.Point(271, 12)
        Me.CmdEliminar.Name = "CmdEliminar"
        Me.CmdEliminar.Size = New System.Drawing.Size(52, 38)
        Me.CmdEliminar.TabIndex = 5
        Me.CmdEliminar.UseVisualStyleBackColor = True
        '
        'CmdMostrar
        '
        Me.CmdMostrar.Enabled = False
        Me.CmdMostrar.Image = Global.SAE.My.Resources.Resources.DataTables
        Me.CmdMostrar.Location = New System.Drawing.Point(324, 12)
        Me.CmdMostrar.Name = "CmdMostrar"
        Me.CmdMostrar.Size = New System.Drawing.Size(52, 38)
        Me.CmdMostrar.TabIndex = 6
        Me.CmdMostrar.UseVisualStyleBackColor = True
        '
        'cmdNuevo
        '
        Me.cmdNuevo.Image = Global.SAE.My.Resources.Resources.nuevo
        Me.cmdNuevo.Location = New System.Drawing.Point(60, 12)
        Me.cmdNuevo.Name = "cmdNuevo"
        Me.cmdNuevo.Size = New System.Drawing.Size(52, 38)
        Me.cmdNuevo.TabIndex = 1
        Me.cmdNuevo.UseVisualStyleBackColor = True
        '
        'lbestado
        '
        Me.lbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbestado.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbestado.Location = New System.Drawing.Point(426, 0)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(90, 22)
        Me.lbestado.TabIndex = 76
        Me.lbestado.Text = "NULO"
        Me.lbestado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(192, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 15)
        Me.Label3.TabIndex = 77
        Me.Label3.Text = "NUCLEO FAMILIAR"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "CC"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "NOMBRE"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 200
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 200
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "FECHA"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'FrmNucleoFami
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(526, 358)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbestado)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmNucleoFami"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Nucleo Familiar"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdEditar As System.Windows.Forms.Button
    Friend WithEvents CmdListo As System.Windows.Forms.Button
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents CmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdEliminar As System.Windows.Forms.Button
    Friend WithEvents CmdMostrar As System.Windows.Forms.Button
    Friend WithEvents cmdNuevo As System.Windows.Forms.Button
    Friend WithEvents txtpor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtGrupo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbestado As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtcodG As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents grilla As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
