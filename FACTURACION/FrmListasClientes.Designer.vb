<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmListasClientes
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.lbnota = New System.Windows.Forms.Label
        Me.cmdLista = New System.Windows.Forms.Button
        Me.txtlista = New System.Windows.Forms.TextBox
        Me.cblista = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtcliente = New System.Windows.Forms.TextBox
        Me.txtnitc = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtlista2 = New System.Windows.Forms.TextBox
        Me.cblista2 = New System.Windows.Forms.ComboBox
        Me.rb2 = New System.Windows.Forms.RadioButton
        Me.rb1 = New System.Windows.Forms.RadioButton
        Me.cmdPDF = New System.Windows.Forms.Button
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lbnota)
        Me.GroupBox1.Controls.Add(Me.cmdLista)
        Me.GroupBox1.Controls.Add(Me.txtlista)
        Me.GroupBox1.Controls.Add(Me.cblista)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtcliente)
        Me.GroupBox1.Controls.Add(Me.txtnitc)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(582, 138)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Asignar Lista de Precio a un Cliente"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 66
        Me.Label3.Text = "Nota"
        '
        'lbnota
        '
        Me.lbnota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbnota.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnota.ForeColor = System.Drawing.Color.DarkRed
        Me.lbnota.Location = New System.Drawing.Point(62, 82)
        Me.lbnota.Name = "lbnota"
        Me.lbnota.Size = New System.Drawing.Size(224, 20)
        Me.lbnota.TabIndex = 65
        Me.lbnota.Text = "no tiene lista asignada"
        Me.lbnota.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdLista
        '
        Me.cmdLista.Location = New System.Drawing.Point(252, 109)
        Me.cmdLista.Name = "cmdLista"
        Me.cmdLista.Size = New System.Drawing.Size(84, 23)
        Me.cmdLista.TabIndex = 64
        Me.cmdLista.Text = "Asignar Lista"
        Me.cmdLista.UseVisualStyleBackColor = True
        '
        'txtlista
        '
        Me.txtlista.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtlista.Enabled = False
        Me.txtlista.Location = New System.Drawing.Point(134, 54)
        Me.txtlista.Name = "txtlista"
        Me.txtlista.ReadOnly = True
        Me.txtlista.Size = New System.Drawing.Size(427, 20)
        Me.txtlista.TabIndex = 63
        '
        'cblista
        '
        Me.cblista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cblista.FormattingEnabled = True
        Me.cblista.Location = New System.Drawing.Point(63, 54)
        Me.cblista.Name = "cblista"
        Me.cblista.Size = New System.Drawing.Size(65, 21)
        Me.cblista.TabIndex = 62
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Lista"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "Cliente"
        '
        'txtcliente
        '
        Me.txtcliente.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcliente.Enabled = False
        Me.txtcliente.Location = New System.Drawing.Point(180, 28)
        Me.txtcliente.Name = "txtcliente"
        Me.txtcliente.ReadOnly = True
        Me.txtcliente.Size = New System.Drawing.Size(381, 20)
        Me.txtcliente.TabIndex = 59
        '
        'txtnitc
        '
        Me.txtnitc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnitc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtnitc.Location = New System.Drawing.Point(63, 28)
        Me.txtnitc.MaxLength = 20
        Me.txtnitc.Name = "txtnitc"
        Me.txtnitc.Size = New System.Drawing.Size(111, 20)
        Me.txtnitc.TabIndex = 58
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtlista2)
        Me.GroupBox2.Controls.Add(Me.cblista2)
        Me.GroupBox2.Controls.Add(Me.rb2)
        Me.GroupBox2.Controls.Add(Me.rb1)
        Me.GroupBox2.Controls.Add(Me.cmdPDF)
        Me.GroupBox2.Location = New System.Drawing.Point(2, 152)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(582, 120)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Imprimir Clientes Por Listas de Precios"
        '
        'txtlista2
        '
        Me.txtlista2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtlista2.Enabled = False
        Me.txtlista2.Location = New System.Drawing.Point(206, 58)
        Me.txtlista2.Name = "txtlista2"
        Me.txtlista2.ReadOnly = True
        Me.txtlista2.Size = New System.Drawing.Size(368, 20)
        Me.txtlista2.TabIndex = 69
        '
        'cblista2
        '
        Me.cblista2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cblista2.FormattingEnabled = True
        Me.cblista2.Location = New System.Drawing.Point(135, 58)
        Me.cblista2.Name = "cblista2"
        Me.cblista2.Size = New System.Drawing.Size(65, 21)
        Me.cblista2.TabIndex = 68
        '
        'rb2
        '
        Me.rb2.AutoSize = True
        Me.rb2.Location = New System.Drawing.Point(14, 61)
        Me.rb2.Name = "rb2"
        Me.rb2.Size = New System.Drawing.Size(123, 17)
        Me.rb2.TabIndex = 67
        Me.rb2.TabStop = True
        Me.rb2.Text = "&Una Lista de Precios"
        Me.rb2.UseVisualStyleBackColor = True
        '
        'rb1
        '
        Me.rb1.AutoSize = True
        Me.rb1.Checked = True
        Me.rb1.Location = New System.Drawing.Point(14, 29)
        Me.rb1.Name = "rb1"
        Me.rb1.Size = New System.Drawing.Size(154, 17)
        Me.rb1.TabIndex = 66
        Me.rb1.TabStop = True
        Me.rb1.Text = "&Todas las Listas de Precios"
        Me.rb1.UseVisualStyleBackColor = True
        '
        'cmdPDF
        '
        Me.cmdPDF.Location = New System.Drawing.Point(252, 90)
        Me.cmdPDF.Name = "cmdPDF"
        Me.cmdPDF.Size = New System.Drawing.Size(84, 23)
        Me.cmdPDF.TabIndex = 65
        Me.cmdPDF.Text = "Gernerar PDF"
        Me.cmdPDF.UseVisualStyleBackColor = True
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Location = New System.Drawing.Point(2, 276)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(582, 85)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.GroupPanel1.TabIndex = 85
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.atras
        Me.cmdsalir.Location = New System.Drawing.Point(260, 11)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(59, 57)
        Me.cmdsalir.TabIndex = 1
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'FrmListasClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(588, 365)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmListasClientes"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Listas de Precios por Clientes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtcliente As System.Windows.Forms.TextBox
    Friend WithEvents txtnitc As System.Windows.Forms.TextBox
    Friend WithEvents cmdLista As System.Windows.Forms.Button
    Friend WithEvents txtlista As System.Windows.Forms.TextBox
    Friend WithEvents cblista As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbnota As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdPDF As System.Windows.Forms.Button
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents txtlista2 As System.Windows.Forms.TextBox
    Friend WithEvents cblista2 As System.Windows.Forms.ComboBox
    Friend WithEvents rb2 As System.Windows.Forms.RadioButton
    Friend WithEvents rb1 As System.Windows.Forms.RadioButton
End Class
