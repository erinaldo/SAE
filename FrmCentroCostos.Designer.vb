<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCentroCostos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCentroCostos))
        Me.lbnumero = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.lbestado = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
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
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chnivel = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lbnivel = New System.Windows.Forms.Label
        Me.lbexiste = New System.Windows.Forms.Label
        Me.txtpre = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtnombre = New System.Windows.Forms.TextBox
        Me.txtcodigo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbnumero
        '
        Me.lbnumero.AutoSize = True
        Me.lbnumero.BackColor = System.Drawing.Color.Transparent
        Me.lbnumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnumero.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbnumero.Location = New System.Drawing.Point(544, 231)
        Me.lbnumero.Name = "lbnumero"
        Me.lbnumero.Size = New System.Drawing.Size(35, 13)
        Me.lbnumero.TabIndex = 78
        Me.lbnumero.Text = "0000"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label38.Location = New System.Drawing.Point(461, 230)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(82, 13)
        Me.Label38.TabIndex = 77
        Me.Label38.Text = "Registro Nro."
        '
        'lbestado
        '
        Me.lbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbestado.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbestado.Location = New System.Drawing.Point(4, 231)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(108, 22)
        Me.lbestado.TabIndex = 76
        Me.lbestado.Text = "NULO"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CmdMostrar)
        Me.GroupBox2.Controls.Add(Me.cmdNuevo)
        Me.GroupBox2.Controls.Add(Me.CmdUltimo)
        Me.GroupBox2.Controls.Add(Me.CmdSiguiente)
        Me.GroupBox2.Controls.Add(Me.CmdAtras)
        Me.GroupBox2.Controls.Add(Me.CmdPrimero)
        Me.GroupBox2.Controls.Add(Me.cmdsalir)
        Me.GroupBox2.Controls.Add(Me.cmdcancelar)
        Me.GroupBox2.Controls.Add(Me.cmdmodificar)
        Me.GroupBox2.Controls.Add(Me.cmdguardar)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 171)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(585, 56)
        Me.GroupBox2.TabIndex = 75
        Me.GroupBox2.TabStop = False
        '
        'CmdMostrar
        '
        Me.CmdMostrar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.CmdMostrar.Image = Global.SAE.My.Resources.Resources.DataTables
        Me.CmdMostrar.Location = New System.Drawing.Point(217, 12)
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
        Me.cmdNuevo.Location = New System.Drawing.Point(9, 12)
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
        Me.CmdUltimo.Location = New System.Drawing.Point(525, 12)
        Me.CmdUltimo.Name = "CmdUltimo"
        Me.CmdUltimo.Size = New System.Drawing.Size(52, 38)
        Me.CmdUltimo.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.CmdUltimo, "Último")
        Me.CmdUltimo.UseVisualStyleBackColor = False
        '
        'CmdSiguiente
        '
        Me.CmdSiguiente.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.CmdSiguiente.Image = CType(resources.GetObject("CmdSiguiente.Image"), System.Drawing.Image)
        Me.CmdSiguiente.Location = New System.Drawing.Point(474, 12)
        Me.CmdSiguiente.Name = "CmdSiguiente"
        Me.CmdSiguiente.Size = New System.Drawing.Size(52, 38)
        Me.CmdSiguiente.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.CmdSiguiente, "Siguiente")
        Me.CmdSiguiente.UseVisualStyleBackColor = False
        '
        'CmdAtras
        '
        Me.CmdAtras.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.CmdAtras.Image = CType(resources.GetObject("CmdAtras.Image"), System.Drawing.Image)
        Me.CmdAtras.Location = New System.Drawing.Point(423, 12)
        Me.CmdAtras.Name = "CmdAtras"
        Me.CmdAtras.Size = New System.Drawing.Size(52, 38)
        Me.CmdAtras.TabIndex = 8
        Me.CmdAtras.Text = " "
        Me.ToolTip1.SetToolTip(Me.CmdAtras, "Atrás")
        Me.CmdAtras.UseVisualStyleBackColor = False
        '
        'CmdPrimero
        '
        Me.CmdPrimero.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.CmdPrimero.Image = CType(resources.GetObject("CmdPrimero.Image"), System.Drawing.Image)
        Me.CmdPrimero.Location = New System.Drawing.Point(372, 12)
        Me.CmdPrimero.Name = "CmdPrimero"
        Me.CmdPrimero.Size = New System.Drawing.Size(52, 38)
        Me.CmdPrimero.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.CmdPrimero, "Primero")
        Me.CmdPrimero.UseVisualStyleBackColor = False
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.salir
        Me.cmdsalir.Location = New System.Drawing.Point(268, 12)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(52, 38)
        Me.cmdsalir.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.cmdsalir, "Salir")
        Me.cmdsalir.UseVisualStyleBackColor = False
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chnivel)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lbnivel)
        Me.GroupBox1.Controls.Add(Me.lbexiste)
        Me.GroupBox1.Controls.Add(Me.txtpre)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtnombre)
        Me.GroupBox1.Controls.Add(Me.txtcodigo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(585, 159)
        Me.GroupBox1.TabIndex = 79
        Me.GroupBox1.TabStop = False
        '
        'chnivel
        '
        Me.chnivel.AutoSize = True
        Me.chnivel.Location = New System.Drawing.Point(11, 16)
        Me.chnivel.Name = "chnivel"
        Me.chnivel.Size = New System.Drawing.Size(102, 17)
        Me.chnivel.TabIndex = 10
        Me.chnivel.Text = "Manejar Niveles"
        Me.chnivel.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(244, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Digitos: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "NIVEL"
        '
        'lbnivel
        '
        Me.lbnivel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbnivel.ForeColor = System.Drawing.Color.Black
        Me.lbnivel.Location = New System.Drawing.Point(135, 68)
        Me.lbnivel.Name = "lbnivel"
        Me.lbnivel.Size = New System.Drawing.Size(103, 23)
        Me.lbnivel.TabIndex = 7
        Me.lbnivel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbexiste
        '
        Me.lbexiste.ForeColor = System.Drawing.Color.Maroon
        Me.lbexiste.Location = New System.Drawing.Point(241, 40)
        Me.lbexiste.Name = "lbexiste"
        Me.lbexiste.Size = New System.Drawing.Size(276, 31)
        Me.lbexiste.TabIndex = 6
        '
        'txtpre
        '
        Me.txtpre.Location = New System.Drawing.Point(135, 129)
        Me.txtpre.MaxLength = 100
        Me.txtpre.Name = "txtpre"
        Me.txtpre.Size = New System.Drawing.Size(141, 20)
        Me.txtpre.TabIndex = 5
        Me.txtpre.Text = "0,00"
        Me.txtpre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "PRESUPUESTO"
        '
        'txtnombre
        '
        Me.txtnombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnombre.Location = New System.Drawing.Point(135, 97)
        Me.txtnombre.MaxLength = 99
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.Size = New System.Drawing.Size(441, 20)
        Me.txtnombre.TabIndex = 3
        '
        'txtcodigo
        '
        Me.txtcodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcodigo.Enabled = False
        Me.txtcodigo.Location = New System.Drawing.Point(135, 40)
        Me.txtcodigo.MaxLength = 50
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.Size = New System.Drawing.Size(100, 20)
        Me.txtcodigo.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "NOMBRE"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CODIGO"
        '
        'FrmCentroCostos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(592, 261)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbnumero)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.lbestado)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCentroCostos"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Centro de Costos"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbnumero As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents lbestado As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
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
    Friend WithEvents txtnombre As System.Windows.Forms.TextBox
    Friend WithEvents txtcodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtpre As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbexiste As System.Windows.Forms.Label
    Friend WithEvents lbnivel As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chnivel As System.Windows.Forms.CheckBox
End Class
