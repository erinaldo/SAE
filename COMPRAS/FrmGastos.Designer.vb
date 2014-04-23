<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGastos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGastos))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtiva = New System.Windows.Forms.TextBox
        Me.txtniva = New System.Windows.Forms.TextBox
        Me.txtngas = New System.Windows.Forms.TextBox
        Me.txtctagas = New System.Windows.Forms.TextBox
        Me.txtctaiva = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtcod = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtnombre = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtdescrip = New System.Windows.Forms.TextBox
        Me.cmdNuevo = New System.Windows.Forms.Button
        Me.CmdMostrar = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CmdPrimero = New System.Windows.Forms.Button
        Me.CmdCancelar = New System.Windows.Forms.Button
        Me.CmdSalir = New System.Windows.Forms.Button
        Me.CmdEliminar = New System.Windows.Forms.Button
        Me.CmdUltimo = New System.Windows.Forms.Button
        Me.CmdEditar = New System.Windows.Forms.Button
        Me.CmdListo = New System.Windows.Forms.Button
        Me.CmdSiguiente = New System.Windows.Forms.Button
        Me.CmdAtras = New System.Windows.Forms.Button
        Me.lbnumero = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbestado = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtiva)
        Me.GroupBox2.Controls.Add(Me.txtniva)
        Me.GroupBox2.Controls.Add(Me.txtngas)
        Me.GroupBox2.Controls.Add(Me.txtctagas)
        Me.GroupBox2.Controls.Add(Me.txtctaiva)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtcod)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtnombre)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtdescrip)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 86)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(645, 234)
        Me.GroupBox2.TabIndex = 116
        Me.GroupBox2.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(26, 146)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 16)
        Me.Label7.TabIndex = 127
        Me.Label7.Text = "IVA %"
        '
        'txtiva
        '
        Me.txtiva.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtiva.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtiva.Location = New System.Drawing.Point(171, 143)
        Me.txtiva.MaxLength = 5
        Me.txtiva.Name = "txtiva"
        Me.txtiva.ShortcutsEnabled = False
        Me.txtiva.Size = New System.Drawing.Size(55, 21)
        Me.txtiva.TabIndex = 4
        Me.txtiva.Text = "0,00"
        Me.txtiva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtniva
        '
        Me.txtniva.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtniva.Enabled = False
        Me.txtniva.Location = New System.Drawing.Point(298, 170)
        Me.txtniva.Name = "txtniva"
        Me.txtniva.ReadOnly = True
        Me.txtniva.Size = New System.Drawing.Size(264, 20)
        Me.txtniva.TabIndex = 7
        '
        'txtngas
        '
        Me.txtngas.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtngas.Enabled = False
        Me.txtngas.Location = New System.Drawing.Point(298, 198)
        Me.txtngas.Name = "txtngas"
        Me.txtngas.ReadOnly = True
        Me.txtngas.Size = New System.Drawing.Size(264, 20)
        Me.txtngas.TabIndex = 8
        '
        'txtctagas
        '
        Me.txtctagas.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtctagas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtctagas.Location = New System.Drawing.Point(171, 196)
        Me.txtctagas.MaxLength = 15
        Me.txtctagas.Name = "txtctagas"
        Me.txtctagas.ShortcutsEnabled = False
        Me.txtctagas.Size = New System.Drawing.Size(121, 21)
        Me.txtctagas.TabIndex = 6
        '
        'txtctaiva
        '
        Me.txtctaiva.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtctaiva.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtctaiva.Location = New System.Drawing.Point(171, 168)
        Me.txtctaiva.MaxLength = 15
        Me.txtctaiva.Name = "txtctaiva"
        Me.txtctaiva.ShortcutsEnabled = False
        Me.txtctaiva.Size = New System.Drawing.Size(121, 21)
        Me.txtctaiva.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(26, 196)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 16)
        Me.Label6.TabIndex = 121
        Me.Label6.Text = "Cuenta Gastos"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(26, 171)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 16)
        Me.Label4.TabIndex = 120
        Me.Label4.Text = "Cuenta IVA"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 16)
        Me.Label1.TabIndex = 117
        Me.Label1.Text = "Codigo del Gasto"
        '
        'txtcod
        '
        Me.txtcod.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcod.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcod.Location = New System.Drawing.Point(171, 19)
        Me.txtcod.MaxLength = 15
        Me.txtcod.Name = "txtcod"
        Me.txtcod.ShortcutsEnabled = False
        Me.txtcod.Size = New System.Drawing.Size(121, 21)
        Me.txtcod.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(25, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 16)
        Me.Label3.TabIndex = 108
        Me.Label3.Text = "Nombre del Gasto"
        '
        'txtnombre
        '
        Me.txtnombre.BackColor = System.Drawing.Color.White
        Me.txtnombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnombre.Location = New System.Drawing.Point(171, 46)
        Me.txtnombre.MaxLength = 80
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.ShortcutsEnabled = False
        Me.txtnombre.Size = New System.Drawing.Size(391, 21)
        Me.txtnombre.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(25, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 16)
        Me.Label5.TabIndex = 97
        Me.Label5.Text = "Descripción"
        '
        'txtdescrip
        '
        Me.txtdescrip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdescrip.Location = New System.Drawing.Point(171, 73)
        Me.txtdescrip.MaxLength = 50
        Me.txtdescrip.Multiline = True
        Me.txtdescrip.Name = "txtdescrip"
        Me.txtdescrip.ShortcutsEnabled = False
        Me.txtdescrip.Size = New System.Drawing.Size(391, 63)
        Me.txtdescrip.TabIndex = 2
        '
        'cmdNuevo
        '
        Me.cmdNuevo.Image = Global.SAE.My.Resources.Resources.nuevo
        Me.cmdNuevo.Location = New System.Drawing.Point(16, 12)
        Me.cmdNuevo.Name = "cmdNuevo"
        Me.cmdNuevo.Size = New System.Drawing.Size(52, 38)
        Me.cmdNuevo.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.cmdNuevo, "nuevo")
        Me.cmdNuevo.UseVisualStyleBackColor = True
        '
        'CmdMostrar
        '
        Me.CmdMostrar.Enabled = False
        Me.CmdMostrar.Image = Global.SAE.My.Resources.Resources.DataTables
        Me.CmdMostrar.Location = New System.Drawing.Point(280, 12)
        Me.CmdMostrar.Name = "CmdMostrar"
        Me.CmdMostrar.Size = New System.Drawing.Size(52, 38)
        Me.CmdMostrar.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.CmdMostrar, "buscar")
        Me.CmdMostrar.UseVisualStyleBackColor = True
        '
        'CmdPrimero
        '
        Me.CmdPrimero.Image = CType(resources.GetObject("CmdPrimero.Image"), System.Drawing.Image)
        Me.CmdPrimero.Location = New System.Drawing.Point(419, 12)
        Me.CmdPrimero.Name = "CmdPrimero"
        Me.CmdPrimero.Size = New System.Drawing.Size(52, 38)
        Me.CmdPrimero.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.CmdPrimero, "primero")
        Me.CmdPrimero.UseVisualStyleBackColor = True
        '
        'CmdCancelar
        '
        Me.CmdCancelar.Image = Global.SAE.My.Resources.Resources.cancelar
        Me.CmdCancelar.Location = New System.Drawing.Point(121, 12)
        Me.CmdCancelar.Name = "CmdCancelar"
        Me.CmdCancelar.Size = New System.Drawing.Size(52, 38)
        Me.CmdCancelar.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.CmdCancelar, "cancelar")
        Me.CmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdSalir
        '
        Me.CmdSalir.Image = Global.SAE.My.Resources.Resources.salir
        Me.CmdSalir.Location = New System.Drawing.Point(333, 12)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(52, 38)
        Me.CmdSalir.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.CmdSalir, "salir")
        Me.CmdSalir.UseVisualStyleBackColor = True
        '
        'CmdEliminar
        '
        Me.CmdEliminar.Enabled = False
        Me.CmdEliminar.Image = Global.SAE.My.Resources.Resources.eliminar
        Me.CmdEliminar.Location = New System.Drawing.Point(227, 12)
        Me.CmdEliminar.Name = "CmdEliminar"
        Me.CmdEliminar.Size = New System.Drawing.Size(52, 38)
        Me.CmdEliminar.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.CmdEliminar, "eliminar")
        Me.CmdEliminar.UseVisualStyleBackColor = True
        '
        'CmdUltimo
        '
        Me.CmdUltimo.Image = CType(resources.GetObject("CmdUltimo.Image"), System.Drawing.Image)
        Me.CmdUltimo.Location = New System.Drawing.Point(572, 12)
        Me.CmdUltimo.Name = "CmdUltimo"
        Me.CmdUltimo.Size = New System.Drawing.Size(52, 38)
        Me.CmdUltimo.TabIndex = 15
        Me.ToolTip1.SetToolTip(Me.CmdUltimo, "ultimo")
        Me.CmdUltimo.UseVisualStyleBackColor = True
        '
        'CmdEditar
        '
        Me.CmdEditar.Image = Global.SAE.My.Resources.Resources.editar
        Me.CmdEditar.Location = New System.Drawing.Point(174, 12)
        Me.CmdEditar.Name = "CmdEditar"
        Me.CmdEditar.Size = New System.Drawing.Size(52, 38)
        Me.CmdEditar.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.CmdEditar, "modificar")
        Me.CmdEditar.UseVisualStyleBackColor = True
        '
        'CmdListo
        '
        Me.CmdListo.Image = Global.SAE.My.Resources.Resources.guardar
        Me.CmdListo.Location = New System.Drawing.Point(68, 12)
        Me.CmdListo.Name = "CmdListo"
        Me.CmdListo.Size = New System.Drawing.Size(52, 38)
        Me.CmdListo.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.CmdListo, "guardar")
        Me.CmdListo.UseVisualStyleBackColor = True
        '
        'CmdSiguiente
        '
        Me.CmdSiguiente.Image = CType(resources.GetObject("CmdSiguiente.Image"), System.Drawing.Image)
        Me.CmdSiguiente.Location = New System.Drawing.Point(521, 12)
        Me.CmdSiguiente.Name = "CmdSiguiente"
        Me.CmdSiguiente.Size = New System.Drawing.Size(52, 38)
        Me.CmdSiguiente.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.CmdSiguiente, "siguiente")
        Me.CmdSiguiente.UseVisualStyleBackColor = True
        '
        'CmdAtras
        '
        Me.CmdAtras.Image = CType(resources.GetObject("CmdAtras.Image"), System.Drawing.Image)
        Me.CmdAtras.Location = New System.Drawing.Point(470, 12)
        Me.CmdAtras.Name = "CmdAtras"
        Me.CmdAtras.Size = New System.Drawing.Size(52, 38)
        Me.CmdAtras.TabIndex = 13
        Me.CmdAtras.Text = " "
        Me.ToolTip1.SetToolTip(Me.CmdAtras, "anterior")
        Me.CmdAtras.UseVisualStyleBackColor = True
        '
        'lbnumero
        '
        Me.lbnumero.AutoSize = True
        Me.lbnumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnumero.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbnumero.Location = New System.Drawing.Point(604, 5)
        Me.lbnumero.Name = "lbnumero"
        Me.lbnumero.Size = New System.Drawing.Size(35, 13)
        Me.lbnumero.TabIndex = 118
        Me.lbnumero.Text = "0000"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label18.Location = New System.Drawing.Point(520, 5)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 13)
        Me.Label18.TabIndex = 117
        Me.Label18.Text = "Registro Nro."
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox1.Controls.Add(Me.CmdUltimo)
        Me.GroupBox1.Controls.Add(Me.CmdEditar)
        Me.GroupBox1.Controls.Add(Me.CmdListo)
        Me.GroupBox1.Controls.Add(Me.CmdSiguiente)
        Me.GroupBox1.Controls.Add(Me.CmdAtras)
        Me.GroupBox1.Controls.Add(Me.CmdSalir)
        Me.GroupBox1.Controls.Add(Me.CmdCancelar)
        Me.GroupBox1.Controls.Add(Me.CmdPrimero)
        Me.GroupBox1.Controls.Add(Me.CmdEliminar)
        Me.GroupBox1.Controls.Add(Me.CmdMostrar)
        Me.GroupBox1.Controls.Add(Me.cmdNuevo)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(645, 56)
        Me.GroupBox1.TabIndex = 115
        Me.GroupBox1.TabStop = False
        '
        'lbestado
        '
        Me.lbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbestado.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbestado.Location = New System.Drawing.Point(6, 4)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(211, 22)
        Me.lbestado.TabIndex = 119
        Me.lbestado.Text = "NULO"
        '
        'FrmGastos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(661, 328)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lbnumero)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbestado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmGastos"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Gastos"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtiva As System.Windows.Forms.TextBox
    Friend WithEvents txtniva As System.Windows.Forms.TextBox
    Friend WithEvents txtngas As System.Windows.Forms.TextBox
    Friend WithEvents txtctagas As System.Windows.Forms.TextBox
    Friend WithEvents txtctaiva As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtcod As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtnombre As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtdescrip As System.Windows.Forms.TextBox
    Friend WithEvents cmdNuevo As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents CmdMostrar As System.Windows.Forms.Button
    Friend WithEvents CmdPrimero As System.Windows.Forms.Button
    Friend WithEvents CmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents CmdEliminar As System.Windows.Forms.Button
    Friend WithEvents CmdUltimo As System.Windows.Forms.Button
    Friend WithEvents CmdEditar As System.Windows.Forms.Button
    Friend WithEvents CmdListo As System.Windows.Forms.Button
    Friend WithEvents CmdSiguiente As System.Windows.Forms.Button
    Friend WithEvents CmdAtras As System.Windows.Forms.Button
    Friend WithEvents lbnumero As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbestado As System.Windows.Forms.Label
End Class
