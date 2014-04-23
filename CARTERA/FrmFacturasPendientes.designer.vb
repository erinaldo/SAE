<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFacturasPendientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFacturasPendientes))
        Me.lbdocajuste = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.lbhora = New System.Windows.Forms.Label
        Me.txtfecha = New System.Windows.Forms.DateTimePicker
        Me.txttipo = New System.Windows.Forms.ComboBox
        Me.lbestado = New System.Windows.Forms.Label
        Me.lbnumero = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtnumfac = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txttipo2 = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CmdUltimo = New System.Windows.Forms.Button
        Me.CmdEditar = New System.Windows.Forms.Button
        Me.CmdListo = New System.Windows.Forms.Button
        Me.CmdSiguiente = New System.Windows.Forms.Button
        Me.CmdAtras = New System.Windows.Forms.Button
        Me.CmdSalir = New System.Windows.Forms.Button
        Me.CmdCancelar = New System.Windows.Forms.Button
        Me.CmdPrimero = New System.Windows.Forms.Button
        Me.CmdEliminar = New System.Windows.Forms.Button
        Me.CmdMostrar = New System.Windows.Forms.Button
        Me.cmdNuevo = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.grupoctas = New System.Windows.Forms.GroupBox
        Me.txtctatotal = New System.Windows.Forms.TextBox
        Me.txtcentrocosto_NOM = New System.Windows.Forms.TextBox
        Me.txtobserbaciones = New System.Windows.Forms.TextBox
        Me.txtret = New System.Windows.Forms.TextBox
        Me.txtiva = New System.Windows.Forms.TextBox
        Me.txtdescuento = New System.Windows.Forms.TextBox
        Me.txtsubtotal = New System.Windows.Forms.TextBox
        Me.txtctasub = New System.Windows.Forms.TextBox
        Me.txtvalorret = New System.Windows.Forms.TextBox
        Me.txtctaret = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.txttotal = New System.Windows.Forms.Label
        Me.cmdobservaciones = New System.Windows.Forms.Button
        Me.Label19 = New System.Windows.Forms.Label
        Me.cbaprobado = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lbusuario = New System.Windows.Forms.Label
        Me.valoriva = New System.Windows.Forms.TextBox
        Me.txtvmto = New System.Windows.Forms.TextBox
        Me.valordes = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtcuentaiva = New System.Windows.Forms.TextBox
        Me.txtcentrocosto = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtcuentadesc = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtdetalle = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtcodeudor = New System.Windows.Forms.TextBox
        Me.txtcod = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtvendedor = New System.Windows.Forms.TextBox
        Me.txtnitv = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtcliente = New System.Windows.Forms.TextBox
        Me.txtnitc = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.CmdCambiarPeriodo = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.grupoctas.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbdocajuste
        '
        Me.lbdocajuste.AutoSize = True
        Me.lbdocajuste.Location = New System.Drawing.Point(207, 6)
        Me.lbdocajuste.Name = "lbdocajuste"
        Me.lbdocajuste.Size = New System.Drawing.Size(56, 13)
        Me.lbdocajuste.TabIndex = 166
        Me.lbdocajuste.Text = "doc ajuste"
        Me.lbdocajuste.Visible = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(292, 57)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(38, 16)
        Me.Label20.TabIndex = 165
        Me.Label20.Text = "Hora"
        '
        'lbhora
        '
        Me.lbhora.AutoSize = True
        Me.lbhora.Location = New System.Drawing.Point(339, 60)
        Me.lbhora.Name = "lbhora"
        Me.lbhora.Size = New System.Drawing.Size(49, 13)
        Me.lbhora.TabIndex = 164
        Me.lbhora.Text = "00:00:00"
        '
        'txtfecha
        '
        Me.txtfecha.CustomFormat = "yyyy/dd/mm"
        Me.txtfecha.Location = New System.Drawing.Point(65, 53)
        Me.txtfecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.txtfecha.Name = "txtfecha"
        Me.txtfecha.Size = New System.Drawing.Size(205, 20)
        Me.txtfecha.TabIndex = 14
        Me.txtfecha.Value = New Date(2010, 1, 14, 0, 0, 0, 0)
        '
        'txttipo
        '
        Me.txttipo.BackColor = System.Drawing.Color.White
        Me.txttipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txttipo.FormattingEnabled = True
        Me.txttipo.Location = New System.Drawing.Point(46, 18)
        Me.txttipo.Name = "txttipo"
        Me.txttipo.Size = New System.Drawing.Size(58, 21)
        Me.txttipo.TabIndex = 11
        '
        'lbestado
        '
        Me.lbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbestado.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbestado.Location = New System.Drawing.Point(11, 6)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(149, 22)
        Me.lbestado.TabIndex = 151
        Me.lbestado.Text = "Estado"
        '
        'lbnumero
        '
        Me.lbnumero.AutoSize = True
        Me.lbnumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnumero.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbnumero.Location = New System.Drawing.Point(605, 7)
        Me.lbnumero.Name = "lbnumero"
        Me.lbnumero.Size = New System.Drawing.Size(35, 13)
        Me.lbnumero.TabIndex = 150
        Me.lbnumero.Text = "0000"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label18.Location = New System.Drawing.Point(521, 7)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 13)
        Me.Label18.TabIndex = 149
        Me.Label18.Text = "Registro Nro."
        '
        'txtnumfac
        '
        Me.txtnumfac.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnumfac.Location = New System.Drawing.Point(539, 20)
        Me.txtnumfac.Name = "txtnumfac"
        Me.txtnumfac.ShortcutsEnabled = False
        Me.txtnumfac.Size = New System.Drawing.Size(92, 20)
        Me.txtnumfac.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 16)
        Me.Label3.TabIndex = 128
        Me.Label3.Text = "Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(427, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 126
        Me.Label2.Text = "Número Factura"
        '
        'txttipo2
        '
        Me.txttipo2.BackColor = System.Drawing.Color.White
        Me.txttipo2.Enabled = False
        Me.txttipo2.Location = New System.Drawing.Point(109, 19)
        Me.txttipo2.Name = "txttipo2"
        Me.txttipo2.ReadOnly = True
        Me.txttipo2.Size = New System.Drawing.Size(302, 20)
        Me.txttipo2.TabIndex = 12
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
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
        Me.GroupBox1.Location = New System.Drawing.Point(11, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(645, 56)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'CmdUltimo
        '
        Me.CmdUltimo.Image = CType(resources.GetObject("CmdUltimo.Image"), System.Drawing.Image)
        Me.CmdUltimo.Location = New System.Drawing.Point(572, 12)
        Me.CmdUltimo.Name = "CmdUltimo"
        Me.CmdUltimo.Size = New System.Drawing.Size(52, 38)
        Me.CmdUltimo.TabIndex = 10
        Me.CmdUltimo.UseVisualStyleBackColor = True
        '
        'CmdEditar
        '
        Me.CmdEditar.Image = Global.SAE.My.Resources.Resources.editar
        Me.CmdEditar.Location = New System.Drawing.Point(174, 12)
        Me.CmdEditar.Name = "CmdEditar"
        Me.CmdEditar.Size = New System.Drawing.Size(52, 38)
        Me.CmdEditar.TabIndex = 3
        Me.CmdEditar.UseVisualStyleBackColor = True
        '
        'CmdListo
        '
        Me.CmdListo.Image = Global.SAE.My.Resources.Resources.guardar
        Me.CmdListo.Location = New System.Drawing.Point(68, 12)
        Me.CmdListo.Name = "CmdListo"
        Me.CmdListo.Size = New System.Drawing.Size(52, 38)
        Me.CmdListo.TabIndex = 1
        Me.CmdListo.UseVisualStyleBackColor = True
        '
        'CmdSiguiente
        '
        Me.CmdSiguiente.Image = CType(resources.GetObject("CmdSiguiente.Image"), System.Drawing.Image)
        Me.CmdSiguiente.Location = New System.Drawing.Point(521, 12)
        Me.CmdSiguiente.Name = "CmdSiguiente"
        Me.CmdSiguiente.Size = New System.Drawing.Size(52, 38)
        Me.CmdSiguiente.TabIndex = 9
        Me.CmdSiguiente.UseVisualStyleBackColor = True
        '
        'CmdAtras
        '
        Me.CmdAtras.Image = CType(resources.GetObject("CmdAtras.Image"), System.Drawing.Image)
        Me.CmdAtras.Location = New System.Drawing.Point(470, 12)
        Me.CmdAtras.Name = "CmdAtras"
        Me.CmdAtras.Size = New System.Drawing.Size(52, 38)
        Me.CmdAtras.TabIndex = 8
        Me.CmdAtras.Text = " "
        Me.CmdAtras.UseVisualStyleBackColor = True
        '
        'CmdSalir
        '
        Me.CmdSalir.Image = Global.SAE.My.Resources.Resources.salir
        Me.CmdSalir.Location = New System.Drawing.Point(333, 12)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(52, 38)
        Me.CmdSalir.TabIndex = 6
        Me.CmdSalir.UseVisualStyleBackColor = True
        '
        'CmdCancelar
        '
        Me.CmdCancelar.Image = Global.SAE.My.Resources.Resources.cancelar
        Me.CmdCancelar.Location = New System.Drawing.Point(121, 12)
        Me.CmdCancelar.Name = "CmdCancelar"
        Me.CmdCancelar.Size = New System.Drawing.Size(52, 38)
        Me.CmdCancelar.TabIndex = 2
        Me.CmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdPrimero
        '
        Me.CmdPrimero.Image = CType(resources.GetObject("CmdPrimero.Image"), System.Drawing.Image)
        Me.CmdPrimero.Location = New System.Drawing.Point(419, 12)
        Me.CmdPrimero.Name = "CmdPrimero"
        Me.CmdPrimero.Size = New System.Drawing.Size(52, 38)
        Me.CmdPrimero.TabIndex = 7
        Me.CmdPrimero.UseVisualStyleBackColor = True
        '
        'CmdEliminar
        '
        Me.CmdEliminar.Image = Global.SAE.My.Resources.Resources.eliminar
        Me.CmdEliminar.Location = New System.Drawing.Point(227, 12)
        Me.CmdEliminar.Name = "CmdEliminar"
        Me.CmdEliminar.Size = New System.Drawing.Size(52, 38)
        Me.CmdEliminar.TabIndex = 4
        Me.CmdEliminar.UseVisualStyleBackColor = True
        '
        'CmdMostrar
        '
        Me.CmdMostrar.Enabled = False
        Me.CmdMostrar.Image = Global.SAE.My.Resources.Resources.DataTables
        Me.CmdMostrar.Location = New System.Drawing.Point(280, 12)
        Me.CmdMostrar.Name = "CmdMostrar"
        Me.CmdMostrar.Size = New System.Drawing.Size(52, 38)
        Me.CmdMostrar.TabIndex = 5
        Me.CmdMostrar.UseVisualStyleBackColor = True
        '
        'cmdNuevo
        '
        Me.cmdNuevo.Image = Global.SAE.My.Resources.Resources.nuevo
        Me.cmdNuevo.Location = New System.Drawing.Point(16, 12)
        Me.cmdNuevo.Name = "cmdNuevo"
        Me.cmdNuevo.Size = New System.Drawing.Size(52, 38)
        Me.cmdNuevo.TabIndex = 0
        Me.cmdNuevo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 122
        Me.Label1.Text = "Tipo"
        '
        'grupoctas
        '
        Me.grupoctas.Controls.Add(Me.txtctatotal)
        Me.grupoctas.Controls.Add(Me.txtcentrocosto_NOM)
        Me.grupoctas.Controls.Add(Me.txtobserbaciones)
        Me.grupoctas.Controls.Add(Me.txtret)
        Me.grupoctas.Controls.Add(Me.txtiva)
        Me.grupoctas.Controls.Add(Me.txtdescuento)
        Me.grupoctas.Controls.Add(Me.txtsubtotal)
        Me.grupoctas.Controls.Add(Me.txtctasub)
        Me.grupoctas.Controls.Add(Me.txtvalorret)
        Me.grupoctas.Controls.Add(Me.txtctaret)
        Me.grupoctas.Controls.Add(Me.Label22)
        Me.grupoctas.Controls.Add(Me.Label23)
        Me.grupoctas.Controls.Add(Me.txttotal)
        Me.grupoctas.Controls.Add(Me.cmdobservaciones)
        Me.grupoctas.Controls.Add(Me.Label19)
        Me.grupoctas.Controls.Add(Me.cbaprobado)
        Me.grupoctas.Controls.Add(Me.Label4)
        Me.grupoctas.Controls.Add(Me.lbusuario)
        Me.grupoctas.Controls.Add(Me.valoriva)
        Me.grupoctas.Controls.Add(Me.txtvmto)
        Me.grupoctas.Controls.Add(Me.valordes)
        Me.grupoctas.Controls.Add(Me.Label17)
        Me.grupoctas.Controls.Add(Me.txtcuentaiva)
        Me.grupoctas.Controls.Add(Me.txtcentrocosto)
        Me.grupoctas.Controls.Add(Me.Label16)
        Me.grupoctas.Controls.Add(Me.txtcuentadesc)
        Me.grupoctas.Controls.Add(Me.Label12)
        Me.grupoctas.Controls.Add(Me.Label10)
        Me.grupoctas.Controls.Add(Me.Label9)
        Me.grupoctas.Controls.Add(Me.Label8)
        Me.grupoctas.Controls.Add(Me.Label7)
        Me.grupoctas.Controls.Add(Me.Label15)
        Me.grupoctas.Controls.Add(Me.Label14)
        Me.grupoctas.Controls.Add(Me.Label11)
        Me.grupoctas.Location = New System.Drawing.Point(12, 346)
        Me.grupoctas.Name = "grupoctas"
        Me.grupoctas.Size = New System.Drawing.Size(644, 178)
        Me.grupoctas.TabIndex = 3
        Me.grupoctas.TabStop = False
        '
        'txtctatotal
        '
        Me.txtctatotal.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtctatotal.Location = New System.Drawing.Point(266, 144)
        Me.txtctatotal.Name = "txtctatotal"
        Me.txtctatotal.ShortcutsEnabled = False
        Me.txtctatotal.Size = New System.Drawing.Size(96, 20)
        Me.txtctatotal.TabIndex = 198
        '
        'txtcentrocosto_NOM
        '
        Me.txtcentrocosto_NOM.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcentrocosto_NOM.Enabled = False
        Me.txtcentrocosto_NOM.Location = New System.Drawing.Point(514, 48)
        Me.txtcentrocosto_NOM.Name = "txtcentrocosto_NOM"
        Me.txtcentrocosto_NOM.ShortcutsEnabled = False
        Me.txtcentrocosto_NOM.Size = New System.Drawing.Size(124, 20)
        Me.txtcentrocosto_NOM.TabIndex = 197
        Me.txtcentrocosto_NOM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtobserbaciones
        '
        Me.txtobserbaciones.Location = New System.Drawing.Point(537, 148)
        Me.txtobserbaciones.Name = "txtobserbaciones"
        Me.txtobserbaciones.Size = New System.Drawing.Size(103, 20)
        Me.txtobserbaciones.TabIndex = 196
        Me.txtobserbaciones.Visible = False
        '
        'txtret
        '
        Me.txtret.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtret.Location = New System.Drawing.Point(136, 101)
        Me.txtret.Name = "txtret"
        Me.txtret.ShortcutsEnabled = False
        Me.txtret.Size = New System.Drawing.Size(119, 20)
        Me.txtret.TabIndex = 28
        Me.txtret.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtiva
        '
        Me.txtiva.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtiva.Location = New System.Drawing.Point(136, 77)
        Me.txtiva.Name = "txtiva"
        Me.txtiva.ShortcutsEnabled = False
        Me.txtiva.Size = New System.Drawing.Size(119, 20)
        Me.txtiva.TabIndex = 25
        Me.txtiva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtdescuento
        '
        Me.txtdescuento.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtdescuento.Location = New System.Drawing.Point(136, 52)
        Me.txtdescuento.Name = "txtdescuento"
        Me.txtdescuento.ShortcutsEnabled = False
        Me.txtdescuento.Size = New System.Drawing.Size(119, 20)
        Me.txtdescuento.TabIndex = 22
        Me.txtdescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtsubtotal
        '
        Me.txtsubtotal.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtsubtotal.Location = New System.Drawing.Point(136, 27)
        Me.txtsubtotal.Name = "txtsubtotal"
        Me.txtsubtotal.ShortcutsEnabled = False
        Me.txtsubtotal.Size = New System.Drawing.Size(119, 20)
        Me.txtsubtotal.TabIndex = 19
        Me.txtsubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtctasub
        '
        Me.txtctasub.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtctasub.Location = New System.Drawing.Point(266, 27)
        Me.txtctasub.Name = "txtctasub"
        Me.txtctasub.ShortcutsEnabled = False
        Me.txtctasub.Size = New System.Drawing.Size(96, 20)
        Me.txtctasub.TabIndex = 20
        '
        'txtvalorret
        '
        Me.txtvalorret.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtvalorret.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvalorret.ForeColor = System.Drawing.Color.SteelBlue
        Me.txtvalorret.Location = New System.Drawing.Point(70, 99)
        Me.txtvalorret.MaxLength = 5
        Me.txtvalorret.Name = "txtvalorret"
        Me.txtvalorret.ShortcutsEnabled = False
        Me.txtvalorret.Size = New System.Drawing.Size(42, 20)
        Me.txtvalorret.TabIndex = 27
        Me.txtvalorret.Text = "0,00"
        Me.txtvalorret.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtctaret
        '
        Me.txtctaret.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtctaret.Location = New System.Drawing.Point(266, 101)
        Me.txtctaret.Name = "txtctaret"
        Me.txtctaret.ShortcutsEnabled = False
        Me.txtctaret.Size = New System.Drawing.Size(96, 20)
        Me.txtctaret.TabIndex = 29
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label22.Location = New System.Drawing.Point(2, 102)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(65, 13)
        Me.Label22.TabIndex = 192
        Me.Label22.Text = "Retención"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label23.Location = New System.Drawing.Point(114, 103)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(16, 13)
        Me.Label23.TabIndex = 195
        Me.Label23.Text = "%"
        '
        'txttotal
        '
        Me.txttotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txttotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotal.ForeColor = System.Drawing.Color.Red
        Me.txttotal.Location = New System.Drawing.Point(133, 143)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.Size = New System.Drawing.Size(119, 20)
        Me.txttotal.TabIndex = 27
        Me.txttotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdobservaciones
        '
        Me.cmdobservaciones.BackColor = System.Drawing.SystemColors.Control
        Me.cmdobservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdobservaciones.Location = New System.Drawing.Point(543, 83)
        Me.cmdobservaciones.Name = "cmdobservaciones"
        Me.cmdobservaciones.Size = New System.Drawing.Size(76, 30)
        Me.cmdobservaciones.TabIndex = 32
        Me.cmdobservaciones.Text = "&Observaciones"
        Me.cmdobservaciones.UseVisualStyleBackColor = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label19.Location = New System.Drawing.Point(374, 102)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(77, 13)
        Me.Label19.TabIndex = 186
        Me.Label19.Text = "Estado Doc."
        '
        'cbaprobado
        '
        Me.cbaprobado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbaprobado.Enabled = False
        Me.cbaprobado.FormattingEnabled = True
        Me.cbaprobado.Items.AddRange(New Object() {"", "AP"})
        Me.cbaprobado.Location = New System.Drawing.Point(465, 99)
        Me.cbaprobado.Name = "cbaprobado"
        Me.cbaprobado.Size = New System.Drawing.Size(43, 21)
        Me.cbaprobado.TabIndex = 33
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(373, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 13)
        Me.Label4.TabIndex = 183
        Me.Label4.Text = "Atendido por el usuario:"
        '
        'lbusuario
        '
        Me.lbusuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbusuario.Location = New System.Drawing.Point(489, 125)
        Me.lbusuario.Name = "lbusuario"
        Me.lbusuario.Size = New System.Drawing.Size(151, 20)
        Me.lbusuario.TabIndex = 182
        Me.lbusuario.Text = "usuario"
        '
        'valoriva
        '
        Me.valoriva.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.valoriva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.valoriva.ForeColor = System.Drawing.Color.SteelBlue
        Me.valoriva.Location = New System.Drawing.Point(70, 75)
        Me.valoriva.MaxLength = 5
        Me.valoriva.Name = "valoriva"
        Me.valoriva.ShortcutsEnabled = False
        Me.valoriva.Size = New System.Drawing.Size(42, 20)
        Me.valoriva.TabIndex = 24
        Me.valoriva.Text = "0,00"
        Me.valoriva.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtvmto
        '
        Me.txtvmto.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtvmto.Location = New System.Drawing.Point(464, 72)
        Me.txtvmto.MaxLength = 4
        Me.txtvmto.Name = "txtvmto"
        Me.txtvmto.ShortcutsEnabled = False
        Me.txtvmto.Size = New System.Drawing.Size(44, 20)
        Me.txtvmto.TabIndex = 31
        Me.txtvmto.Text = "10"
        Me.txtvmto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'valordes
        '
        Me.valordes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.valordes.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.valordes.Location = New System.Drawing.Point(70, 49)
        Me.valordes.MaxLength = 5
        Me.valordes.Name = "valordes"
        Me.valordes.ShortcutsEnabled = False
        Me.valordes.Size = New System.Drawing.Size(42, 20)
        Me.valordes.TabIndex = 21
        Me.valordes.Text = "0,00"
        Me.valordes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label17.Location = New System.Drawing.Point(373, 77)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(86, 13)
        Me.Label17.TabIndex = 179
        Me.Label17.Text = "V/mto en dias"
        '
        'txtcuentaiva
        '
        Me.txtcuentaiva.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcuentaiva.Location = New System.Drawing.Point(267, 78)
        Me.txtcuentaiva.Name = "txtcuentaiva"
        Me.txtcuentaiva.ShortcutsEnabled = False
        Me.txtcuentaiva.Size = New System.Drawing.Size(96, 20)
        Me.txtcuentaiva.TabIndex = 26
        '
        'txtcentrocosto
        '
        Me.txtcentrocosto.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcentrocosto.Location = New System.Drawing.Point(450, 48)
        Me.txtcentrocosto.Name = "txtcentrocosto"
        Me.txtcentrocosto.ShortcutsEnabled = False
        Me.txtcentrocosto.Size = New System.Drawing.Size(58, 20)
        Me.txtcentrocosto.TabIndex = 30
        Me.txtcentrocosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label16.Location = New System.Drawing.Point(367, 52)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(85, 13)
        Me.Label16.TabIndex = 177
        Me.Label16.Text = "Centro costos"
        '
        'txtcuentadesc
        '
        Me.txtcuentadesc.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcuentadesc.Location = New System.Drawing.Point(267, 52)
        Me.txtcuentadesc.Name = "txtcuentadesc"
        Me.txtcuentadesc.ShortcutsEnabled = False
        Me.txtcuentadesc.Size = New System.Drawing.Size(96, 20)
        Me.txtcuentadesc.TabIndex = 23
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label12.Location = New System.Drawing.Point(374, 26)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(218, 13)
        Me.Label12.TabIndex = 169
        Me.Label12.Text = "Cuentas (doble clic para seleccionar)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Crimson
        Me.Label10.Location = New System.Drawing.Point(1, 140)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 20)
        Me.Label10.TabIndex = 167
        Me.Label10.Text = "TOTAL"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label9.Location = New System.Drawing.Point(2, 78)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 13)
        Me.Label9.TabIndex = 166
        Me.Label9.Text = "I.V.A"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.Label8.Location = New System.Drawing.Point(2, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 13)
        Me.Label8.TabIndex = 165
        Me.Label8.Text = "Descuento"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Green
        Me.Label7.Location = New System.Drawing.Point(2, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 164
        Me.Label7.Text = "Sub Total"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label15.Location = New System.Drawing.Point(114, 79)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(16, 13)
        Me.Label15.TabIndex = 175
        Me.Label15.Text = "%"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.Label14.Location = New System.Drawing.Point(114, 53)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(21, 16)
        Me.Label14.TabIndex = 173
        Me.Label14.Text = "%"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label11.Location = New System.Drawing.Point(114, 94)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(165, 42)
        Me.Label11.TabIndex = 168
        Me.Label11.Text = "_______"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtdetalle)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.txtcodeudor)
        Me.GroupBox2.Controls.Add(Me.txtcod)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtvendedor)
        Me.GroupBox2.Controls.Add(Me.txtnitv)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtcliente)
        Me.GroupBox2.Controls.Add(Me.txtnitc)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 183)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(509, 157)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'txtdetalle
        '
        Me.txtdetalle.BackColor = System.Drawing.Color.White
        Me.txtdetalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdetalle.Location = New System.Drawing.Point(111, 106)
        Me.txtdetalle.Multiline = True
        Me.txtdetalle.Name = "txtdetalle"
        Me.txtdetalle.Size = New System.Drawing.Size(392, 45)
        Me.txtdetalle.TabIndex = 18
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 104)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(79, 13)
        Me.Label21.TabIndex = 183
        Me.Label21.Text = "Detalle Factura"
        '
        'txtcodeudor
        '
        Me.txtcodeudor.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcodeudor.Enabled = False
        Me.txtcodeudor.Location = New System.Drawing.Point(237, 81)
        Me.txtcodeudor.Name = "txtcodeudor"
        Me.txtcodeudor.ReadOnly = True
        Me.txtcodeudor.Size = New System.Drawing.Size(267, 20)
        Me.txtcodeudor.TabIndex = 177
        '
        'txtcod
        '
        Me.txtcod.Location = New System.Drawing.Point(109, 81)
        Me.txtcod.Name = "txtcod"
        Me.txtcod.ShortcutsEnabled = False
        Me.txtcod.Size = New System.Drawing.Size(119, 20)
        Me.txtcod.TabIndex = 17
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(5, 84)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(107, 13)
        Me.Label13.TabIndex = 181
        Me.Label13.Text = "Nit/Cedula Codeudor"
        '
        'txtvendedor
        '
        Me.txtvendedor.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtvendedor.Enabled = False
        Me.txtvendedor.Location = New System.Drawing.Point(237, 55)
        Me.txtvendedor.Name = "txtvendedor"
        Me.txtvendedor.ReadOnly = True
        Me.txtvendedor.Size = New System.Drawing.Size(267, 20)
        Me.txtvendedor.TabIndex = 175
        '
        'txtnitv
        '
        Me.txtnitv.Location = New System.Drawing.Point(109, 55)
        Me.txtnitv.Name = "txtnitv"
        Me.txtnitv.ShortcutsEnabled = False
        Me.txtnitv.Size = New System.Drawing.Size(119, 20)
        Me.txtnitv.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 13)
        Me.Label6.TabIndex = 180
        Me.Label6.Text = "Nit/Cedula Vendedor"
        '
        'txtcliente
        '
        Me.txtcliente.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcliente.Enabled = False
        Me.txtcliente.Location = New System.Drawing.Point(237, 29)
        Me.txtcliente.Name = "txtcliente"
        Me.txtcliente.ReadOnly = True
        Me.txtcliente.Size = New System.Drawing.Size(267, 20)
        Me.txtcliente.TabIndex = 173
        '
        'txtnitc
        '
        Me.txtnitc.Location = New System.Drawing.Point(109, 29)
        Me.txtnitc.Name = "txtnitc"
        Me.txtnitc.ShortcutsEnabled = False
        Me.txtnitc.Size = New System.Drawing.Size(119, 20)
        Me.txtnitc.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 13)
        Me.Label5.TabIndex = 179
        Me.Label5.Text = "Nit/Cedula Cliente"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txttipo2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.txtnumfac)
        Me.GroupBox3.Controls.Add(Me.lbhora)
        Me.GroupBox3.Controls.Add(Me.txttipo)
        Me.GroupBox3.Controls.Add(Me.txtfecha)
        Me.GroupBox3.Location = New System.Drawing.Point(11, 88)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(645, 89)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmdPrint)
        Me.GroupBox4.Controls.Add(Me.CmdCambiarPeriodo)
        Me.GroupBox4.Location = New System.Drawing.Point(528, 187)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(127, 152)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Imprimir / Cambiar Periodo"
        '
        'cmdPrint
        '
        Me.cmdPrint.BackColor = System.Drawing.Color.White
        Me.cmdPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrint.Image = Global.SAE.My.Resources.Resources.impresora
        Me.cmdPrint.Location = New System.Drawing.Point(31, 26)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(63, 57)
        Me.cmdPrint.TabIndex = 34
        Me.cmdPrint.UseVisualStyleBackColor = False
        '
        'CmdCambiarPeriodo
        '
        Me.CmdCambiarPeriodo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CmdCambiarPeriodo.Image = Global.SAE.My.Resources.Resources.abriperiodo1
        Me.CmdCambiarPeriodo.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.CmdCambiarPeriodo.Location = New System.Drawing.Point(32, 83)
        Me.CmdCambiarPeriodo.Name = "CmdCambiarPeriodo"
        Me.CmdCambiarPeriodo.Size = New System.Drawing.Size(63, 53)
        Me.CmdCambiarPeriodo.TabIndex = 35
        Me.CmdCambiarPeriodo.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.CmdCambiarPeriodo.UseVisualStyleBackColor = False
        '
        'FrmFacturasPendientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(670, 534)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.grupoctas)
        Me.Controls.Add(Me.lbdocajuste)
        Me.Controls.Add(Me.lbestado)
        Me.Controls.Add(Me.lbnumero)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmFacturasPendientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Facturas Pendientes de Pago..."
        Me.GroupBox1.ResumeLayout(False)
        Me.grupoctas.ResumeLayout(False)
        Me.grupoctas.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbdocajuste As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lbhora As System.Windows.Forms.Label
    Friend WithEvents txtfecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents txttipo As System.Windows.Forms.ComboBox
    Friend WithEvents lbestado As System.Windows.Forms.Label
    Friend WithEvents lbnumero As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtnumfac As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txttipo2 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdUltimo As System.Windows.Forms.Button
    Friend WithEvents CmdEditar As System.Windows.Forms.Button
    Friend WithEvents CmdListo As System.Windows.Forms.Button
    Friend WithEvents CmdSiguiente As System.Windows.Forms.Button
    Friend WithEvents CmdAtras As System.Windows.Forms.Button
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents CmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdPrimero As System.Windows.Forms.Button
    Friend WithEvents CmdEliminar As System.Windows.Forms.Button
    Friend WithEvents CmdMostrar As System.Windows.Forms.Button
    Friend WithEvents cmdNuevo As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grupoctas As System.Windows.Forms.GroupBox
    Friend WithEvents txttotal As System.Windows.Forms.Label
    Friend WithEvents cmdobservaciones As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cbaprobado As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbusuario As System.Windows.Forms.Label
    Friend WithEvents valoriva As System.Windows.Forms.TextBox
    Friend WithEvents txtvmto As System.Windows.Forms.TextBox
    Friend WithEvents valordes As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtcuentaiva As System.Windows.Forms.TextBox
    Friend WithEvents txtcentrocosto As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtcuentadesc As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtvalorret As System.Windows.Forms.TextBox
    Friend WithEvents txtctaret As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtctasub As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdCambiarPeriodo As System.Windows.Forms.Button
    Friend WithEvents txtcodeudor As System.Windows.Forms.TextBox
    Friend WithEvents txtcod As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents txtvendedor As System.Windows.Forms.TextBox
    Friend WithEvents txtnitv As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtcliente As System.Windows.Forms.TextBox
    Friend WithEvents txtnitc As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtdetalle As System.Windows.Forms.TextBox
    Friend WithEvents txtret As System.Windows.Forms.TextBox
    Friend WithEvents txtiva As System.Windows.Forms.TextBox
    Friend WithEvents txtdescuento As System.Windows.Forms.TextBox
    Friend WithEvents txtsubtotal As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtobserbaciones As System.Windows.Forms.TextBox
    Friend WithEvents txtcentrocosto_NOM As System.Windows.Forms.TextBox
    Friend WithEvents txtctatotal As System.Windows.Forms.TextBox
End Class
