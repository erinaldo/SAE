<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMetasxArea
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMetasxArea))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BusArea = New System.Windows.Forms.Button
        Me.txtf2 = New System.Windows.Forms.DateTimePicker
        Me.txtf1 = New System.Windows.Forms.DateTimePicker
        Me.txtvalor = New System.Windows.Forms.TextBox
        Me.txttope = New System.Windows.Forms.TextBox
        Me.txtarea = New System.Windows.Forms.TextBox
        Me.txtcod = New System.Windows.Forms.TextBox
        Me.cbrango = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbcom = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbestado = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CmdEditar = New System.Windows.Forms.Button
        Me.CmdListo = New System.Windows.Forms.Button
        Me.CmdSalir = New System.Windows.Forms.Button
        Me.CmdCancelar = New System.Windows.Forms.Button
        Me.CmdEliminar = New System.Windows.Forms.Button
        Me.CmdMostrar = New System.Windows.Forms.Button
        Me.cmdNuevo = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BusArea)
        Me.GroupBox1.Controls.Add(Me.txtf2)
        Me.GroupBox1.Controls.Add(Me.txtf1)
        Me.GroupBox1.Controls.Add(Me.txtvalor)
        Me.GroupBox1.Controls.Add(Me.txttope)
        Me.GroupBox1.Controls.Add(Me.txtarea)
        Me.GroupBox1.Controls.Add(Me.txtcod)
        Me.GroupBox1.Controls.Add(Me.cbrango)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cbcom)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(412, 239)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'BusArea
        '
        Me.BusArea.Location = New System.Drawing.Point(321, 46)
        Me.BusArea.Name = "BusArea"
        Me.BusArea.Size = New System.Drawing.Size(75, 23)
        Me.BusArea.TabIndex = 2
        Me.BusArea.Text = "Buscar"
        Me.BusArea.UseVisualStyleBackColor = True
        '
        'txtf2
        '
        Me.txtf2.CustomFormat = "yyyy/dd/mm"
        Me.txtf2.Location = New System.Drawing.Point(115, 179)
        Me.txtf2.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.txtf2.Name = "txtf2"
        Me.txtf2.Size = New System.Drawing.Size(205, 20)
        Me.txtf2.TabIndex = 7
        Me.txtf2.Value = New Date(2010, 1, 14, 0, 0, 0, 0)
        '
        'txtf1
        '
        Me.txtf1.CustomFormat = "yyyy/dd/mm"
        Me.txtf1.Location = New System.Drawing.Point(115, 150)
        Me.txtf1.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.txtf1.Name = "txtf1"
        Me.txtf1.Size = New System.Drawing.Size(205, 20)
        Me.txtf1.TabIndex = 6
        Me.txtf1.Value = New Date(2010, 1, 14, 0, 0, 0, 0)
        '
        'txtvalor
        '
        Me.txtvalor.Location = New System.Drawing.Point(231, 111)
        Me.txtvalor.Name = "txtvalor"
        Me.txtvalor.Size = New System.Drawing.Size(143, 20)
        Me.txtvalor.TabIndex = 5
        '
        'txttope
        '
        Me.txttope.Location = New System.Drawing.Point(125, 72)
        Me.txttope.Name = "txttope"
        Me.txttope.Size = New System.Drawing.Size(181, 20)
        Me.txttope.TabIndex = 3
        '
        'txtarea
        '
        Me.txtarea.BackColor = System.Drawing.Color.White
        Me.txtarea.Location = New System.Drawing.Point(125, 46)
        Me.txtarea.Name = "txtarea"
        Me.txtarea.ReadOnly = True
        Me.txtarea.Size = New System.Drawing.Size(181, 20)
        Me.txtarea.TabIndex = 1
        '
        'txtcod
        '
        Me.txtcod.Location = New System.Drawing.Point(125, 19)
        Me.txtcod.Name = "txtcod"
        Me.txtcod.Size = New System.Drawing.Size(181, 20)
        Me.txtcod.TabIndex = 0
        '
        'cbrango
        '
        Me.cbrango.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbrango.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbrango.FormattingEnabled = True
        Me.cbrango.Items.AddRange(New Object() {"FECHAS", "MENSUAL"})
        Me.cbrango.Location = New System.Drawing.Point(115, 210)
        Me.cbrango.Name = "cbrango"
        Me.cbrango.Size = New System.Drawing.Size(129, 21)
        Me.cbrango.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(7, 213)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 15)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Rango a evaluar"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 182)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 15)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Fecha Final"
        '
        'cbcom
        '
        Me.cbcom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbcom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbcom.FormattingEnabled = True
        Me.cbcom.Items.AddRange(New Object() {"PORCENTAJE", "VALOR FIJO"})
        Me.cbcom.Location = New System.Drawing.Point(115, 108)
        Me.cbcom.Name = "cbcom"
        Me.cbcom.Size = New System.Drawing.Size(110, 21)
        Me.cbcom.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 15)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Tipo de Comision"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 150)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 15)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Fecha Inicial"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Tope de la Meta $"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Area"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo"
        '
        'lbestado
        '
        Me.lbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbestado.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbestado.Location = New System.Drawing.Point(9, 6)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(153, 22)
        Me.lbestado.TabIndex = 60
        Me.lbestado.Text = "NULO"
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
        Me.GroupBox2.Location = New System.Drawing.Point(6, 266)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(414, 56)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'CmdEditar
        '
        Me.CmdEditar.Image = Global.SAE.My.Resources.Resources.editar
        Me.CmdEditar.Location = New System.Drawing.Point(174, 12)
        Me.CmdEditar.Name = "CmdEditar"
        Me.CmdEditar.Size = New System.Drawing.Size(52, 38)
        Me.CmdEditar.TabIndex = 4
        Me.CmdEditar.UseVisualStyleBackColor = True
        '
        'CmdListo
        '
        Me.CmdListo.Image = Global.SAE.My.Resources.Resources.guardar
        Me.CmdListo.Location = New System.Drawing.Point(68, 12)
        Me.CmdListo.Name = "CmdListo"
        Me.CmdListo.Size = New System.Drawing.Size(52, 38)
        Me.CmdListo.TabIndex = 2
        Me.CmdListo.UseVisualStyleBackColor = True
        '
        'CmdSalir
        '
        Me.CmdSalir.Image = Global.SAE.My.Resources.Resources.salir
        Me.CmdSalir.Location = New System.Drawing.Point(333, 12)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(52, 38)
        Me.CmdSalir.TabIndex = 7
        Me.CmdSalir.UseVisualStyleBackColor = True
        '
        'CmdCancelar
        '
        Me.CmdCancelar.Image = Global.SAE.My.Resources.Resources.cancelar
        Me.CmdCancelar.Location = New System.Drawing.Point(121, 12)
        Me.CmdCancelar.Name = "CmdCancelar"
        Me.CmdCancelar.Size = New System.Drawing.Size(52, 38)
        Me.CmdCancelar.TabIndex = 3
        Me.CmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdEliminar
        '
        Me.CmdEliminar.Enabled = False
        Me.CmdEliminar.Image = Global.SAE.My.Resources.Resources.eliminar
        Me.CmdEliminar.Location = New System.Drawing.Point(227, 12)
        Me.CmdEliminar.Name = "CmdEliminar"
        Me.CmdEliminar.Size = New System.Drawing.Size(52, 38)
        Me.CmdEliminar.TabIndex = 5
        Me.CmdEliminar.UseVisualStyleBackColor = True
        '
        'CmdMostrar
        '
        Me.CmdMostrar.Enabled = False
        Me.CmdMostrar.Image = Global.SAE.My.Resources.Resources.DataTables
        Me.CmdMostrar.Location = New System.Drawing.Point(280, 12)
        Me.CmdMostrar.Name = "CmdMostrar"
        Me.CmdMostrar.Size = New System.Drawing.Size(52, 38)
        Me.CmdMostrar.TabIndex = 6
        Me.CmdMostrar.UseVisualStyleBackColor = True
        '
        'cmdNuevo
        '
        Me.cmdNuevo.Image = Global.SAE.My.Resources.Resources.nuevo
        Me.cmdNuevo.Location = New System.Drawing.Point(16, 12)
        Me.cmdNuevo.Name = "cmdNuevo"
        Me.cmdNuevo.Size = New System.Drawing.Size(52, 38)
        Me.cmdNuevo.TabIndex = 1
        Me.cmdNuevo.UseVisualStyleBackColor = True
        '
        'FrmMetasxArea
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(428, 327)
        Me.Controls.Add(Me.lbestado)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMetasxArea"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Metas por Areas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbrango As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbcom As System.Windows.Forms.ComboBox
    Friend WithEvents lbestado As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdEditar As System.Windows.Forms.Button
    Friend WithEvents CmdListo As System.Windows.Forms.Button
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents CmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdEliminar As System.Windows.Forms.Button
    Friend WithEvents CmdMostrar As System.Windows.Forms.Button
    Friend WithEvents cmdNuevo As System.Windows.Forms.Button
    Friend WithEvents txtvalor As System.Windows.Forms.TextBox
    Friend WithEvents txttope As System.Windows.Forms.TextBox
    Friend WithEvents txtarea As System.Windows.Forms.TextBox
    Friend WithEvents txtcod As System.Windows.Forms.TextBox
    Friend WithEvents txtf2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtf1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents BusArea As System.Windows.Forms.Button
End Class
