<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImpuestos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImpuestos))
        Me.lbnroobs = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.lbestado = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cbTipoAsi = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCuenta = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPorcentaje = New System.Windows.Forms.TextBox
        Me.txtDescripcion = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtDescriGral = New System.Windows.Forms.TextBox
        Me.TxtCodGral = New System.Windows.Forms.TextBox
        Me.lbcodigo = New System.Windows.Forms.Label
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
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbnroobs
        '
        Me.lbnroobs.AutoSize = True
        Me.lbnroobs.BackColor = System.Drawing.Color.Transparent
        Me.lbnroobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnroobs.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbnroobs.Location = New System.Drawing.Point(605, 299)
        Me.lbnroobs.Name = "lbnroobs"
        Me.lbnroobs.Size = New System.Drawing.Size(35, 13)
        Me.lbnroobs.TabIndex = 84
        Me.lbnroobs.Text = "0000"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label38.Location = New System.Drawing.Point(522, 298)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(82, 13)
        Me.Label38.TabIndex = 83
        Me.Label38.Text = "Registro Nro."
        '
        'lbestado
        '
        Me.lbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbestado.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbestado.Location = New System.Drawing.Point(14, 299)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(108, 22)
        Me.lbestado.TabIndex = 82
        Me.lbestado.Text = "NULO"
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
        Me.GroupBox1.Location = New System.Drawing.Point(9, 239)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(656, 56)
        Me.GroupBox1.TabIndex = 81
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbcodigo)
        Me.GroupBox2.Controls.Add(Me.cbTipoAsi)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtCuenta)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtPorcentaje)
        Me.GroupBox2.Controls.Add(Me.txtDescripcion)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtCodigo)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtDescriGral)
        Me.GroupBox2.Controls.Add(Me.TxtCodGral)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(656, 233)
        Me.GroupBox2.TabIndex = 85
        Me.GroupBox2.TabStop = False
        '
        'cbTipoAsi
        '
        Me.cbTipoAsi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoAsi.FormattingEnabled = True
        Me.cbTipoAsi.Items.AddRange(New Object() {"D", "C"})
        Me.cbTipoAsi.Location = New System.Drawing.Point(487, 197)
        Me.cbTipoAsi.Name = "cbTipoAsi"
        Me.cbTipoAsi.Size = New System.Drawing.Size(50, 21)
        Me.cbTipoAsi.TabIndex = 64
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(323, 198)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(158, 16)
        Me.Label5.TabIndex = 63
        Me.Label5.Text = "Tipo de Asiento (D/C)"
        '
        'txtCuenta
        '
        Me.txtCuenta.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtCuenta.Location = New System.Drawing.Point(178, 197)
        Me.txtCuenta.MaxLength = 50
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(119, 20)
        Me.txtCuenta.TabIndex = 62
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 201)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 16)
        Me.Label4.TabIndex = 61
        Me.Label4.Text = "Cuenta Auxiliar"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 164)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 16)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Porcentaje (%)"
        '
        'txtPorcentaje
        '
        Me.txtPorcentaje.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtPorcentaje.Location = New System.Drawing.Point(178, 163)
        Me.txtPorcentaje.MaxLength = 10
        Me.txtPorcentaje.Name = "txtPorcentaje"
        Me.txtPorcentaje.Size = New System.Drawing.Size(70, 20)
        Me.txtPorcentaje.TabIndex = 59
        Me.txtPorcentaje.Text = "0,000"
        Me.txtPorcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(178, 107)
        Me.txtDescripcion.MaxLength = 500
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(444, 47)
        Me.txtDescripcion.TabIndex = 58
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 16)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Descripción"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigo.Location = New System.Drawing.Point(178, 78)
        Me.txtCodigo.MaxLength = 4
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(45, 20)
        Me.txtCodigo.TabIndex = 56
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 16)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Código"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(133, 16)
        Me.Label10.TabIndex = 54
        Me.Label10.Text = "Concepto General"
        '
        'txtDescriGral
        '
        Me.txtDescriGral.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtDescriGral.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescriGral.Location = New System.Drawing.Point(178, 48)
        Me.txtDescriGral.MaxLength = 50
        Me.txtDescriGral.Name = "txtDescriGral"
        Me.txtDescriGral.Size = New System.Drawing.Size(444, 20)
        Me.txtDescriGral.TabIndex = 53
        '
        'TxtCodGral
        '
        Me.TxtCodGral.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TxtCodGral.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCodGral.Location = New System.Drawing.Point(178, 19)
        Me.TxtCodGral.MaxLength = 4
        Me.TxtCodGral.Name = "TxtCodGral"
        Me.TxtCodGral.Size = New System.Drawing.Size(45, 20)
        Me.TxtCodGral.TabIndex = 52
        '
        'lbcodigo
        '
        Me.lbcodigo.AutoSize = True
        Me.lbcodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcodigo.Location = New System.Drawing.Point(262, 82)
        Me.lbcodigo.Name = "lbcodigo"
        Me.lbcodigo.Size = New System.Drawing.Size(107, 16)
        Me.lbcodigo.TabIndex = 65
        Me.lbcodigo.Text = "codigo interno"
        Me.lbcodigo.Visible = False
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
        'FrmImpuestos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(680, 326)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lbnroobs)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.lbestado)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmImpuestos"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE  Impuestos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbnroobs As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents lbestado As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdEliminar As System.Windows.Forms.Button
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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPorcentaje As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDescriGral As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodGral As System.Windows.Forms.TextBox
    Friend WithEvents txtCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbTipoAsi As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbcodigo As System.Windows.Forms.Label
End Class
