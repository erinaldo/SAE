<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBuscarCodBar
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtcod = New System.Windows.Forms.TextBox
        Me.cmd_buscar = New System.Windows.Forms.Button
        Me.lbitems = New System.Windows.Forms.Label
        Me.lbbodega = New System.Windows.Forms.Label
        Me.lbiva = New System.Windows.Forms.Label
        Me.LbTipoMov = New System.Windows.Forms.Label
        Me.lbform = New System.Windows.Forms.Label
        Me.lbsalir = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtcod)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(351, 94)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Buscar por Codigo de Barras"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Codigo"
        '
        'txtcod
        '
        Me.txtcod.Location = New System.Drawing.Point(97, 41)
        Me.txtcod.Name = "txtcod"
        Me.txtcod.Size = New System.Drawing.Size(201, 20)
        Me.txtcod.TabIndex = 0
        '
        'cmd_buscar
        '
        Me.cmd_buscar.Location = New System.Drawing.Point(15, 179)
        Me.cmd_buscar.Name = "cmd_buscar"
        Me.cmd_buscar.Size = New System.Drawing.Size(75, 23)
        Me.cmd_buscar.TabIndex = 1
        Me.cmd_buscar.Text = "&Buscar"
        Me.cmd_buscar.UseVisualStyleBackColor = True
        '
        'lbitems
        '
        Me.lbitems.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbitems.ForeColor = System.Drawing.Color.DarkRed
        Me.lbitems.Location = New System.Drawing.Point(12, 109)
        Me.lbitems.Name = "lbitems"
        Me.lbitems.Size = New System.Drawing.Size(351, 23)
        Me.lbitems.TabIndex = 73
        Me.lbitems.Text = "Digite 00 y luego enter para salir o cancelar."
        Me.lbitems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbbodega
        '
        Me.lbbodega.AutoSize = True
        Me.lbbodega.Location = New System.Drawing.Point(307, 179)
        Me.lbbodega.Name = "lbbodega"
        Me.lbbodega.Size = New System.Drawing.Size(13, 13)
        Me.lbbodega.TabIndex = 77
        Me.lbbodega.Text = "1"
        Me.lbbodega.Visible = False
        '
        'lbiva
        '
        Me.lbiva.AutoSize = True
        Me.lbiva.Location = New System.Drawing.Point(307, 206)
        Me.lbiva.Name = "lbiva"
        Me.lbiva.Size = New System.Drawing.Size(23, 13)
        Me.lbiva.TabIndex = 76
        Me.lbiva.Text = "NO"
        Me.lbiva.Visible = False
        '
        'LbTipoMov
        '
        Me.LbTipoMov.AutoSize = True
        Me.LbTipoMov.Location = New System.Drawing.Point(173, 206)
        Me.LbTipoMov.Name = "LbTipoMov"
        Me.LbTipoMov.Size = New System.Drawing.Size(82, 13)
        Me.LbTipoMov.TabIndex = 75
        Me.LbTipoMov.Text = "entrada o salida"
        Me.LbTipoMov.Visible = False
        '
        'lbform
        '
        Me.lbform.AutoSize = True
        Me.lbform.Location = New System.Drawing.Point(173, 184)
        Me.lbform.Name = "lbform"
        Me.lbform.Size = New System.Drawing.Size(52, 13)
        Me.lbform.TabIndex = 78
        Me.lbform.Text = "formulario"
        Me.lbform.Visible = False
        '
        'lbsalir
        '
        Me.lbsalir.AutoSize = True
        Me.lbsalir.Location = New System.Drawing.Point(106, 206)
        Me.lbsalir.Name = "lbsalir"
        Me.lbsalir.Size = New System.Drawing.Size(23, 13)
        Me.lbsalir.TabIndex = 79
        Me.lbsalir.Text = "NO"
        Me.lbsalir.Visible = False
        '
        'FrmBuscarCodBar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(374, 136)
        Me.Controls.Add(Me.lbsalir)
        Me.Controls.Add(Me.lbform)
        Me.Controls.Add(Me.lbbodega)
        Me.Controls.Add(Me.lbiva)
        Me.Controls.Add(Me.LbTipoMov)
        Me.Controls.Add(Me.lbitems)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmd_buscar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBuscarCodBar"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Buscar Articulo Por Codigo Barras"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtcod As System.Windows.Forms.TextBox
    Friend WithEvents cmd_buscar As System.Windows.Forms.Button
    Friend WithEvents lbitems As System.Windows.Forms.Label
    Friend WithEvents lbbodega As System.Windows.Forms.Label
    Friend WithEvents lbiva As System.Windows.Forms.Label
    Friend WithEvents LbTipoMov As System.Windows.Forms.Label
    Friend WithEvents lbform As System.Windows.Forms.Label
    Friend WithEvents lbsalir As System.Windows.Forms.Label
End Class
