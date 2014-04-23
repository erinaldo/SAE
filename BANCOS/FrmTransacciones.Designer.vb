<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTransacciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTransacciones))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.gdoc = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtmonto = New System.Windows.Forms.TextBox
        Me.Lbper = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtperiodo = New System.Windows.Forms.TextBox
        Me.txtdia = New System.Windows.Forms.TextBox
        Me.TxtNumero = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtDoc = New System.Windows.Forms.TextBox
        Me.TxtDocumento = New System.Windows.Forms.TextBox
        Me.gdestino = New System.Windows.Forms.GroupBox
        Me.txtcheque2 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.LABELDV2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtnomcta2 = New System.Windows.Forms.TextBox
        Me.txtnit2 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtnum2 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtbanco2 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtcuenta2 = New System.Windows.Forms.TextBox
        Me.gorigen = New System.Windows.Forms.GroupBox
        Me.txtcheque = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.LABELDV = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.txtnomcta = New System.Windows.Forms.TextBox
        Me.txtnit = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtnum = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtbanco = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtcuenta = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.CmdUltimo = New System.Windows.Forms.Button
        Me.cmdEdit = New System.Windows.Forms.Button
        Me.CmdListo = New System.Windows.Forms.Button
        Me.CmdSiguiente = New System.Windows.Forms.Button
        Me.CmdAtras = New System.Windows.Forms.Button
        Me.CmdSalir = New System.Windows.Forms.Button
        Me.CmdCancelar = New System.Windows.Forms.Button
        Me.CmdPrimero = New System.Windows.Forms.Button
        Me.CmdEliminar = New System.Windows.Forms.Button
        Me.CmdMostrar = New System.Windows.Forms.Button
        Me.CmdNuevo = New System.Windows.Forms.Button
        Me.lbnroobs = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.lbestado = New System.Windows.Forms.Label
        Me.txtnomctab = New System.Windows.Forms.Label
        Me.txtnomctab2 = New System.Windows.Forms.Label
        Me.lbdoc = New System.Windows.Forms.Label
        Me.cmdprint = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.gdoc.SuspendLayout()
        Me.gdestino.SuspendLayout()
        Me.gorigen.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.gdoc)
        Me.GroupBox1.Controls.Add(Me.gdestino)
        Me.GroupBox1.Controls.Add(Me.gorigen)
        Me.GroupBox1.Location = New System.Drawing.Point(6, -2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(793, 445)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'gdoc
        '
        Me.gdoc.Controls.Add(Me.lbdoc)
        Me.gdoc.Controls.Add(Me.Label12)
        Me.gdoc.Controls.Add(Me.txtmonto)
        Me.gdoc.Controls.Add(Me.Lbper)
        Me.gdoc.Controls.Add(Me.Label9)
        Me.gdoc.Controls.Add(Me.txtperiodo)
        Me.gdoc.Controls.Add(Me.txtdia)
        Me.gdoc.Controls.Add(Me.TxtNumero)
        Me.gdoc.Controls.Add(Me.Label11)
        Me.gdoc.Controls.Add(Me.Label10)
        Me.gdoc.Controls.Add(Me.txtDoc)
        Me.gdoc.Controls.Add(Me.TxtDocumento)
        Me.gdoc.Location = New System.Drawing.Point(13, 322)
        Me.gdoc.Name = "gdoc"
        Me.gdoc.Size = New System.Drawing.Size(768, 113)
        Me.gdoc.TabIndex = 3
        Me.gdoc.TabStop = False
        Me.gdoc.Text = "Documento Contable"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label12.Location = New System.Drawing.Point(16, 89)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(261, 13)
        Me.Label12.TabIndex = 54
        Me.Label12.Text = "MONTO DE LA TRANSACCIÓN EN PESOS $"
        '
        'txtmonto
        '
        Me.txtmonto.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtmonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmonto.ForeColor = System.Drawing.Color.ForestGreen
        Me.txtmonto.Location = New System.Drawing.Point(291, 86)
        Me.txtmonto.Name = "txtmonto"
        Me.txtmonto.Size = New System.Drawing.Size(183, 20)
        Me.txtmonto.TabIndex = 9
        Me.txtmonto.Text = "0"
        Me.txtmonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Lbper
        '
        Me.Lbper.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbper.Location = New System.Drawing.Point(132, 58)
        Me.Lbper.Name = "Lbper"
        Me.Lbper.Size = New System.Drawing.Size(96, 15)
        Me.Lbper.TabIndex = 52
        Me.Lbper.Text = "0000-00-"
        Me.Lbper.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 56)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(115, 16)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "Nro Documento"
        '
        'txtperiodo
        '
        Me.txtperiodo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtperiodo.Enabled = False
        Me.txtperiodo.Location = New System.Drawing.Point(519, 54)
        Me.txtperiodo.Name = "txtperiodo"
        Me.txtperiodo.ReadOnly = True
        Me.txtperiodo.Size = New System.Drawing.Size(54, 20)
        Me.txtperiodo.TabIndex = 49
        Me.txtperiodo.Text = "/00/0000"
        '
        'txtdia
        '
        Me.txtdia.Location = New System.Drawing.Point(492, 54)
        Me.txtdia.MaxLength = 2
        Me.txtdia.Name = "txtdia"
        Me.txtdia.Size = New System.Drawing.Size(29, 20)
        Me.txtdia.TabIndex = 2
        Me.txtdia.Text = "00"
        Me.txtdia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtNumero
        '
        Me.TxtNumero.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TxtNumero.Location = New System.Drawing.Point(228, 56)
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Size = New System.Drawing.Size(99, 20)
        Me.TxtNumero.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(366, 59)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(126, 13)
        Me.Label11.TabIndex = 50
        Me.Label11.Text = "Fecha (dd/mm/aaaa)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(14, 27)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(144, 16)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "Tipo de Documento"
        '
        'txtDoc
        '
        Me.txtDoc.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtDoc.Enabled = False
        Me.txtDoc.Location = New System.Drawing.Point(228, 30)
        Me.txtDoc.Name = "txtDoc"
        Me.txtDoc.ReadOnly = True
        Me.txtDoc.Size = New System.Drawing.Size(375, 20)
        Me.txtDoc.TabIndex = 45
        '
        'TxtDocumento
        '
        Me.TxtDocumento.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TxtDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDocumento.Enabled = False
        Me.TxtDocumento.Location = New System.Drawing.Point(177, 30)
        Me.TxtDocumento.MaxLength = 4
        Me.TxtDocumento.Name = "TxtDocumento"
        Me.TxtDocumento.ReadOnly = True
        Me.TxtDocumento.Size = New System.Drawing.Size(45, 20)
        Me.TxtDocumento.TabIndex = 0
        '
        'gdestino
        '
        Me.gdestino.Controls.Add(Me.txtnomctab2)
        Me.gdestino.Controls.Add(Me.txtcheque2)
        Me.gdestino.Controls.Add(Me.Label13)
        Me.gdestino.Controls.Add(Me.LABELDV2)
        Me.gdestino.Controls.Add(Me.Label4)
        Me.gdestino.Controls.Add(Me.txtnomcta2)
        Me.gdestino.Controls.Add(Me.txtnit2)
        Me.gdestino.Controls.Add(Me.Label6)
        Me.gdestino.Controls.Add(Me.txtnum2)
        Me.gdestino.Controls.Add(Me.Label7)
        Me.gdestino.Controls.Add(Me.txtbanco2)
        Me.gdestino.Controls.Add(Me.Label8)
        Me.gdestino.Controls.Add(Me.txtcuenta2)
        Me.gdestino.Location = New System.Drawing.Point(12, 164)
        Me.gdestino.Name = "gdestino"
        Me.gdestino.Size = New System.Drawing.Size(770, 152)
        Me.gdestino.TabIndex = 2
        Me.gdestino.TabStop = False
        Me.gdestino.Text = "A la Cuenta  (Cuenta Destino)"
        '
        'txtcheque2
        '
        Me.txtcheque2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcheque2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcheque2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcheque2.ForeColor = System.Drawing.Color.ForestGreen
        Me.txtcheque2.Location = New System.Drawing.Point(277, 117)
        Me.txtcheque2.MaxLength = 20
        Me.txtcheque2.Name = "txtcheque2"
        Me.txtcheque2.Size = New System.Drawing.Size(183, 20)
        Me.txtcheque2.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label13.Location = New System.Drawing.Point(12, 120)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(242, 13)
        Me.Label13.TabIndex = 135
        Me.Label13.Text = "NUMERO DE TRANSACCION O CHEQUE"
        '
        'LABELDV2
        '
        Me.LABELDV2.AutoSize = True
        Me.LABELDV2.BackColor = System.Drawing.Color.Transparent
        Me.LABELDV2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LABELDV2.ForeColor = System.Drawing.Color.Red
        Me.LABELDV2.Location = New System.Drawing.Point(226, 89)
        Me.LABELDV2.Name = "LABELDV2"
        Me.LABELDV2.Size = New System.Drawing.Size(16, 16)
        Me.LABELDV2.TabIndex = 133
        Me.LABELDV2.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(202, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 16)
        Me.Label4.TabIndex = 132
        Me.Label4.Text = "DV"
        '
        'txtnomcta2
        '
        Me.txtnomcta2.BackColor = System.Drawing.Color.White
        Me.txtnomcta2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnomcta2.Enabled = False
        Me.txtnomcta2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnomcta2.ForeColor = System.Drawing.Color.ForestGreen
        Me.txtnomcta2.Location = New System.Drawing.Point(273, 55)
        Me.txtnomcta2.MaxLength = 70
        Me.txtnomcta2.Name = "txtnomcta2"
        Me.txtnomcta2.ShortcutsEnabled = False
        Me.txtnomcta2.Size = New System.Drawing.Size(485, 21)
        Me.txtnomcta2.TabIndex = 1
        '
        'txtnit2
        '
        Me.txtnit2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnit2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnit2.Enabled = False
        Me.txtnit2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnit2.ForeColor = System.Drawing.Color.ForestGreen
        Me.txtnit2.Location = New System.Drawing.Point(76, 86)
        Me.txtnit2.MaxLength = 15
        Me.txtnit2.Name = "txtnit2"
        Me.txtnit2.ShortcutsEnabled = False
        Me.txtnit2.Size = New System.Drawing.Size(121, 21)
        Me.txtnit2.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 89)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 16)
        Me.Label6.TabIndex = 126
        Me.Label6.Text = "Nit Banco"
        '
        'txtnum2
        '
        Me.txtnum2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnum2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnum2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnum2.ForeColor = System.Drawing.Color.ForestGreen
        Me.txtnum2.Location = New System.Drawing.Point(122, 19)
        Me.txtnum2.MaxLength = 30
        Me.txtnum2.Name = "txtnum2"
        Me.txtnum2.ShortcutsEnabled = False
        Me.txtnum2.Size = New System.Drawing.Size(151, 21)
        Me.txtnum2.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 16)
        Me.Label7.TabIndex = 122
        Me.Label7.Text = "Número Cuenta"
        '
        'txtbanco2
        '
        Me.txtbanco2.BackColor = System.Drawing.Color.White
        Me.txtbanco2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtbanco2.Enabled = False
        Me.txtbanco2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbanco2.ForeColor = System.Drawing.Color.ForestGreen
        Me.txtbanco2.Location = New System.Drawing.Point(249, 86)
        Me.txtbanco2.MaxLength = 180
        Me.txtbanco2.Name = "txtbanco2"
        Me.txtbanco2.ShortcutsEnabled = False
        Me.txtbanco2.Size = New System.Drawing.Size(507, 21)
        Me.txtbanco2.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 58)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 16)
        Me.Label8.TabIndex = 119
        Me.Label8.Text = "Cuenta Contable"
        '
        'txtcuenta2
        '
        Me.txtcuenta2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcuenta2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcuenta2.Enabled = False
        Me.txtcuenta2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcuenta2.ForeColor = System.Drawing.Color.ForestGreen
        Me.txtcuenta2.Location = New System.Drawing.Point(122, 55)
        Me.txtcuenta2.MaxLength = 15
        Me.txtcuenta2.Name = "txtcuenta2"
        Me.txtcuenta2.ShortcutsEnabled = False
        Me.txtcuenta2.Size = New System.Drawing.Size(151, 21)
        Me.txtcuenta2.TabIndex = 0
        '
        'gorigen
        '
        Me.gorigen.Controls.Add(Me.txtnomctab)
        Me.gorigen.Controls.Add(Me.txtcheque)
        Me.gorigen.Controls.Add(Me.Label3)
        Me.gorigen.Controls.Add(Me.LABELDV)
        Me.gorigen.Controls.Add(Me.Label26)
        Me.gorigen.Controls.Add(Me.txtnomcta)
        Me.gorigen.Controls.Add(Me.txtnit)
        Me.gorigen.Controls.Add(Me.Label5)
        Me.gorigen.Controls.Add(Me.txtnum)
        Me.gorigen.Controls.Add(Me.Label2)
        Me.gorigen.Controls.Add(Me.txtbanco)
        Me.gorigen.Controls.Add(Me.Label1)
        Me.gorigen.Controls.Add(Me.txtcuenta)
        Me.gorigen.Location = New System.Drawing.Point(12, 16)
        Me.gorigen.Name = "gorigen"
        Me.gorigen.Size = New System.Drawing.Size(770, 142)
        Me.gorigen.TabIndex = 1
        Me.gorigen.TabStop = False
        Me.gorigen.Text = "Translado de la Cuenta  (Cuenta Origen)"
        '
        'txtcheque
        '
        Me.txtcheque.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcheque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcheque.ForeColor = System.Drawing.Color.ForestGreen
        Me.txtcheque.Location = New System.Drawing.Point(275, 115)
        Me.txtcheque.MaxLength = 20
        Me.txtcheque.Name = "txtcheque"
        Me.txtcheque.Size = New System.Drawing.Size(183, 20)
        Me.txtcheque.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label3.Location = New System.Drawing.Point(14, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(242, 13)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "NUMERO DE TRANSACCION O CHEQUE"
        '
        'LABELDV
        '
        Me.LABELDV.AutoSize = True
        Me.LABELDV.BackColor = System.Drawing.Color.Transparent
        Me.LABELDV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LABELDV.ForeColor = System.Drawing.Color.Red
        Me.LABELDV.Location = New System.Drawing.Point(226, 89)
        Me.LABELDV.Name = "LABELDV"
        Me.LABELDV.Size = New System.Drawing.Size(16, 16)
        Me.LABELDV.TabIndex = 133
        Me.LABELDV.Text = "0"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(202, 89)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(27, 16)
        Me.Label26.TabIndex = 132
        Me.Label26.Text = "DV"
        '
        'txtnomcta
        '
        Me.txtnomcta.BackColor = System.Drawing.Color.White
        Me.txtnomcta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnomcta.Enabled = False
        Me.txtnomcta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnomcta.ForeColor = System.Drawing.Color.DarkRed
        Me.txtnomcta.Location = New System.Drawing.Point(273, 55)
        Me.txtnomcta.MaxLength = 70
        Me.txtnomcta.Name = "txtnomcta"
        Me.txtnomcta.ShortcutsEnabled = False
        Me.txtnomcta.Size = New System.Drawing.Size(485, 21)
        Me.txtnomcta.TabIndex = 1
        '
        'txtnit
        '
        Me.txtnit.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnit.Enabled = False
        Me.txtnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnit.ForeColor = System.Drawing.Color.DarkRed
        Me.txtnit.Location = New System.Drawing.Point(76, 86)
        Me.txtnit.MaxLength = 15
        Me.txtnit.Name = "txtnit"
        Me.txtnit.ShortcutsEnabled = False
        Me.txtnit.Size = New System.Drawing.Size(121, 21)
        Me.txtnit.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 89)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 16)
        Me.Label5.TabIndex = 126
        Me.Label5.Text = "Nit Banco"
        '
        'txtnum
        '
        Me.txtnum.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnum.ForeColor = System.Drawing.Color.DarkRed
        Me.txtnum.Location = New System.Drawing.Point(122, 19)
        Me.txtnum.MaxLength = 30
        Me.txtnum.Name = "txtnum"
        Me.txtnum.ShortcutsEnabled = False
        Me.txtnum.Size = New System.Drawing.Size(151, 21)
        Me.txtnum.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 16)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "Número Cuenta"
        '
        'txtbanco
        '
        Me.txtbanco.BackColor = System.Drawing.Color.White
        Me.txtbanco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtbanco.Enabled = False
        Me.txtbanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbanco.ForeColor = System.Drawing.Color.DarkRed
        Me.txtbanco.Location = New System.Drawing.Point(249, 86)
        Me.txtbanco.MaxLength = 180
        Me.txtbanco.Name = "txtbanco"
        Me.txtbanco.ShortcutsEnabled = False
        Me.txtbanco.Size = New System.Drawing.Size(507, 21)
        Me.txtbanco.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 16)
        Me.Label1.TabIndex = 119
        Me.Label1.Text = "Cuenta Contable"
        '
        'txtcuenta
        '
        Me.txtcuenta.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcuenta.Enabled = False
        Me.txtcuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcuenta.ForeColor = System.Drawing.Color.DarkRed
        Me.txtcuenta.Location = New System.Drawing.Point(122, 55)
        Me.txtcuenta.MaxLength = 15
        Me.txtcuenta.Name = "txtcuenta"
        Me.txtcuenta.ShortcutsEnabled = False
        Me.txtcuenta.Size = New System.Drawing.Size(151, 21)
        Me.txtcuenta.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmdprint)
        Me.GroupBox4.Controls.Add(Me.CmdUltimo)
        Me.GroupBox4.Controls.Add(Me.cmdEdit)
        Me.GroupBox4.Controls.Add(Me.CmdListo)
        Me.GroupBox4.Controls.Add(Me.CmdSiguiente)
        Me.GroupBox4.Controls.Add(Me.CmdAtras)
        Me.GroupBox4.Controls.Add(Me.CmdSalir)
        Me.GroupBox4.Controls.Add(Me.CmdCancelar)
        Me.GroupBox4.Controls.Add(Me.CmdPrimero)
        Me.GroupBox4.Controls.Add(Me.CmdEliminar)
        Me.GroupBox4.Controls.Add(Me.CmdMostrar)
        Me.GroupBox4.Controls.Add(Me.CmdNuevo)
        Me.GroupBox4.Location = New System.Drawing.Point(11, 449)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(788, 56)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        '
        'CmdUltimo
        '
        Me.CmdUltimo.Image = CType(resources.GetObject("CmdUltimo.Image"), System.Drawing.Image)
        Me.CmdUltimo.Location = New System.Drawing.Point(719, 12)
        Me.CmdUltimo.Name = "CmdUltimo"
        Me.CmdUltimo.Size = New System.Drawing.Size(52, 38)
        Me.CmdUltimo.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.CmdUltimo, "Último Registro")
        Me.CmdUltimo.UseVisualStyleBackColor = True
        '
        'cmdEdit
        '
        Me.cmdEdit.Image = Global.SAE.My.Resources.Resources.editar
        Me.cmdEdit.Location = New System.Drawing.Point(164, 12)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(52, 38)
        Me.cmdEdit.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.cmdEdit, "Editar Registro")
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'CmdListo
        '
        Me.CmdListo.Image = Global.SAE.My.Resources.Resources.guardar
        Me.CmdListo.Location = New System.Drawing.Point(58, 12)
        Me.CmdListo.Name = "CmdListo"
        Me.CmdListo.Size = New System.Drawing.Size(52, 38)
        Me.CmdListo.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.CmdListo, "Guardar")
        Me.CmdListo.UseVisualStyleBackColor = True
        '
        'CmdSiguiente
        '
        Me.CmdSiguiente.Image = CType(resources.GetObject("CmdSiguiente.Image"), System.Drawing.Image)
        Me.CmdSiguiente.Location = New System.Drawing.Point(668, 12)
        Me.CmdSiguiente.Name = "CmdSiguiente"
        Me.CmdSiguiente.Size = New System.Drawing.Size(52, 38)
        Me.CmdSiguiente.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.CmdSiguiente, "Siguiente Registro")
        Me.CmdSiguiente.UseVisualStyleBackColor = True
        '
        'CmdAtras
        '
        Me.CmdAtras.Image = CType(resources.GetObject("CmdAtras.Image"), System.Drawing.Image)
        Me.CmdAtras.Location = New System.Drawing.Point(617, 12)
        Me.CmdAtras.Name = "CmdAtras"
        Me.CmdAtras.Size = New System.Drawing.Size(52, 38)
        Me.CmdAtras.TabIndex = 12
        Me.CmdAtras.Text = " "
        Me.ToolTip1.SetToolTip(Me.CmdAtras, "Registro Anterior")
        Me.CmdAtras.UseVisualStyleBackColor = True
        '
        'CmdSalir
        '
        Me.CmdSalir.Image = Global.SAE.My.Resources.Resources.salir
        Me.CmdSalir.Location = New System.Drawing.Point(375, 12)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(52, 38)
        Me.CmdSalir.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.CmdSalir, "Salir del Formulario")
        Me.CmdSalir.UseVisualStyleBackColor = True
        '
        'CmdCancelar
        '
        Me.CmdCancelar.Image = Global.SAE.My.Resources.Resources.cancelar
        Me.CmdCancelar.Location = New System.Drawing.Point(111, 12)
        Me.CmdCancelar.Name = "CmdCancelar"
        Me.CmdCancelar.Size = New System.Drawing.Size(52, 38)
        Me.CmdCancelar.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.CmdCancelar, "Cancelar Operacion")
        Me.CmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdPrimero
        '
        Me.CmdPrimero.Image = CType(resources.GetObject("CmdPrimero.Image"), System.Drawing.Image)
        Me.CmdPrimero.Location = New System.Drawing.Point(566, 12)
        Me.CmdPrimero.Name = "CmdPrimero"
        Me.CmdPrimero.Size = New System.Drawing.Size(52, 38)
        Me.CmdPrimero.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.CmdPrimero, "Primer Registro")
        Me.CmdPrimero.UseVisualStyleBackColor = True
        '
        'CmdEliminar
        '
        Me.CmdEliminar.Image = Global.SAE.My.Resources.Resources.eliminar
        Me.CmdEliminar.Location = New System.Drawing.Point(217, 12)
        Me.CmdEliminar.Name = "CmdEliminar"
        Me.CmdEliminar.Size = New System.Drawing.Size(52, 38)
        Me.CmdEliminar.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.CmdEliminar, "Eliminar Registro")
        Me.CmdEliminar.UseVisualStyleBackColor = True
        '
        'CmdMostrar
        '
        Me.CmdMostrar.Image = Global.SAE.My.Resources.Resources.DataTables
        Me.CmdMostrar.Location = New System.Drawing.Point(322, 12)
        Me.CmdMostrar.Name = "CmdMostrar"
        Me.CmdMostrar.Size = New System.Drawing.Size(52, 38)
        Me.CmdMostrar.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.CmdMostrar, "Mostrar Registros")
        Me.CmdMostrar.UseVisualStyleBackColor = True
        '
        'CmdNuevo
        '
        Me.CmdNuevo.Image = Global.SAE.My.Resources.Resources.nuevo
        Me.CmdNuevo.Location = New System.Drawing.Point(6, 12)
        Me.CmdNuevo.Name = "CmdNuevo"
        Me.CmdNuevo.Size = New System.Drawing.Size(52, 38)
        Me.CmdNuevo.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.CmdNuevo, "Nuevo")
        Me.CmdNuevo.UseVisualStyleBackColor = True
        '
        'lbnroobs
        '
        Me.lbnroobs.AutoSize = True
        Me.lbnroobs.BackColor = System.Drawing.Color.Transparent
        Me.lbnroobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnroobs.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbnroobs.Location = New System.Drawing.Point(741, 515)
        Me.lbnroobs.Name = "lbnroobs"
        Me.lbnroobs.Size = New System.Drawing.Size(35, 13)
        Me.lbnroobs.TabIndex = 212
        Me.lbnroobs.Text = "0000"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label38.Location = New System.Drawing.Point(658, 514)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(82, 13)
        Me.Label38.TabIndex = 211
        Me.Label38.Text = "Registro Nro."
        '
        'lbestado
        '
        Me.lbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbestado.ForeColor = System.Drawing.Color.DarkMagenta
        Me.lbestado.Location = New System.Drawing.Point(13, 509)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(108, 22)
        Me.lbestado.TabIndex = 210
        Me.lbestado.Text = "Estado"
        '
        'txtnomctab
        '
        Me.txtnomctab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtnomctab.ForeColor = System.Drawing.Color.DarkRed
        Me.txtnomctab.Location = New System.Drawing.Point(275, 19)
        Me.txtnomctab.Name = "txtnomctab"
        Me.txtnomctab.Size = New System.Drawing.Size(481, 23)
        Me.txtnomctab.TabIndex = 134
        '
        'txtnomctab2
        '
        Me.txtnomctab2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtnomctab2.ForeColor = System.Drawing.Color.DarkRed
        Me.txtnomctab2.Location = New System.Drawing.Point(275, 19)
        Me.txtnomctab2.Name = "txtnomctab2"
        Me.txtnomctab2.Size = New System.Drawing.Size(481, 23)
        Me.txtnomctab2.TabIndex = 137
        '
        'lbdoc
        '
        Me.lbdoc.AutoSize = True
        Me.lbdoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbdoc.Location = New System.Drawing.Point(606, 60)
        Me.lbdoc.Name = "lbdoc"
        Me.lbdoc.Size = New System.Drawing.Size(28, 16)
        Me.lbdoc.TabIndex = 55
        Me.lbdoc.Text = "TB"
        Me.lbdoc.Visible = False
        '
        'cmdprint
        '
        Me.cmdprint.Image = Global.SAE.My.Resources.Resources.pdf
        Me.cmdprint.Location = New System.Drawing.Point(269, 12)
        Me.cmdprint.Name = "cmdprint"
        Me.cmdprint.Size = New System.Drawing.Size(52, 38)
        Me.cmdprint.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.cmdprint, "Imprimir Registro")
        Me.cmdprint.UseVisualStyleBackColor = True
        '
        'FrmTransacciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(808, 539)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.lbnroobs)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.lbestado)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmTransacciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Transacciones Entre Cuentas"
        Me.GroupBox1.ResumeLayout(False)
        Me.gdoc.ResumeLayout(False)
        Me.gdoc.PerformLayout()
        Me.gdestino.ResumeLayout(False)
        Me.gdestino.PerformLayout()
        Me.gorigen.ResumeLayout(False)
        Me.gorigen.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents gdestino As System.Windows.Forms.GroupBox
    Friend WithEvents LABELDV2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtnomcta2 As System.Windows.Forms.TextBox
    Friend WithEvents txtnit2 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtnum2 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtbanco2 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtcuenta2 As System.Windows.Forms.TextBox
    Friend WithEvents gorigen As System.Windows.Forms.GroupBox
    Friend WithEvents LABELDV As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtnomcta As System.Windows.Forms.TextBox
    Friend WithEvents txtnit As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtnum As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtbanco As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtcuenta As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdUltimo As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents CmdListo As System.Windows.Forms.Button
    Friend WithEvents CmdSiguiente As System.Windows.Forms.Button
    Friend WithEvents CmdAtras As System.Windows.Forms.Button
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents CmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdPrimero As System.Windows.Forms.Button
    Friend WithEvents CmdEliminar As System.Windows.Forms.Button
    Friend WithEvents CmdMostrar As System.Windows.Forms.Button
    Friend WithEvents CmdNuevo As System.Windows.Forms.Button
    Friend WithEvents lbnroobs As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents lbestado As System.Windows.Forms.Label
    Friend WithEvents gdoc As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDoc As System.Windows.Forms.TextBox
    Friend WithEvents TxtDocumento As System.Windows.Forms.TextBox
    Friend WithEvents Lbper As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtperiodo As System.Windows.Forms.TextBox
    Friend WithEvents txtdia As System.Windows.Forms.TextBox
    Friend WithEvents TxtNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtmonto As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtcheque As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtcheque2 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtnomctab2 As System.Windows.Forms.Label
    Friend WithEvents txtnomctab As System.Windows.Forms.Label
    Friend WithEvents lbdoc As System.Windows.Forms.Label
    Friend WithEvents cmdprint As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
