<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInmueble
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInmueble))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtfE = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.txtInsc = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtMatrInm = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtnotaria = New System.Windows.Forms.TextBox
        Me.txtNEsc = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtllaves = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.cmbEstrato = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtAvaCata = New System.Windows.Forms.TextBox
        Me.cmbCiudad = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtNcatas = New System.Windows.Forms.TextBox
        Me.txtdes = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtPLocal = New System.Windows.Forms.TextBox
        Me.txtBarrio = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmbDestino = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmbEst = New System.Windows.Forms.ComboBox
        Me.cmbconserva = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmbDpto = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmbOperacion = New System.Windows.Forms.ComboBox
        Me.cmbTipo = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtPvivi = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtdire = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbestado = New System.Windows.Forms.ComboBox
        Me.txtavalCom = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtnomp = New System.Windows.Forms.TextBox
        Me.txtnitp = New System.Windows.Forms.TextBox
        Me.txtcod = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmbCiudad2 = New System.Windows.Forms.ComboBox
        Me.lbnroobs = New System.Windows.Forms.Label
        Me.cmbDpto2 = New System.Windows.Forms.ComboBox
        Me.CmdBuscar = New System.Windows.Forms.Button
        Me.cmdNuevo = New System.Windows.Forms.Button
        Me.Label38 = New System.Windows.Forms.Label
        Me.CmdMostrar = New System.Windows.Forms.Button
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.lbestado = New System.Windows.Forms.Label
        Me.cmdguardar = New System.Windows.Forms.Button
        Me.cmdmodificar = New System.Windows.Forms.Button
        Me.cmdcancelar = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CmdEliminar = New System.Windows.Forms.Button
        Me.servicios = New System.Windows.Forms.Button
        Me.llaves = New System.Windows.Forms.Button
        Me.dependencia = New System.Windows.Forms.Button
        Me.cmdGaleria = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtfE)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.txtInsc)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.txtMatrInm)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.txtnotaria)
        Me.GroupBox1.Controls.Add(Me.txtNEsc)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.txtllaves)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.cmbEstrato)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.txtAvaCata)
        Me.GroupBox1.Controls.Add(Me.cmbCiudad)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txtNcatas)
        Me.GroupBox1.Controls.Add(Me.txtdes)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtPLocal)
        Me.GroupBox1.Controls.Add(Me.txtBarrio)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.cmbDestino)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.cmbEst)
        Me.GroupBox1.Controls.Add(Me.cmbconserva)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.cmbDpto)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cmbOperacion)
        Me.GroupBox1.Controls.Add(Me.cmbTipo)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtPvivi)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtdire)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cbestado)
        Me.GroupBox1.Controls.Add(Me.txtavalCom)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtnomp)
        Me.GroupBox1.Controls.Add(Me.txtnitp)
        Me.GroupBox1.Controls.Add(Me.txtcod)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 67)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(657, 398)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Informacion General"
        '
        'txtfE
        '
        Me.txtfE.BackColor = System.Drawing.Color.White
        Me.txtfE.Location = New System.Drawing.Point(451, 275)
        Me.txtfE.Name = "txtfE"
        Me.txtfE.Size = New System.Drawing.Size(185, 20)
        Me.txtfE.TabIndex = 20
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(449, 310)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(58, 13)
        Me.Label25.TabIndex = 109
        Me.Label25.Text = "Inscripcion"
        '
        'txtInsc
        '
        Me.txtInsc.BackColor = System.Drawing.Color.White
        Me.txtInsc.Location = New System.Drawing.Point(515, 307)
        Me.txtInsc.Name = "txtInsc"
        Me.txtInsc.Size = New System.Drawing.Size(122, 20)
        Me.txtInsc.TabIndex = 23
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(206, 310)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(105, 13)
        Me.Label24.TabIndex = 107
        Me.Label24.Text = "Matricula Inmobiliaria"
        '
        'txtMatrInm
        '
        Me.txtMatrInm.BackColor = System.Drawing.Color.White
        Me.txtMatrInm.Location = New System.Drawing.Point(317, 307)
        Me.txtMatrInm.Name = "txtMatrInm"
        Me.txtMatrInm.Size = New System.Drawing.Size(122, 20)
        Me.txtMatrInm.TabIndex = 22
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(6, 312)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(41, 13)
        Me.Label23.TabIndex = 105
        Me.Label23.Text = "Notaria"
        '
        'txtnotaria
        '
        Me.txtnotaria.BackColor = System.Drawing.Color.White
        Me.txtnotaria.Location = New System.Drawing.Point(75, 307)
        Me.txtnotaria.Name = "txtnotaria"
        Me.txtnotaria.Size = New System.Drawing.Size(122, 20)
        Me.txtnotaria.TabIndex = 21
        '
        'txtNEsc
        '
        Me.txtNEsc.BackColor = System.Drawing.Color.White
        Me.txtNEsc.Location = New System.Drawing.Point(75, 276)
        Me.txtNEsc.Name = "txtNEsc"
        Me.txtNEsc.Size = New System.Drawing.Size(228, 20)
        Me.txtNEsc.TabIndex = 19
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(311, 273)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(134, 26)
        Me.Label22.TabIndex = 103
        Me.Label22.Text = "Fecha de Escritura" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(DD de MM del año AAAA)"
        '
        'txtllaves
        '
        Me.txtllaves.BackColor = System.Drawing.Color.White
        Me.txtllaves.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtllaves.Location = New System.Drawing.Point(103, 172)
        Me.txtllaves.Name = "txtllaves"
        Me.txtllaves.Size = New System.Drawing.Size(50, 20)
        Me.txtllaves.TabIndex = 12
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(6, 278)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 13)
        Me.Label21.TabIndex = 101
        Me.Label21.Text = "N° Escritura"
        '
        'cmbEstrato
        '
        Me.cmbEstrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstrato.FormattingEnabled = True
        Me.cmbEstrato.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07"})
        Me.cmbEstrato.Location = New System.Drawing.Point(598, 98)
        Me.cmbEstrato.Name = "cmbEstrato"
        Me.cmbEstrato.Size = New System.Drawing.Size(37, 21)
        Me.cmbEstrato.TabIndex = 8
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(3, 174)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(102, 13)
        Me.Label20.TabIndex = 99
        Me.Label20.Text = "Cantidad de LLaves"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(552, 102)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(40, 13)
        Me.Label19.TabIndex = 97
        Me.Label19.Text = "Estrato"
        '
        'txtAvaCata
        '
        Me.txtAvaCata.BackColor = System.Drawing.Color.White
        Me.txtAvaCata.Location = New System.Drawing.Point(525, 204)
        Me.txtAvaCata.Name = "txtAvaCata"
        Me.txtAvaCata.Size = New System.Drawing.Size(110, 20)
        Me.txtAvaCata.TabIndex = 16
        '
        'cmbCiudad
        '
        Me.cmbCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCiudad.FormattingEnabled = True
        Me.cmbCiudad.Location = New System.Drawing.Point(505, 59)
        Me.cmbCiudad.Name = "cmbCiudad"
        Me.cmbCiudad.Size = New System.Drawing.Size(130, 21)
        Me.cmbCiudad.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(460, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 80
        Me.Label6.Text = "Ciudad"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(409, 207)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(84, 13)
        Me.Label18.TabIndex = 94
        Me.Label18.Text = "Avaluo Catastral"
        '
        'txtNcatas
        '
        Me.txtNcatas.BackColor = System.Drawing.Color.White
        Me.txtNcatas.Location = New System.Drawing.Point(106, 206)
        Me.txtNcatas.Name = "txtNcatas"
        Me.txtNcatas.Size = New System.Drawing.Size(287, 20)
        Me.txtNcatas.TabIndex = 15
        '
        'txtdes
        '
        Me.txtdes.BackColor = System.Drawing.Color.White
        Me.txtdes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdes.Location = New System.Drawing.Point(101, 338)
        Me.txtdes.Multiline = True
        Me.txtdes.Name = "txtdes"
        Me.txtdes.Size = New System.Drawing.Size(535, 51)
        Me.txtdes.TabIndex = 24
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(5, 208)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(84, 13)
        Me.Label17.TabIndex = 92
        Me.Label17.Text = "Codigo Catastral"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 338)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 15)
        Me.Label8.TabIndex = 82
        Me.Label8.Text = "Observaciones"
        '
        'txtPLocal
        '
        Me.txtPLocal.BackColor = System.Drawing.Color.White
        Me.txtPLocal.Location = New System.Drawing.Point(515, 172)
        Me.txtPLocal.Name = "txtPLocal"
        Me.txtPLocal.Size = New System.Drawing.Size(122, 20)
        Me.txtPLocal.TabIndex = 14
        '
        'txtBarrio
        '
        Me.txtBarrio.BackColor = System.Drawing.Color.White
        Me.txtBarrio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBarrio.Location = New System.Drawing.Point(403, 99)
        Me.txtBarrio.Name = "txtBarrio"
        Me.txtBarrio.Size = New System.Drawing.Size(135, 20)
        Me.txtBarrio.TabIndex = 7
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(155, 175)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(81, 13)
        Me.Label16.TabIndex = 78
        Me.Label16.Text = "Precio Vivienda"
        '
        'cmbDestino
        '
        Me.cmbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDestino.FormattingEnabled = True
        Me.cmbDestino.Items.AddRange(New Object() {"COMERCIAL", "MIXTO", "VIVIENDA", "OTRO"})
        Me.cmbDestino.Location = New System.Drawing.Point(514, 132)
        Me.cmbDestino.Name = "cmbDestino"
        Me.cmbDestino.Size = New System.Drawing.Size(121, 21)
        Me.cmbDestino.TabIndex = 11
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(363, 102)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(34, 13)
        Me.Label15.TabIndex = 78
        Me.Label15.Text = "Barrio"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(449, 135)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(43, 13)
        Me.Label14.TabIndex = 90
        Me.Label14.Text = "Destino"
        '
        'cmbEst
        '
        Me.cmbEst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEst.FormattingEnabled = True
        Me.cmbEst.Items.AddRange(New Object() {"NUEVO", "USADO"})
        Me.cmbEst.Location = New System.Drawing.Point(282, 132)
        Me.cmbEst.Name = "cmbEst"
        Me.cmbEst.Size = New System.Drawing.Size(121, 21)
        Me.cmbEst.TabIndex = 10
        '
        'cmbconserva
        '
        Me.cmbconserva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbconserva.FormattingEnabled = True
        Me.cmbconserva.Items.AddRange(New Object() {"BUENO", "EXCELENTE", "PARA ESTRENO", "OTRO"})
        Me.cmbconserva.Location = New System.Drawing.Point(89, 134)
        Me.cmbconserva.Name = "cmbconserva"
        Me.cmbconserva.Size = New System.Drawing.Size(121, 21)
        Me.cmbconserva.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(230, 135)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 13)
        Me.Label13.TabIndex = 88
        Me.Label13.Text = "Estado"
        '
        'cmbDpto
        '
        Me.cmbDpto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDpto.FormattingEnabled = True
        Me.cmbDpto.Location = New System.Drawing.Point(271, 62)
        Me.cmbDpto.Name = "cmbDpto"
        Me.cmbDpto.Size = New System.Drawing.Size(168, 21)
        Me.cmbDpto.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(3, 136)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 13)
        Me.Label12.TabIndex = 86
        Me.Label12.Text = "Conservación"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(191, 67)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 13)
        Me.Label11.TabIndex = 84
        Me.Label11.Text = "Departamento"
        '
        'cmbOperacion
        '
        Me.cmbOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOperacion.FormattingEnabled = True
        Me.cmbOperacion.Items.AddRange(New Object() {"ARRIENDO", "VENTA"})
        Me.cmbOperacion.Location = New System.Drawing.Point(65, 62)
        Me.cmbOperacion.Name = "cmbOperacion"
        Me.cmbOperacion.Size = New System.Drawing.Size(122, 21)
        Me.cmbOperacion.TabIndex = 3
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(253, 30)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(225, 21)
        Me.cmbTipo.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(3, 65)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 13)
        Me.Label10.TabIndex = 80
        Me.Label10.Text = "Operacion"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(159, 33)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 13)
        Me.Label9.TabIndex = 78
        Me.Label9.Text = "Tipo de Inmueble"
        '
        'txtPvivi
        '
        Me.txtPvivi.BackColor = System.Drawing.Color.White
        Me.txtPvivi.Location = New System.Drawing.Point(238, 173)
        Me.txtPvivi.Name = "txtPvivi"
        Me.txtPvivi.Size = New System.Drawing.Size(108, 20)
        Me.txtPvivi.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(349, 175)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(161, 13)
        Me.Label7.TabIndex = 81
        Me.Label7.Text = "Precio Local comercial y/o Mixto"
        '
        'txtdire
        '
        Me.txtdire.BackColor = System.Drawing.Color.White
        Me.txtdire.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdire.Location = New System.Drawing.Point(67, 99)
        Me.txtdire.Name = "txtdire"
        Me.txtdire.Size = New System.Drawing.Size(290, 20)
        Me.txtdire.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 79
        Me.Label5.Text = "Direccion"
        '
        'cbestado
        '
        Me.cbestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbestado.FormattingEnabled = True
        Me.cbestado.Items.AddRange(New Object() {"DISPONIBLE", "OCUPADO", "INACTIVO"})
        Me.cbestado.Location = New System.Drawing.Point(515, 30)
        Me.cbestado.Name = "cbestado"
        Me.cbestado.Size = New System.Drawing.Size(121, 21)
        Me.cbestado.TabIndex = 2
        '
        'txtavalCom
        '
        Me.txtavalCom.BackColor = System.Drawing.Color.White
        Me.txtavalCom.Location = New System.Drawing.Point(108, 243)
        Me.txtavalCom.Name = "txtavalCom"
        Me.txtavalCom.Size = New System.Drawing.Size(121, 20)
        Me.txtavalCom.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(485, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Fase"
        '
        'txtnomp
        '
        Me.txtnomp.Enabled = False
        Me.txtnomp.Location = New System.Drawing.Point(412, 243)
        Me.txtnomp.Name = "txtnomp"
        Me.txtnomp.Size = New System.Drawing.Size(225, 20)
        Me.txtnomp.TabIndex = 18
        '
        'txtnitp
        '
        Me.txtnitp.BackColor = System.Drawing.Color.White
        Me.txtnitp.Location = New System.Drawing.Point(304, 243)
        Me.txtnitp.Name = "txtnitp"
        Me.txtnitp.Size = New System.Drawing.Size(105, 20)
        Me.txtnitp.TabIndex = 18
        '
        'txtcod
        '
        Me.txtcod.BackColor = System.Drawing.Color.White
        Me.txtcod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcod.Location = New System.Drawing.Point(51, 30)
        Me.txtcod.Name = "txtcod"
        Me.txtcod.Size = New System.Drawing.Size(102, 20)
        Me.txtcod.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 246)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Avaluo Comercial"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(235, 244)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Propietario"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdPrint)
        Me.GroupBox3.Controls.Add(Me.cmbCiudad2)
        Me.GroupBox3.Controls.Add(Me.lbnroobs)
        Me.GroupBox3.Controls.Add(Me.cmbDpto2)
        Me.GroupBox3.Controls.Add(Me.CmdBuscar)
        Me.GroupBox3.Controls.Add(Me.cmdNuevo)
        Me.GroupBox3.Controls.Add(Me.Label38)
        Me.GroupBox3.Controls.Add(Me.CmdMostrar)
        Me.GroupBox3.Controls.Add(Me.cmdsalir)
        Me.GroupBox3.Controls.Add(Me.lbestado)
        Me.GroupBox3.Controls.Add(Me.cmdguardar)
        Me.GroupBox3.Controls.Add(Me.cmdmodificar)
        Me.GroupBox3.Controls.Add(Me.cmdcancelar)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(657, 61)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'cmdPrint
        '
        Me.cmdPrint.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdPrint.Image = Global.SAE.My.Resources.Resources.pdf
        Me.cmdPrint.Location = New System.Drawing.Point(353, 12)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(52, 38)
        Me.cmdPrint.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.cmdPrint, "Ver PDF")
        Me.cmdPrint.UseVisualStyleBackColor = False
        '
        'cmbCiudad2
        '
        Me.cmbCiudad2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCiudad2.FormattingEnabled = True
        Me.cmbCiudad2.Location = New System.Drawing.Point(600, 41)
        Me.cmbCiudad2.Name = "cmbCiudad2"
        Me.cmbCiudad2.Size = New System.Drawing.Size(32, 21)
        Me.cmbCiudad2.TabIndex = 100
        Me.cmbCiudad2.Visible = False
        '
        'lbnroobs
        '
        Me.lbnroobs.AutoSize = True
        Me.lbnroobs.BackColor = System.Drawing.Color.Transparent
        Me.lbnroobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnroobs.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbnroobs.Location = New System.Drawing.Point(612, 38)
        Me.lbnroobs.Name = "lbnroobs"
        Me.lbnroobs.Size = New System.Drawing.Size(35, 13)
        Me.lbnroobs.TabIndex = 77
        Me.lbnroobs.Text = "0000"
        Me.lbnroobs.Visible = False
        '
        'cmbDpto2
        '
        Me.cmbDpto2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDpto2.FormattingEnabled = True
        Me.cmbDpto2.Location = New System.Drawing.Point(563, 41)
        Me.cmbDpto2.Name = "cmbDpto2"
        Me.cmbDpto2.Size = New System.Drawing.Size(36, 21)
        Me.cmbDpto2.TabIndex = 99
        Me.cmbDpto2.Visible = False
        '
        'CmdBuscar
        '
        Me.CmdBuscar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.CmdBuscar.Image = Global.SAE.My.Resources.Resources.anular1
        Me.CmdBuscar.Location = New System.Drawing.Point(238, 12)
        Me.CmdBuscar.Name = "CmdBuscar"
        Me.CmdBuscar.Size = New System.Drawing.Size(52, 38)
        Me.CmdBuscar.TabIndex = 79
        Me.ToolTip1.SetToolTip(Me.CmdBuscar, "Eliminar")
        Me.CmdBuscar.UseVisualStyleBackColor = False
        '
        'cmdNuevo
        '
        Me.cmdNuevo.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdNuevo.Image = Global.SAE.My.Resources.Resources.nuevo
        Me.cmdNuevo.Location = New System.Drawing.Point(9, 12)
        Me.cmdNuevo.Name = "cmdNuevo"
        Me.cmdNuevo.Size = New System.Drawing.Size(52, 38)
        Me.cmdNuevo.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.cmdNuevo, "Nuevo")
        Me.cmdNuevo.UseVisualStyleBackColor = False
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label38.Location = New System.Drawing.Point(532, 38)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(82, 13)
        Me.Label38.TabIndex = 76
        Me.Label38.Text = "Registro Nro."
        Me.Label38.Visible = False
        '
        'CmdMostrar
        '
        Me.CmdMostrar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.CmdMostrar.Image = Global.SAE.My.Resources.Resources.DataTables
        Me.CmdMostrar.Location = New System.Drawing.Point(296, 12)
        Me.CmdMostrar.Name = "CmdMostrar"
        Me.CmdMostrar.Size = New System.Drawing.Size(52, 38)
        Me.CmdMostrar.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.CmdMostrar, "Listar Inmuebles")
        Me.CmdMostrar.UseVisualStyleBackColor = False
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.salir
        Me.cmdsalir.Location = New System.Drawing.Point(407, 12)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(52, 38)
        Me.cmdsalir.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.cmdsalir, "Salir")
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'lbestado
        '
        Me.lbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbestado.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbestado.Location = New System.Drawing.Point(560, 16)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(90, 22)
        Me.lbestado.TabIndex = 75
        Me.lbestado.Text = "NULO"
        Me.lbestado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdguardar
        '
        Me.cmdguardar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdguardar.Image = Global.SAE.My.Resources.Resources.guardar
        Me.cmdguardar.Location = New System.Drawing.Point(67, 12)
        Me.cmdguardar.Name = "cmdguardar"
        Me.cmdguardar.Size = New System.Drawing.Size(52, 38)
        Me.cmdguardar.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.cmdguardar, "Guardar")
        Me.cmdguardar.UseVisualStyleBackColor = False
        '
        'cmdmodificar
        '
        Me.cmdmodificar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdmodificar.Image = Global.SAE.My.Resources.Resources.editar
        Me.cmdmodificar.Location = New System.Drawing.Point(183, 12)
        Me.cmdmodificar.Name = "cmdmodificar"
        Me.cmdmodificar.Size = New System.Drawing.Size(52, 38)
        Me.cmdmodificar.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.cmdmodificar, "Editar")
        Me.cmdmodificar.UseVisualStyleBackColor = False
        '
        'cmdcancelar
        '
        Me.cmdcancelar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdcancelar.Image = Global.SAE.My.Resources.Resources.cancelar
        Me.cmdcancelar.Location = New System.Drawing.Point(125, 12)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(52, 38)
        Me.cmdcancelar.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.cmdcancelar, "Cancelar")
        Me.cmdcancelar.UseVisualStyleBackColor = False
        '
        'CmdEliminar
        '
        Me.CmdEliminar.Image = Global.SAE.My.Resources.Resources.eliminar
        Me.CmdEliminar.Location = New System.Drawing.Point(612, 465)
        Me.CmdEliminar.Name = "CmdEliminar"
        Me.CmdEliminar.Size = New System.Drawing.Size(52, 38)
        Me.CmdEliminar.TabIndex = 99
        Me.ToolTip1.SetToolTip(Me.CmdEliminar, "eliminar")
        Me.CmdEliminar.UseVisualStyleBackColor = True
        Me.CmdEliminar.Visible = False
        '
        'servicios
        '
        Me.servicios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.servicios.Location = New System.Drawing.Point(7, 471)
        Me.servicios.Name = "servicios"
        Me.servicios.Size = New System.Drawing.Size(105, 23)
        Me.servicios.TabIndex = 96
        Me.servicios.Text = "Servicios"
        Me.servicios.UseVisualStyleBackColor = True
        '
        'llaves
        '
        Me.llaves.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llaves.Location = New System.Drawing.Point(223, 471)
        Me.llaves.Name = "llaves"
        Me.llaves.Size = New System.Drawing.Size(146, 23)
        Me.llaves.TabIndex = 97
        Me.llaves.Text = "Inventario de Llaves"
        Me.llaves.UseVisualStyleBackColor = True
        '
        'dependencia
        '
        Me.dependencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dependencia.Location = New System.Drawing.Point(115, 471)
        Me.dependencia.Name = "dependencia"
        Me.dependencia.Size = New System.Drawing.Size(105, 23)
        Me.dependencia.TabIndex = 98
        Me.dependencia.Text = "Dependencias"
        Me.dependencia.UseVisualStyleBackColor = True
        '
        'cmdGaleria
        '
        Me.cmdGaleria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGaleria.Location = New System.Drawing.Point(373, 471)
        Me.cmdGaleria.Name = "cmdGaleria"
        Me.cmdGaleria.Size = New System.Drawing.Size(139, 23)
        Me.cmdGaleria.TabIndex = 100
        Me.cmdGaleria.Text = "Galeria de Imagenes"
        Me.cmdGaleria.UseVisualStyleBackColor = True
        '
        'FrmInmueble
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(669, 504)
        Me.Controls.Add(Me.cmdGaleria)
        Me.Controls.Add(Me.CmdEliminar)
        Me.Controls.Add(Me.dependencia)
        Me.Controls.Add(Me.llaves)
        Me.Controls.Add(Me.servicios)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInmueble"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Inmuebles"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdMostrar As System.Windows.Forms.Button
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdcancelar As System.Windows.Forms.Button
    Friend WithEvents cmdmodificar As System.Windows.Forms.Button
    Friend WithEvents cmdguardar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbestado As System.Windows.Forms.ComboBox
    Friend WithEvents txtavalCom As System.Windows.Forms.TextBox
    Friend WithEvents txtnomp As System.Windows.Forms.TextBox
    Friend WithEvents txtnitp As System.Windows.Forms.TextBox
    Friend WithEvents txtcod As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbestado As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents lbnroobs As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdNuevo As System.Windows.Forms.Button
    Friend WithEvents CmdBuscar As System.Windows.Forms.Button
    Friend WithEvents txtdire As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtPvivi As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtdes As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbOperacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbDpto As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbCiudad As System.Windows.Forms.ComboBox
    Friend WithEvents cmbconserva As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbEst As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbDestino As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtBarrio As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtPLocal As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtAvaCata As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtNcatas As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents servicios As System.Windows.Forms.Button
    Friend WithEvents cmbEstrato As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents llaves As System.Windows.Forms.Button
    Friend WithEvents dependencia As System.Windows.Forms.Button
    Friend WithEvents txtllaves As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cmbDpto2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCiudad2 As System.Windows.Forms.ComboBox
    Friend WithEvents CmdEliminar As System.Windows.Forms.Button
    Friend WithEvents cmdGaleria As System.Windows.Forms.Button
    Friend WithEvents txtNEsc As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtnotaria As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtInsc As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtMatrInm As System.Windows.Forms.TextBox
    Friend WithEvents txtfE As System.Windows.Forms.TextBox
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
End Class
