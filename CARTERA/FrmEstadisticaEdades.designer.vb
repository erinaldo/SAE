<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frmestadisticaedades
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtnit = New System.Windows.Forms.TextBox
        Me.txtcliente = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.rdbtclientes = New System.Windows.Forms.RadioButton
        Me.rdbcliente = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.filtrofecha = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtfecha2 = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtfecha1 = New System.Windows.Forms.DateTimePicker
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rdbbarras = New System.Windows.Forms.RadioButton
        Me.rdbsector = New System.Windows.Forms.RadioButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtdias = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.txttitulo = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtnit)
        Me.GroupBox1.Controls.Add(Me.txtcliente)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.rdbtclientes)
        Me.GroupBox1.Controls.Add(Me.rdbcliente)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(237, 102)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opciones de Graficas"
        '
        'txtnit
        '
        Me.txtnit.Location = New System.Drawing.Point(72, 48)
        Me.txtnit.Name = "txtnit"
        Me.txtnit.Size = New System.Drawing.Size(153, 20)
        Me.txtnit.TabIndex = 227
        '
        'txtcliente
        '
        Me.txtcliente.BackColor = System.Drawing.Color.White
        Me.txtcliente.Enabled = False
        Me.txtcliente.Location = New System.Drawing.Point(15, 70)
        Me.txtcliente.Name = "txtcliente"
        Me.txtcliente.ReadOnly = True
        Me.txtcliente.ShortcutsEnabled = False
        Me.txtcliente.Size = New System.Drawing.Size(211, 20)
        Me.txtcliente.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 226
        Me.Label1.Text = "C.C. o Nit"
        '
        'rdbtclientes
        '
        Me.rdbtclientes.AutoSize = True
        Me.rdbtclientes.Location = New System.Drawing.Point(95, 23)
        Me.rdbtclientes.Name = "rdbtclientes"
        Me.rdbtclientes.Size = New System.Drawing.Size(115, 17)
        Me.rdbtclientes.TabIndex = 1
        Me.rdbtclientes.TabStop = True
        Me.rdbtclientes.Text = "Todos Los Clientes"
        Me.rdbtclientes.UseVisualStyleBackColor = True
        '
        'rdbcliente
        '
        Me.rdbcliente.AutoSize = True
        Me.rdbcliente.Location = New System.Drawing.Point(15, 23)
        Me.rdbcliente.Name = "rdbcliente"
        Me.rdbcliente.Size = New System.Drawing.Size(74, 17)
        Me.rdbcliente.TabIndex = 2
        Me.rdbcliente.TabStop = True
        Me.rdbcliente.Text = "Un Cliente"
        Me.rdbcliente.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.filtrofecha)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtfecha2)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtfecha1)
        Me.GroupBox2.Location = New System.Drawing.Point(255, 15)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(352, 102)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Vencimientos"
        '
        'filtrofecha
        '
        Me.filtrofecha.AutoSize = True
        Me.filtrofecha.Location = New System.Drawing.Point(15, 74)
        Me.filtrofecha.Name = "filtrofecha"
        Me.filtrofecha.Size = New System.Drawing.Size(131, 17)
        Me.filtrofecha.TabIndex = 126
        Me.filtrofecha.Text = "Aplicar Filtro de Fecha"
        Me.filtrofecha.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 13)
        Me.Label4.TabIndex = 125
        Me.Label4.Text = "Fecha Inicial Análisis"
        '
        'txtfecha2
        '
        Me.txtfecha2.CustomFormat = "yyyy/dd/mm"
        Me.txtfecha2.Location = New System.Drawing.Point(117, 20)
        Me.txtfecha2.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.txtfecha2.Name = "txtfecha2"
        Me.txtfecha2.Size = New System.Drawing.Size(205, 20)
        Me.txtfecha2.TabIndex = 124
        Me.txtfecha2.Value = New Date(2011, 1, 1, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 123
        Me.Label2.Text = "Fecha Final Análisis"
        '
        'txtfecha1
        '
        Me.txtfecha1.CustomFormat = "yyyy/dd/mm"
        Me.txtfecha1.Location = New System.Drawing.Point(117, 46)
        Me.txtfecha1.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.txtfecha1.Name = "txtfecha1"
        Me.txtfecha1.Size = New System.Drawing.Size(205, 20)
        Me.txtfecha1.TabIndex = 8
        Me.txtfecha1.Value = New Date(2011, 1, 1, 0, 0, 0, 0)
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdbbarras)
        Me.GroupBox3.Controls.Add(Me.rdbsector)
        Me.GroupBox3.Location = New System.Drawing.Point(255, 130)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(351, 47)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tipos de Graficas"
        '
        'rdbbarras
        '
        Me.rdbbarras.AutoSize = True
        Me.rdbbarras.Location = New System.Drawing.Point(140, 19)
        Me.rdbbarras.Name = "rdbbarras"
        Me.rdbbarras.Size = New System.Drawing.Size(88, 17)
        Me.rdbbarras.TabIndex = 13
        Me.rdbbarras.TabStop = True
        Me.rdbbarras.Text = "Columnas 3D"
        Me.rdbbarras.UseVisualStyleBackColor = True
        '
        'rdbsector
        '
        Me.rdbsector.AutoSize = True
        Me.rdbsector.Location = New System.Drawing.Point(26, 19)
        Me.rdbsector.Name = "rdbsector"
        Me.rdbsector.Size = New System.Drawing.Size(84, 17)
        Me.rdbsector.TabIndex = 12
        Me.rdbsector.TabStop = True
        Me.rdbsector.Text = "Sectores 3D"
        Me.rdbsector.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtdias)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 130)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(237, 47)
        Me.GroupBox4.TabIndex = 9
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Días"
        '
        'txtdias
        '
        Me.txtdias.Location = New System.Drawing.Point(78, 16)
        Me.txtdias.Name = "txtdias"
        Me.txtdias.Size = New System.Drawing.Size(49, 20)
        Me.txtdias.TabIndex = 10
        Me.txtdias.Text = "30"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 124
        Me.Label3.Text = "Intervalos"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txttitulo)
        Me.GroupBox5.Location = New System.Drawing.Point(17, 183)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(589, 302)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Esquema de Graficos"
        '
        'txttitulo
        '
        Me.txttitulo.Location = New System.Drawing.Point(52, 25)
        Me.txttitulo.Name = "txttitulo"
        Me.txttitulo.Size = New System.Drawing.Size(367, 20)
        Me.txttitulo.TabIndex = 1
        Me.txttitulo.Visible = False
        '
        'Frmestadisticaedades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(620, 495)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frmestadisticaedades"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Estadistica Por Edades"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbtclientes As System.Windows.Forms.RadioButton
    Friend WithEvents rdbcliente As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtcliente As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtfecha1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbsector As System.Windows.Forms.RadioButton
    Friend WithEvents rdbbarras As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    'Friend WithEvents grafica As AxFusionChartsForVB.AxFusionCharts
    Friend WithEvents txtdias As System.Windows.Forms.TextBox
    Friend WithEvents txttitulo As System.Windows.Forms.TextBox
    Friend WithEvents txtnit As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtfecha2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents filtrofecha As System.Windows.Forms.CheckBox
End Class
