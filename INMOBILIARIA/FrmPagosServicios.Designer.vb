<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPagosServicios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPagosServicios))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtvalordp = New System.Windows.Forms.TextBox
        Me.lbanulado = New System.Windows.Forms.TextBox
        Me.cmbCont = New System.Windows.Forms.Button
        Me.cmdmodificar = New System.Windows.Forms.Button
        Me.lbdoc = New System.Windows.Forms.Label
        Me.txtdep = New System.Windows.Forms.TextBox
        Me.txtnomp = New System.Windows.Forms.TextBox
        Me.chdp = New System.Windows.Forms.CheckBox
        Me.txtnitp = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.lbmesA = New System.Windows.Forms.Label
        Me.txtnoma = New System.Windows.Forms.TextBox
        Me.cmbservicio = New System.Windows.Forms.ComboBox
        Me.txtnita = New System.Windows.Forms.TextBox
        Me.txtf1 = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lbestado = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtmedpago = New System.Windows.Forms.TextBox
        Me.txtvalor = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbmes = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtinm = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.CmdEliminar = New System.Windows.Forms.Button
        Me.CmdMostrar = New System.Windows.Forms.Button
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdNuevo = New System.Windows.Forms.Button
        Me.cmdguardar = New System.Windows.Forms.Button
        Me.cmdcancelar = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.lbper = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtvalordp)
        Me.GroupBox1.Controls.Add(Me.lbanulado)
        Me.GroupBox1.Controls.Add(Me.cmbCont)
        Me.GroupBox1.Controls.Add(Me.cmdmodificar)
        Me.GroupBox1.Controls.Add(Me.lbdoc)
        Me.GroupBox1.Controls.Add(Me.txtdep)
        Me.GroupBox1.Controls.Add(Me.txtnomp)
        Me.GroupBox1.Controls.Add(Me.chdp)
        Me.GroupBox1.Controls.Add(Me.txtnitp)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.lbmesA)
        Me.GroupBox1.Controls.Add(Me.txtnoma)
        Me.GroupBox1.Controls.Add(Me.cmbservicio)
        Me.GroupBox1.Controls.Add(Me.txtnita)
        Me.GroupBox1.Controls.Add(Me.txtf1)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lbestado)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtmedpago)
        Me.GroupBox1.Controls.Add(Me.txtvalor)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmbmes)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtinm)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(389, 305)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'txtvalordp
        '
        Me.txtvalordp.BackColor = System.Drawing.Color.White
        Me.txtvalordp.Location = New System.Drawing.Point(262, 197)
        Me.txtvalordp.Name = "txtvalordp"
        Me.txtvalordp.Size = New System.Drawing.Size(102, 20)
        Me.txtvalordp.TabIndex = 90
        Me.txtvalordp.Visible = False
        '
        'lbanulado
        '
        Me.lbanulado.Location = New System.Drawing.Point(276, 253)
        Me.lbanulado.Name = "lbanulado"
        Me.lbanulado.Size = New System.Drawing.Size(100, 20)
        Me.lbanulado.TabIndex = 89
        Me.lbanulado.Visible = False
        '
        'cmbCont
        '
        Me.cmbCont.Location = New System.Drawing.Point(262, 224)
        Me.cmbCont.Name = "cmbCont"
        Me.cmbCont.Size = New System.Drawing.Size(75, 23)
        Me.cmbCont.TabIndex = 7
        Me.cmbCont.Text = "Contabilizar"
        Me.cmbCont.UseVisualStyleBackColor = True
        '
        'cmdmodificar
        '
        Me.cmdmodificar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdmodificar.Image = Global.SAE.My.Resources.Resources.editar
        Me.cmdmodificar.Location = New System.Drawing.Point(329, 107)
        Me.cmdmodificar.Name = "cmdmodificar"
        Me.cmdmodificar.Size = New System.Drawing.Size(52, 38)
        Me.cmdmodificar.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.cmdmodificar, "Editar")
        Me.cmdmodificar.UseVisualStyleBackColor = False
        Me.cmdmodificar.Visible = False
        '
        'lbdoc
        '
        Me.lbdoc.AutoSize = True
        Me.lbdoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbdoc.Location = New System.Drawing.Point(207, 253)
        Me.lbdoc.Name = "lbdoc"
        Me.lbdoc.Size = New System.Drawing.Size(23, 13)
        Me.lbdoc.TabIndex = 88
        Me.lbdoc.Text = "CE"
        '
        'txtdep
        '
        Me.txtdep.BackColor = System.Drawing.Color.White
        Me.txtdep.Location = New System.Drawing.Point(113, 226)
        Me.txtdep.Name = "txtdep"
        Me.txtdep.ReadOnly = True
        Me.txtdep.Size = New System.Drawing.Size(100, 20)
        Me.txtdep.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.txtdep, "Disponible en deposito")
        '
        'txtnomp
        '
        Me.txtnomp.Enabled = False
        Me.txtnomp.Location = New System.Drawing.Point(215, 55)
        Me.txtnomp.Name = "txtnomp"
        Me.txtnomp.Size = New System.Drawing.Size(168, 20)
        Me.txtnomp.TabIndex = 85
        '
        'chdp
        '
        Me.chdp.AutoSize = True
        Me.chdp.Location = New System.Drawing.Point(6, 226)
        Me.chdp.Name = "chdp"
        Me.chdp.Size = New System.Drawing.Size(105, 17)
        Me.chdp.TabIndex = 5
        Me.chdp.Text = "Afectar Deposito"
        Me.chdp.UseVisualStyleBackColor = True
        '
        'txtnitp
        '
        Me.txtnitp.BackColor = System.Drawing.Color.White
        Me.txtnitp.Enabled = False
        Me.txtnitp.Location = New System.Drawing.Point(113, 55)
        Me.txtnitp.Name = "txtnitp"
        Me.txtnitp.ReadOnly = True
        Me.txtnitp.Size = New System.Drawing.Size(96, 20)
        Me.txtnitp.TabIndex = 84
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 89)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 13)
        Me.Label7.TabIndex = 86
        Me.Label7.Text = "Arrendatario"
        '
        'lbmesA
        '
        Me.lbmesA.AutoSize = True
        Me.lbmesA.Location = New System.Drawing.Point(6, 12)
        Me.lbmesA.Name = "lbmesA"
        Me.lbmesA.Size = New System.Drawing.Size(41, 13)
        Me.lbmesA.TabIndex = 82
        Me.lbmesA.Text = "lbmesA"
        Me.lbmesA.Visible = False
        '
        'txtnoma
        '
        Me.txtnoma.Enabled = False
        Me.txtnoma.Location = New System.Drawing.Point(215, 81)
        Me.txtnoma.Name = "txtnoma"
        Me.txtnoma.Size = New System.Drawing.Size(168, 20)
        Me.txtnoma.TabIndex = 82
        '
        'cmbservicio
        '
        Me.cmbservicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbservicio.FormattingEnabled = True
        Me.cmbservicio.Location = New System.Drawing.Point(113, 115)
        Me.cmbservicio.Name = "cmbservicio"
        Me.cmbservicio.Size = New System.Drawing.Size(205, 21)
        Me.cmbservicio.TabIndex = 2
        '
        'txtnita
        '
        Me.txtnita.BackColor = System.Drawing.Color.White
        Me.txtnita.Enabled = False
        Me.txtnita.Location = New System.Drawing.Point(113, 82)
        Me.txtnita.Name = "txtnita"
        Me.txtnita.ReadOnly = True
        Me.txtnita.Size = New System.Drawing.Size(96, 20)
        Me.txtnita.TabIndex = 81
        '
        'txtf1
        '
        Me.txtf1.CustomFormat = "yyyy/dd/mm"
        Me.txtf1.Location = New System.Drawing.Point(113, 142)
        Me.txtf1.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.txtf1.Name = "txtf1"
        Me.txtf1.Size = New System.Drawing.Size(205, 20)
        Me.txtf1.TabIndex = 3
        Me.txtf1.Value = New Date(2010, 1, 14, 0, 0, 0, 0)
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 58)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 13)
        Me.Label8.TabIndex = 83
        Me.Label8.Text = "Propietario"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 147)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Fecha de Pago"
        '
        'lbestado
        '
        Me.lbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbestado.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbestado.Location = New System.Drawing.Point(273, 12)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(108, 22)
        Me.lbestado.TabIndex = 81
        Me.lbestado.Text = "NULO"
        Me.lbestado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 120)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 83
        Me.Label6.Text = "Servicio"
        '
        'txtmedpago
        '
        Me.txtmedpago.BackColor = System.Drawing.Color.White
        Me.txtmedpago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtmedpago.Location = New System.Drawing.Point(113, 276)
        Me.txtmedpago.Name = "txtmedpago"
        Me.txtmedpago.Size = New System.Drawing.Size(205, 20)
        Me.txtmedpago.TabIndex = 8
        '
        'txtvalor
        '
        Me.txtvalor.BackColor = System.Drawing.Color.White
        Me.txtvalor.Location = New System.Drawing.Point(113, 199)
        Me.txtvalor.Name = "txtvalor"
        Me.txtvalor.Size = New System.Drawing.Size(143, 20)
        Me.txtvalor.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 279)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Medio de Pago"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 200)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Valor Pagado"
        '
        'cmbmes
        '
        Me.cmbmes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbmes.FormattingEnabled = True
        Me.cmbmes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cmbmes.Location = New System.Drawing.Point(113, 169)
        Me.cmbmes.Name = "cmbmes"
        Me.cmbmes.Size = New System.Drawing.Size(143, 21)
        Me.cmbmes.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 174)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Mes Pago"
        '
        'txtinm
        '
        Me.txtinm.BackColor = System.Drawing.Color.White
        Me.txtinm.Location = New System.Drawing.Point(113, 29)
        Me.txtinm.Name = "txtinm"
        Me.txtinm.Size = New System.Drawing.Size(143, 20)
        Me.txtinm.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Codigo del Inmueble"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CmdEliminar)
        Me.GroupBox3.Controls.Add(Me.CmdMostrar)
        Me.GroupBox3.Controls.Add(Me.cmdsalir)
        Me.GroupBox3.Controls.Add(Me.cmdNuevo)
        Me.GroupBox3.Controls.Add(Me.cmdguardar)
        Me.GroupBox3.Controls.Add(Me.cmdcancelar)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 307)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(389, 61)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'CmdEliminar
        '
        Me.CmdEliminar.Image = Global.SAE.My.Resources.Resources.eliminar
        Me.CmdEliminar.Location = New System.Drawing.Point(189, 13)
        Me.CmdEliminar.Name = "CmdEliminar"
        Me.CmdEliminar.Size = New System.Drawing.Size(52, 38)
        Me.CmdEliminar.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.CmdEliminar, "Eliminar")
        Me.CmdEliminar.UseVisualStyleBackColor = True
        '
        'CmdMostrar
        '
        Me.CmdMostrar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.CmdMostrar.Image = Global.SAE.My.Resources.Resources.DataTables
        Me.CmdMostrar.Location = New System.Drawing.Point(244, 13)
        Me.CmdMostrar.Name = "CmdMostrar"
        Me.CmdMostrar.Size = New System.Drawing.Size(52, 38)
        Me.CmdMostrar.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.CmdMostrar, "Consultar Inmuebles")
        Me.CmdMostrar.UseVisualStyleBackColor = False
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.salir
        Me.cmdsalir.Location = New System.Drawing.Point(299, 13)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(52, 38)
        Me.cmdsalir.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.cmdsalir, "Salir")
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'cmdNuevo
        '
        Me.cmdNuevo.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdNuevo.Image = Global.SAE.My.Resources.Resources.nuevo
        Me.cmdNuevo.Location = New System.Drawing.Point(28, 13)
        Me.cmdNuevo.Name = "cmdNuevo"
        Me.cmdNuevo.Size = New System.Drawing.Size(52, 38)
        Me.cmdNuevo.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.cmdNuevo, "Nuevo")
        Me.cmdNuevo.UseVisualStyleBackColor = False
        '
        'cmdguardar
        '
        Me.cmdguardar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdguardar.Image = Global.SAE.My.Resources.Resources.guardar
        Me.cmdguardar.Location = New System.Drawing.Point(81, 13)
        Me.cmdguardar.Name = "cmdguardar"
        Me.cmdguardar.Size = New System.Drawing.Size(52, 38)
        Me.cmdguardar.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.cmdguardar, "Guardar")
        Me.cmdguardar.UseVisualStyleBackColor = False
        '
        'cmdcancelar
        '
        Me.cmdcancelar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdcancelar.Image = Global.SAE.My.Resources.Resources.cancelar
        Me.cmdcancelar.Location = New System.Drawing.Point(135, 13)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(52, 38)
        Me.cmdcancelar.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.cmdcancelar, "Cancelar")
        Me.cmdcancelar.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 251)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 13)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Doc Contable"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkSeaGreen
        Me.Label10.Location = New System.Drawing.Point(120, 252)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 20)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "No. "
        '
        'lbper
        '
        Me.lbper.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbper.ForeColor = System.Drawing.Color.Black
        Me.lbper.Location = New System.Drawing.Point(152, 252)
        Me.lbper.Name = "lbper"
        Me.lbper.Size = New System.Drawing.Size(65, 20)
        Me.lbper.TabIndex = 15
        Me.lbper.Text = "01/2011-"
        '
        'FrmPagosServicios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(403, 375)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lbper)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPagosServicios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Control de Pagos Servicios Publicos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtinm As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbmes As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtvalor As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtf1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtmedpago As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdMostrar As System.Windows.Forms.Button
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdNuevo As System.Windows.Forms.Button
    Friend WithEvents cmdguardar As System.Windows.Forms.Button
    Friend WithEvents cmdcancelar As System.Windows.Forms.Button
    Friend WithEvents lbestado As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmbservicio As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdmodificar As System.Windows.Forms.Button
    Friend WithEvents lbmesA As System.Windows.Forms.Label
    Friend WithEvents CmdEliminar As System.Windows.Forms.Button
    Friend WithEvents chdp As System.Windows.Forms.CheckBox
    Friend WithEvents txtnomp As System.Windows.Forms.TextBox
    Friend WithEvents txtnitp As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtnoma As System.Windows.Forms.TextBox
    Friend WithEvents txtnita As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtdep As System.Windows.Forms.TextBox
    Friend WithEvents cmbCont As System.Windows.Forms.Button
    Friend WithEvents lbdoc As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lbper As System.Windows.Forms.Label
    Friend WithEvents lbanulado As System.Windows.Forms.TextBox
    Friend WithEvents txtvalordp As System.Windows.Forms.TextBox
End Class
