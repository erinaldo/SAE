<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGestionCitas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGestionCitas))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txthora = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtestado = New System.Windows.Forms.ComboBox
        Me.txtnoma = New System.Windows.Forms.TextBox
        Me.txtnita = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtnomc = New System.Windows.Forms.TextBox
        Me.lbnov1 = New System.Windows.Forms.Label
        Me.txtnitc = New System.Windows.Forms.TextBox
        Me.Lbnov = New System.Windows.Forms.Label
        Me.txtnomv = New System.Windows.Forms.TextBox
        Me.lbestado = New System.Windows.Forms.Label
        Me.txtnitv = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtobs = New System.Windows.Forms.TextBox
        Me.txtserv = New System.Windows.Forms.TextBox
        Me.txtf1 = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbnroobs = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CmdEliminar = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdProc = New System.Windows.Forms.Button
        Me.cmdNuevo = New System.Windows.Forms.Button
        Me.CmdMostrar = New System.Windows.Forms.Button
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdguardar = New System.Windows.Forms.Button
        Me.cmdmodificar = New System.Windows.Forms.Button
        Me.cmdcancelar = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txthora)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtestado)
        Me.GroupBox1.Controls.Add(Me.txtnoma)
        Me.GroupBox1.Controls.Add(Me.txtnita)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtnomc)
        Me.GroupBox1.Controls.Add(Me.lbnov1)
        Me.GroupBox1.Controls.Add(Me.txtnitc)
        Me.GroupBox1.Controls.Add(Me.Lbnov)
        Me.GroupBox1.Controls.Add(Me.txtnomv)
        Me.GroupBox1.Controls.Add(Me.lbestado)
        Me.GroupBox1.Controls.Add(Me.txtnitv)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtobs)
        Me.GroupBox1.Controls.Add(Me.txtserv)
        Me.GroupBox1.Controls.Add(Me.txtf1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(502, 313)
        Me.GroupBox1.TabIndex = 95
        Me.GroupBox1.TabStop = False
        '
        'txthora
        '
        Me.txthora.Location = New System.Drawing.Point(420, 156)
        Me.txthora.Name = "txthora"
        Me.txthora.Size = New System.Drawing.Size(66, 20)
        Me.txthora.TabIndex = 86
        Me.txthora.Text = "00:00:00"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Maroon
        Me.Label9.Location = New System.Drawing.Point(98, 141)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(156, 13)
        Me.Label9.TabIndex = 85
        Me.Label9.Text = "*** Enter para Seleccionar"
        Me.Label9.Visible = False
        '
        'txtestado
        '
        Me.txtestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtestado.FormattingEnabled = True
        Me.txtestado.Items.AddRange(New Object() {"PENDIENTE", "CUMPLIDO", "CANCELADO"})
        Me.txtestado.Location = New System.Drawing.Point(101, 285)
        Me.txtestado.Name = "txtestado"
        Me.txtestado.Size = New System.Drawing.Size(123, 21)
        Me.txtestado.TabIndex = 10
        '
        'txtnoma
        '
        Me.txtnoma.Enabled = False
        Me.txtnoma.Location = New System.Drawing.Point(203, 69)
        Me.txtnoma.Name = "txtnoma"
        Me.txtnoma.Size = New System.Drawing.Size(283, 20)
        Me.txtnoma.TabIndex = 4
        '
        'txtnita
        '
        Me.txtnita.BackColor = System.Drawing.Color.White
        Me.txtnita.Enabled = False
        Me.txtnita.Location = New System.Drawing.Point(101, 69)
        Me.txtnita.Name = "txtnita"
        Me.txtnita.ReadOnly = True
        Me.txtnita.Size = New System.Drawing.Size(96, 20)
        Me.txtnita.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 15)
        Me.Label8.TabIndex = 84
        Me.Label8.Text = "Asesor"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(380, 159)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 15)
        Me.Label7.TabIndex = 83
        Me.Label7.Text = "Hora"
        '
        'txtnomc
        '
        Me.txtnomc.Enabled = False
        Me.txtnomc.Location = New System.Drawing.Point(203, 42)
        Me.txtnomc.Name = "txtnomc"
        Me.txtnomc.Size = New System.Drawing.Size(283, 20)
        Me.txtnomc.TabIndex = 2
        '
        'lbnov1
        '
        Me.lbnov1.AutoSize = True
        Me.lbnov1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnov1.Location = New System.Drawing.Point(5, 16)
        Me.lbnov1.Name = "lbnov1"
        Me.lbnov1.Size = New System.Drawing.Size(55, 13)
        Me.lbnov1.TabIndex = 78
        Me.lbnov1.Text = "CITA No"
        '
        'txtnitc
        '
        Me.txtnitc.BackColor = System.Drawing.Color.White
        Me.txtnitc.Enabled = False
        Me.txtnitc.Location = New System.Drawing.Point(101, 42)
        Me.txtnitc.Name = "txtnitc"
        Me.txtnitc.Size = New System.Drawing.Size(96, 20)
        Me.txtnitc.TabIndex = 1
        '
        'Lbnov
        '
        Me.Lbnov.AutoSize = True
        Me.Lbnov.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbnov.Location = New System.Drawing.Point(58, 16)
        Me.Lbnov.Name = "Lbnov"
        Me.Lbnov.Size = New System.Drawing.Size(45, 13)
        Me.Lbnov.TabIndex = 81
        Me.Lbnov.Text = "Label7"
        '
        'txtnomv
        '
        Me.txtnomv.Enabled = False
        Me.txtnomv.Location = New System.Drawing.Point(203, 254)
        Me.txtnomv.Name = "txtnomv"
        Me.txtnomv.Size = New System.Drawing.Size(283, 20)
        Me.txtnomv.TabIndex = 5
        '
        'lbestado
        '
        Me.lbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbestado.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbestado.Location = New System.Drawing.Point(384, 11)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(90, 22)
        Me.lbestado.TabIndex = 75
        Me.lbestado.Text = "NULO"
        Me.lbestado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtnitv
        '
        Me.txtnitv.BackColor = System.Drawing.Color.White
        Me.txtnitv.Location = New System.Drawing.Point(101, 254)
        Me.txtnitv.Name = "txtnitv"
        Me.txtnitv.Size = New System.Drawing.Size(96, 20)
        Me.txtnitv.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 254)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 15)
        Me.Label6.TabIndex = 80
        Me.Label6.Text = "Registrado Por"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 287)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 15)
        Me.Label5.TabIndex = 77
        Me.Label5.Text = "Estado"
        '
        'txtobs
        '
        Me.txtobs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtobs.Location = New System.Drawing.Point(101, 189)
        Me.txtobs.Multiline = True
        Me.txtobs.Name = "txtobs"
        Me.txtobs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtobs.Size = New System.Drawing.Size(385, 59)
        Me.txtobs.TabIndex = 8
        '
        'txtserv
        '
        Me.txtserv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtserv.Location = New System.Drawing.Point(101, 99)
        Me.txtserv.Multiline = True
        Me.txtserv.Name = "txtserv"
        Me.txtserv.Size = New System.Drawing.Size(385, 39)
        Me.txtserv.TabIndex = 5
        '
        'txtf1
        '
        Me.txtf1.CustomFormat = "yyyy/dd/mm"
        Me.txtf1.Location = New System.Drawing.Point(101, 159)
        Me.txtf1.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.txtf1.Name = "txtf1"
        Me.txtf1.Size = New System.Drawing.Size(213, 20)
        Me.txtf1.TabIndex = 6
        Me.txtf1.Value = New Date(2010, 1, 14, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 189)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 15)
        Me.Label4.TabIndex = 76
        Me.Label4.Text = "Observacion"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 15)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "Cliente"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 15)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "Servicio"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 159)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha"
        '
        'lbnroobs
        '
        Me.lbnroobs.AutoSize = True
        Me.lbnroobs.BackColor = System.Drawing.Color.Transparent
        Me.lbnroobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnroobs.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbnroobs.Location = New System.Drawing.Point(95, 6)
        Me.lbnroobs.Name = "lbnroobs"
        Me.lbnroobs.Size = New System.Drawing.Size(35, 13)
        Me.lbnroobs.TabIndex = 97
        Me.lbnroobs.Text = "0000"
        Me.lbnroobs.Visible = False
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label38.Location = New System.Drawing.Point(15, 6)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(82, 13)
        Me.Label38.TabIndex = 96
        Me.Label38.Text = "Registro Nro."
        Me.Label38.Visible = False
        '
        'CmdEliminar
        '
        Me.CmdEliminar.Image = Global.SAE.My.Resources.Resources.eliminar
        Me.CmdEliminar.Location = New System.Drawing.Point(226, 12)
        Me.CmdEliminar.Name = "CmdEliminar"
        Me.CmdEliminar.Size = New System.Drawing.Size(52, 38)
        Me.CmdEliminar.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.CmdEliminar, "Eliminar")
        Me.CmdEliminar.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdPrint.Image = Global.SAE.My.Resources.Resources.impr
        Me.cmdPrint.Location = New System.Drawing.Point(390, 13)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(52, 38)
        Me.cmdPrint.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.cmdPrint, "Generar PDF")
        Me.cmdPrint.UseVisualStyleBackColor = False
        '
        'cmdProc
        '
        Me.cmdProc.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdProc.Image = Global.SAE.My.Resources.Resources.ok
        Me.cmdProc.Location = New System.Drawing.Point(332, 12)
        Me.cmdProc.Name = "cmdProc"
        Me.cmdProc.Size = New System.Drawing.Size(57, 38)
        Me.cmdProc.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.cmdProc, "Aplicar Procedimiento")
        Me.cmdProc.UseVisualStyleBackColor = False
        '
        'cmdNuevo
        '
        Me.cmdNuevo.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdNuevo.Image = Global.SAE.My.Resources.Resources.nuevo
        Me.cmdNuevo.Location = New System.Drawing.Point(10, 12)
        Me.cmdNuevo.Name = "cmdNuevo"
        Me.cmdNuevo.Size = New System.Drawing.Size(52, 38)
        Me.cmdNuevo.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.cmdNuevo, "Nuevo")
        Me.cmdNuevo.UseVisualStyleBackColor = False
        '
        'CmdMostrar
        '
        Me.CmdMostrar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.CmdMostrar.Image = Global.SAE.My.Resources.Resources.DataTables
        Me.CmdMostrar.Location = New System.Drawing.Point(279, 12)
        Me.CmdMostrar.Name = "CmdMostrar"
        Me.CmdMostrar.Size = New System.Drawing.Size(52, 38)
        Me.CmdMostrar.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.CmdMostrar, "Mostrar")
        Me.CmdMostrar.UseVisualStyleBackColor = False
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.salir
        Me.cmdsalir.Location = New System.Drawing.Point(443, 13)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(52, 38)
        Me.cmdsalir.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.cmdsalir, "Salir")
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'cmdguardar
        '
        Me.cmdguardar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdguardar.Image = Global.SAE.My.Resources.Resources.guardar
        Me.cmdguardar.Location = New System.Drawing.Point(63, 12)
        Me.cmdguardar.Name = "cmdguardar"
        Me.cmdguardar.Size = New System.Drawing.Size(52, 38)
        Me.cmdguardar.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.cmdguardar, "Guardar")
        Me.cmdguardar.UseVisualStyleBackColor = False
        '
        'cmdmodificar
        '
        Me.cmdmodificar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdmodificar.Image = Global.SAE.My.Resources.Resources.editar
        Me.cmdmodificar.Location = New System.Drawing.Point(172, 12)
        Me.cmdmodificar.Name = "cmdmodificar"
        Me.cmdmodificar.Size = New System.Drawing.Size(52, 38)
        Me.cmdmodificar.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.cmdmodificar, "Editar")
        Me.cmdmodificar.UseVisualStyleBackColor = False
        '
        'cmdcancelar
        '
        Me.cmdcancelar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdcancelar.Image = Global.SAE.My.Resources.Resources.cancelar
        Me.cmdcancelar.Location = New System.Drawing.Point(118, 12)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(52, 38)
        Me.cmdcancelar.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.cmdcancelar, "Cancelar")
        Me.cmdcancelar.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CmdEliminar)
        Me.GroupBox3.Controls.Add(Me.cmdPrint)
        Me.GroupBox3.Controls.Add(Me.cmdProc)
        Me.GroupBox3.Controls.Add(Me.cmdNuevo)
        Me.GroupBox3.Controls.Add(Me.CmdMostrar)
        Me.GroupBox3.Controls.Add(Me.cmdsalir)
        Me.GroupBox3.Controls.Add(Me.cmdguardar)
        Me.GroupBox3.Controls.Add(Me.cmdmodificar)
        Me.GroupBox3.Controls.Add(Me.cmdcancelar)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 324)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(502, 61)
        Me.GroupBox3.TabIndex = 94
        Me.GroupBox3.TabStop = False
        '
        'FrmGestionCitas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(513, 395)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbnroobs)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmGestionCitas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gestion Citas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtnomc As System.Windows.Forms.TextBox
    Friend WithEvents lbnov1 As System.Windows.Forms.Label
    Friend WithEvents txtnitc As System.Windows.Forms.TextBox
    Friend WithEvents Lbnov As System.Windows.Forms.Label
    Friend WithEvents txtnomv As System.Windows.Forms.TextBox
    Friend WithEvents lbestado As System.Windows.Forms.Label
    Friend WithEvents txtnitv As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtobs As System.Windows.Forms.TextBox
    Friend WithEvents txtserv As System.Windows.Forms.TextBox
    Friend WithEvents txtf1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdcancelar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdmodificar As System.Windows.Forms.Button
    Friend WithEvents lbnroobs As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents cmdguardar As System.Windows.Forms.Button
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents CmdMostrar As System.Windows.Forms.Button
    Friend WithEvents cmdNuevo As System.Windows.Forms.Button
    Friend WithEvents cmdProc As System.Windows.Forms.Button
    Friend WithEvents CmdEliminar As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtnoma As System.Windows.Forms.TextBox
    Friend WithEvents txtnita As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtestado As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txthora As System.Windows.Forms.TextBox
End Class
