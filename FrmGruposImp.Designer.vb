<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGruposImp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGruposImp))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtDescriGral = New System.Windows.Forms.TextBox
        Me.TxtCodGral = New System.Windows.Forms.TextBox
        Me.lbnroobs = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.lbestado = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CmdEliminar = New System.Windows.Forms.Button
        Me.CmdMostrar = New System.Windows.Forms.Button
        Me.cmdNuevo = New System.Windows.Forms.Button
        Me.CmdUltimo = New System.Windows.Forms.Button
        Me.CmdSiguiente = New System.Windows.Forms.Button
        Me.CmdAtras = New System.Windows.Forms.Button
        Me.CmdPrimero = New System.Windows.Forms.Button
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdcancelar = New System.Windows.Forms.Button
        Me.cmdmodificar = New System.Windows.Forms.Button
        Me.cmdguardar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtDescriGral)
        Me.GroupBox2.Controls.Add(Me.TxtCodGral)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(656, 89)
        Me.GroupBox2.TabIndex = 68
        Me.GroupBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 16)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Descripción"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(21, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(154, 16)
        Me.Label10.TabIndex = 50
        Me.Label10.Text = "Código del Concepto"
        '
        'txtDescriGral
        '
        Me.txtDescriGral.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtDescriGral.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescriGral.Location = New System.Drawing.Point(187, 48)
        Me.txtDescriGral.MaxLength = 50
        Me.txtDescriGral.Name = "txtDescriGral"
        Me.txtDescriGral.Size = New System.Drawing.Size(444, 20)
        Me.txtDescriGral.TabIndex = 1
        '
        'TxtCodGral
        '
        Me.TxtCodGral.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TxtCodGral.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCodGral.Location = New System.Drawing.Point(187, 19)
        Me.TxtCodGral.MaxLength = 4
        Me.TxtCodGral.Name = "TxtCodGral"
        Me.TxtCodGral.Size = New System.Drawing.Size(45, 20)
        Me.TxtCodGral.TabIndex = 0
        '
        'lbnroobs
        '
        Me.lbnroobs.AutoSize = True
        Me.lbnroobs.BackColor = System.Drawing.Color.Transparent
        Me.lbnroobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnroobs.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbnroobs.Location = New System.Drawing.Point(604, 157)
        Me.lbnroobs.Name = "lbnroobs"
        Me.lbnroobs.Size = New System.Drawing.Size(35, 13)
        Me.lbnroobs.TabIndex = 80
        Me.lbnroobs.Text = "0000"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label38.Location = New System.Drawing.Point(521, 156)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(82, 13)
        Me.Label38.TabIndex = 79
        Me.Label38.Text = "Registro Nro."
        '
        'lbestado
        '
        Me.lbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbestado.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbestado.Location = New System.Drawing.Point(13, 157)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(108, 22)
        Me.lbestado.TabIndex = 78
        Me.lbestado.Text = "NULO"
        '
        'CmdEliminar
        '
        Me.CmdEliminar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.CmdEliminar.Image = Global.SAE.My.Resources.Resources.eliminar
        Me.CmdEliminar.Location = New System.Drawing.Point(214, 12)
        Me.CmdEliminar.Name = "CmdEliminar"
        Me.CmdEliminar.Size = New System.Drawing.Size(52, 38)
        Me.CmdEliminar.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.CmdEliminar, "Eliminar")
        Me.CmdEliminar.UseVisualStyleBackColor = False
        '
        'CmdMostrar
        '
        Me.CmdMostrar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.CmdMostrar.Image = Global.SAE.My.Resources.Resources.DataTables
        Me.CmdMostrar.Location = New System.Drawing.Point(265, 12)
        Me.CmdMostrar.Name = "CmdMostrar"
        Me.CmdMostrar.Size = New System.Drawing.Size(52, 38)
        Me.CmdMostrar.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.CmdMostrar, "Mostrar")
        Me.CmdMostrar.UseVisualStyleBackColor = False
        '
        'cmdNuevo
        '
        Me.cmdNuevo.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdNuevo.Image = Global.SAE.My.Resources.Resources.nuevo
        Me.cmdNuevo.Location = New System.Drawing.Point(6, 12)
        Me.cmdNuevo.Name = "cmdNuevo"
        Me.cmdNuevo.Size = New System.Drawing.Size(52, 38)
        Me.cmdNuevo.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.cmdNuevo, "Nuevo")
        Me.cmdNuevo.UseVisualStyleBackColor = False
        '
        'CmdUltimo
        '
        Me.CmdUltimo.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.CmdUltimo.Image = CType(resources.GetObject("CmdUltimo.Image"), System.Drawing.Image)
        Me.CmdUltimo.Location = New System.Drawing.Point(596, 12)
        Me.CmdUltimo.Name = "CmdUltimo"
        Me.CmdUltimo.Size = New System.Drawing.Size(52, 38)
        Me.CmdUltimo.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.CmdUltimo, "Último")
        Me.CmdUltimo.UseVisualStyleBackColor = False
        '
        'CmdSiguiente
        '
        Me.CmdSiguiente.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.CmdSiguiente.Image = CType(resources.GetObject("CmdSiguiente.Image"), System.Drawing.Image)
        Me.CmdSiguiente.Location = New System.Drawing.Point(545, 12)
        Me.CmdSiguiente.Name = "CmdSiguiente"
        Me.CmdSiguiente.Size = New System.Drawing.Size(52, 38)
        Me.CmdSiguiente.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.CmdSiguiente, "Siguiente")
        Me.CmdSiguiente.UseVisualStyleBackColor = False
        '
        'CmdAtras
        '
        Me.CmdAtras.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.CmdAtras.Image = CType(resources.GetObject("CmdAtras.Image"), System.Drawing.Image)
        Me.CmdAtras.Location = New System.Drawing.Point(494, 12)
        Me.CmdAtras.Name = "CmdAtras"
        Me.CmdAtras.Size = New System.Drawing.Size(52, 38)
        Me.CmdAtras.TabIndex = 9
        Me.CmdAtras.Text = " "
        Me.ToolTip1.SetToolTip(Me.CmdAtras, "Atrás")
        Me.CmdAtras.UseVisualStyleBackColor = False
        '
        'CmdPrimero
        '
        Me.CmdPrimero.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.CmdPrimero.Image = CType(resources.GetObject("CmdPrimero.Image"), System.Drawing.Image)
        Me.CmdPrimero.Location = New System.Drawing.Point(443, 12)
        Me.CmdPrimero.Name = "CmdPrimero"
        Me.CmdPrimero.Size = New System.Drawing.Size(52, 38)
        Me.CmdPrimero.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.CmdPrimero, "Primero")
        Me.CmdPrimero.UseVisualStyleBackColor = False
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.salir
        Me.cmdsalir.Location = New System.Drawing.Point(316, 12)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(52, 38)
        Me.cmdsalir.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.cmdsalir, "Salir")
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'cmdcancelar
        '
        Me.cmdcancelar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdcancelar.Image = Global.SAE.My.Resources.Resources.cancelar
        Me.cmdcancelar.Location = New System.Drawing.Point(110, 12)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(52, 38)
        Me.cmdcancelar.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.cmdcancelar, "Cancelar")
        Me.cmdcancelar.UseVisualStyleBackColor = False
        '
        'cmdmodificar
        '
        Me.cmdmodificar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdmodificar.Image = Global.SAE.My.Resources.Resources.editar
        Me.cmdmodificar.Location = New System.Drawing.Point(162, 12)
        Me.cmdmodificar.Name = "cmdmodificar"
        Me.cmdmodificar.Size = New System.Drawing.Size(52, 38)
        Me.cmdmodificar.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.cmdmodificar, "Editar")
        Me.cmdmodificar.UseVisualStyleBackColor = False
        '
        'cmdguardar
        '
        Me.cmdguardar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdguardar.Image = Global.SAE.My.Resources.Resources.guardar
        Me.cmdguardar.Location = New System.Drawing.Point(58, 12)
        Me.cmdguardar.Name = "cmdguardar"
        Me.cmdguardar.Size = New System.Drawing.Size(52, 38)
        Me.cmdguardar.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.cmdguardar, "Guardar")
        Me.cmdguardar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CmdEliminar)
        Me.GroupBox1.Controls.Add(Me.CmdMostrar)
        Me.GroupBox1.Controls.Add(Me.cmdNuevo)
        Me.GroupBox1.Controls.Add(Me.CmdUltimo)
        Me.GroupBox1.Controls.Add(Me.CmdSiguiente)
        Me.GroupBox1.Controls.Add(Me.CmdAtras)
        Me.GroupBox1.Controls.Add(Me.CmdPrimero)
        Me.GroupBox1.Controls.Add(Me.cmdsalir)
        Me.GroupBox1.Controls.Add(Me.cmdcancelar)
        Me.GroupBox1.Controls.Add(Me.cmdmodificar)
        Me.GroupBox1.Controls.Add(Me.cmdguardar)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 97)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(656, 56)
        Me.GroupBox1.TabIndex = 75
        Me.GroupBox1.TabStop = False
        '
        'FrmGruposImp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(676, 185)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lbnroobs)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.lbestado)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmGruposImp"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE  Conceptos Generales de Impuestos"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDescriGral As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodGral As System.Windows.Forms.TextBox
    Friend WithEvents lbnroobs As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents lbestado As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents CmdEliminar As System.Windows.Forms.Button
    Friend WithEvents CmdMostrar As System.Windows.Forms.Button
    Friend WithEvents cmdNuevo As System.Windows.Forms.Button
    Friend WithEvents CmdUltimo As System.Windows.Forms.Button
    Friend WithEvents CmdSiguiente As System.Windows.Forms.Button
    Friend WithEvents CmdAtras As System.Windows.Forms.Button
    Friend WithEvents CmdPrimero As System.Windows.Forms.Button
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdcancelar As System.Windows.Forms.Button
    Friend WithEvents cmdmodificar As System.Windows.Forms.Button
    Friend WithEvents cmdguardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
