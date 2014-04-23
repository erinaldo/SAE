<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSaldosInicialesCartera
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cbcont = New System.Windows.Forms.CheckBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtncentro = New System.Windows.Forms.TextBox
        Me.txtcentro = New System.Windows.Forms.TextBox
        Me.txtnomcta = New System.Windows.Forms.TextBox
        Me.txtcta = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtcliente = New System.Windows.Forms.TextBox
        Me.txtnit = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.laboltotal = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.grilla = New System.Windows.Forms.DataGridView
        Me.tipo = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.doc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.concepto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.vmto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.valor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ok = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmdInf = New System.Windows.Forms.Button
        Me.lbcta = New System.Windows.Forms.Label
        Me.CmdListo = New System.Windows.Forms.Button
        Me.CmdSalir = New System.Windows.Forms.Button
        Me.CmdCancelar = New System.Windows.Forms.Button
        Me.cmdNuevo = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbcont)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.txtncentro)
        Me.GroupBox2.Controls.Add(Me.txtcentro)
        Me.GroupBox2.Controls.Add(Me.txtnomcta)
        Me.GroupBox2.Controls.Add(Me.txtcta)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtcliente)
        Me.GroupBox2.Controls.Add(Me.txtnit)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(739, 115)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos Cliente"
        '
        'cbcont
        '
        Me.cbcont.AutoSize = True
        Me.cbcont.Checked = True
        Me.cbcont.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbcont.Location = New System.Drawing.Point(6, 41)
        Me.cbcont.Name = "cbcont"
        Me.cbcont.Size = New System.Drawing.Size(156, 17)
        Me.cbcont.TabIndex = 10
        Me.cbcont.Text = "Contabilizar Saldos Iniciales"
        Me.cbcont.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(4, 89)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(88, 13)
        Me.Label19.TabIndex = 186
        Me.Label19.Text = "Centro de Costos"
        '
        'txtncentro
        '
        Me.txtncentro.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtncentro.Enabled = False
        Me.txtncentro.Location = New System.Drawing.Point(161, 86)
        Me.txtncentro.Name = "txtncentro"
        Me.txtncentro.ReadOnly = True
        Me.txtncentro.Size = New System.Drawing.Size(514, 20)
        Me.txtncentro.TabIndex = 185
        '
        'txtcentro
        '
        Me.txtcentro.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcentro.Enabled = False
        Me.txtcentro.Location = New System.Drawing.Point(109, 86)
        Me.txtcentro.Name = "txtcentro"
        Me.txtcentro.Size = New System.Drawing.Size(45, 20)
        Me.txtcentro.TabIndex = 184
        '
        'txtnomcta
        '
        Me.txtnomcta.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtnomcta.Enabled = False
        Me.txtnomcta.Location = New System.Drawing.Point(237, 60)
        Me.txtnomcta.Name = "txtnomcta"
        Me.txtnomcta.ReadOnly = True
        Me.txtnomcta.Size = New System.Drawing.Size(438, 20)
        Me.txtnomcta.TabIndex = 175
        '
        'txtcta
        '
        Me.txtcta.Enabled = False
        Me.txtcta.Location = New System.Drawing.Point(109, 60)
        Me.txtcta.Name = "txtcta"
        Me.txtcta.ShortcutsEnabled = False
        Me.txtcta.Size = New System.Drawing.Size(119, 20)
        Me.txtcta.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 13)
        Me.Label6.TabIndex = 180
        Me.Label6.Text = "Cuenta Contabilidad"
        '
        'txtcliente
        '
        Me.txtcliente.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcliente.Enabled = False
        Me.txtcliente.Location = New System.Drawing.Point(237, 19)
        Me.txtcliente.Name = "txtcliente"
        Me.txtcliente.ReadOnly = True
        Me.txtcliente.Size = New System.Drawing.Size(438, 20)
        Me.txtcliente.TabIndex = 173
        '
        'txtnit
        '
        Me.txtnit.Enabled = False
        Me.txtnit.Location = New System.Drawing.Point(109, 19)
        Me.txtnit.Name = "txtnit"
        Me.txtnit.ShortcutsEnabled = False
        Me.txtnit.Size = New System.Drawing.Size(119, 20)
        Me.txtnit.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 13)
        Me.Label5.TabIndex = 179
        Me.Label5.Text = "Nit/Cedula Cliente"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.laboltotal)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.grilla)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 125)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(739, 223)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Facturas Pendientes"
        '
        'laboltotal
        '
        Me.laboltotal.BackColor = System.Drawing.Color.BurlyWood
        Me.laboltotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.laboltotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.laboltotal.ForeColor = System.Drawing.Color.Red
        Me.laboltotal.Location = New System.Drawing.Point(231, 192)
        Me.laboltotal.Name = "laboltotal"
        Me.laboltotal.Size = New System.Drawing.Size(217, 21)
        Me.laboltotal.TabIndex = 15
        Me.laboltotal.Text = "$0"
        Me.laboltotal.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.BurlyWood
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(8, 192)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(217, 21)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Valor Facturas"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'grilla
        '
        Me.grilla.AllowDrop = True
        Me.grilla.AllowUserToResizeColumns = False
        Me.grilla.AllowUserToResizeRows = False
        Me.grilla.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tipo, Me.doc, Me.concepto, Me.fecha, Me.vmto, Me.valor, Me.cuenta, Me.ok})
        Me.grilla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.grilla.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.grilla.Location = New System.Drawing.Point(9, 20)
        Me.grilla.MultiSelect = False
        Me.grilla.Name = "grilla"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grilla.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.grilla.RowHeadersVisible = False
        Me.grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grilla.Size = New System.Drawing.Size(721, 169)
        Me.grilla.TabIndex = 1
        '
        'tipo
        '
        Me.tipo.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.tipo.HeaderText = "Tipo Doc"
        Me.tipo.MinimumWidth = 60
        Me.tipo.Name = "tipo"
        Me.tipo.Width = 60
        '
        'doc
        '
        Me.doc.FillWeight = 80.0!
        Me.doc.HeaderText = "Numero Doc"
        Me.doc.MaxInputLength = 12
        Me.doc.MinimumWidth = 74
        Me.doc.Name = "doc"
        Me.doc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.doc.Width = 74
        '
        'concepto
        '
        Me.concepto.HeaderText = "Concepto"
        Me.concepto.MinimumWidth = 180
        Me.concepto.Name = "concepto"
        Me.concepto.Width = 180
        '
        'fecha
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle6.Format = "d"
        DataGridViewCellStyle6.NullValue = Nothing
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.fecha.DefaultCellStyle = DataGridViewCellStyle6
        Me.fecha.FillWeight = 180.0!
        Me.fecha.HeaderText = "Fecha(dd/mm/aaaa)"
        Me.fecha.MaxInputLength = 12
        Me.fecha.MinimumWidth = 110
        Me.fecha.Name = "fecha"
        Me.fecha.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.fecha.Width = 110
        '
        'vmto
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.ForestGreen
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.vmto.DefaultCellStyle = DataGridViewCellStyle7
        Me.vmto.HeaderText = "Dias Vmto."
        Me.vmto.MaxInputLength = 30
        Me.vmto.MinimumWidth = 75
        Me.vmto.Name = "vmto"
        Me.vmto.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.vmto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.vmto.Width = 75
        '
        'valor
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.DarkOrange
        DataGridViewCellStyle8.Format = "N2"
        Me.valor.DefaultCellStyle = DataGridViewCellStyle8
        Me.valor.HeaderText = "Valor"
        Me.valor.MaxInputLength = 30
        Me.valor.MinimumWidth = 85
        Me.valor.Name = "valor"
        Me.valor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.valor.Width = 85
        '
        'cuenta
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.NullValue = Nothing
        Me.cuenta.DefaultCellStyle = DataGridViewCellStyle9
        Me.cuenta.HeaderText = "Cuenta"
        Me.cuenta.MinimumWidth = 83
        Me.cuenta.Name = "cuenta"
        Me.cuenta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cuenta.Width = 83
        '
        'ok
        '
        Me.ok.HeaderText = "Ok"
        Me.ok.MinimumWidth = 30
        Me.ok.Name = "ok"
        Me.ok.ReadOnly = True
        Me.ok.Width = 30
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdInf)
        Me.GroupBox3.Controls.Add(Me.lbcta)
        Me.GroupBox3.Controls.Add(Me.CmdListo)
        Me.GroupBox3.Controls.Add(Me.CmdSalir)
        Me.GroupBox3.Controls.Add(Me.CmdCancelar)
        Me.GroupBox3.Controls.Add(Me.cmdNuevo)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 352)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(739, 60)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(473, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(30, 29)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "&E"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdInf
        '
        Me.cmdInf.Image = Global.SAE.My.Resources.Resources.Excel_Pdf
        Me.cmdInf.Location = New System.Drawing.Point(393, 12)
        Me.cmdInf.Name = "cmdInf"
        Me.cmdInf.Size = New System.Drawing.Size(54, 40)
        Me.cmdInf.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.cmdInf, "Informe")
        Me.cmdInf.UseVisualStyleBackColor = True
        '
        'lbcta
        '
        Me.lbcta.AutoSize = True
        Me.lbcta.Location = New System.Drawing.Point(49, 20)
        Me.lbcta.Name = "lbcta"
        Me.lbcta.Size = New System.Drawing.Size(37, 13)
        Me.lbcta.TabIndex = 9
        Me.lbcta.Text = "cta 13"
        Me.lbcta.Visible = False
        '
        'CmdListo
        '
        Me.CmdListo.Enabled = False
        Me.CmdListo.Image = Global.SAE.My.Resources.Resources.guardar
        Me.CmdListo.Location = New System.Drawing.Point(286, 12)
        Me.CmdListo.Name = "CmdListo"
        Me.CmdListo.Size = New System.Drawing.Size(52, 40)
        Me.CmdListo.TabIndex = 8
        Me.CmdListo.UseVisualStyleBackColor = True
        '
        'CmdSalir
        '
        Me.CmdSalir.Image = Global.SAE.My.Resources.Resources.salir
        Me.CmdSalir.Location = New System.Drawing.Point(451, 13)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(52, 40)
        Me.CmdSalir.TabIndex = 5
        Me.CmdSalir.UseVisualStyleBackColor = True
        '
        'CmdCancelar
        '
        Me.CmdCancelar.Enabled = False
        Me.CmdCancelar.Image = Global.SAE.My.Resources.Resources.cancelar
        Me.CmdCancelar.Location = New System.Drawing.Point(339, 12)
        Me.CmdCancelar.Name = "CmdCancelar"
        Me.CmdCancelar.Size = New System.Drawing.Size(52, 40)
        Me.CmdCancelar.TabIndex = 3
        Me.CmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdNuevo
        '
        Me.cmdNuevo.Image = Global.SAE.My.Resources.Resources.nuevo
        Me.cmdNuevo.Location = New System.Drawing.Point(232, 12)
        Me.cmdNuevo.Name = "cmdNuevo"
        Me.cmdNuevo.Size = New System.Drawing.Size(52, 40)
        Me.cmdNuevo.TabIndex = 0
        Me.cmdNuevo.UseVisualStyleBackColor = True
        '
        'FrmSaldosInicialesCartera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(760, 418)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSaldosInicialesCartera"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  SAE Saldos Iniciales Cartera                       Para Eliminar saldos inicial" & _
            "es presione la tecla Alt+E"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtcliente As System.Windows.Forms.TextBox
    Friend WithEvents txtnit As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtnomcta As System.Windows.Forms.TextBox
    Friend WithEvents txtcta As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grilla As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents laboltotal As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdListo As System.Windows.Forms.Button
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents CmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdNuevo As System.Windows.Forms.Button
    Friend WithEvents lbcta As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtncentro As System.Windows.Forms.TextBox
    Friend WithEvents txtcentro As System.Windows.Forms.TextBox
    Friend WithEvents tipo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents doc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents concepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vmto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ok As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cmdInf As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cbcont As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
