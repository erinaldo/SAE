﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInfoClientes
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.chcli = New System.Windows.Forms.CheckBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtnom = New System.Windows.Forms.TextBox
        Me.txttip = New System.Windows.Forms.TextBox
        Me.c2 = New System.Windows.Forms.RadioButton
        Me.c1 = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.d2 = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.d1 = New System.Windows.Forms.RadioButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtdi2 = New System.Windows.Forms.TextBox
        Me.txtdi1 = New System.Windows.Forms.TextBox
        Me.cbfin = New System.Windows.Forms.ComboBox
        Me.txtpfin = New System.Windows.Forms.TextBox
        Me.cbini = New System.Windows.Forms.ComboBox
        Me.txtpini = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdpantalla = New System.Windows.Forms.Button
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chcli)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtnom)
        Me.GroupBox3.Controls.Add(Me.txttip)
        Me.GroupBox3.Controls.Add(Me.c2)
        Me.GroupBox3.Controls.Add(Me.c1)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(526, 129)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'chcli
        '
        Me.chcli.AutoSize = True
        Me.chcli.Location = New System.Drawing.Point(113, 46)
        Me.chcli.Name = "chcli"
        Me.chcli.Size = New System.Drawing.Size(152, 17)
        Me.chcli.TabIndex = 3
        Me.chcli.Text = "Buscar Cliente por Apellido"
        Me.chcli.UseVisualStyleBackColor = True
        Me.chcli.Visible = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Brown
        Me.Label22.Location = New System.Drawing.Point(15, 108)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(235, 13)
        Me.Label22.TabIndex = 84
        Me.Label22.Text = "* Doble click para seleccionar el Cliente"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 15)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Nit"
        '
        'txtnom
        '
        Me.txtnom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtnom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtnom.Enabled = False
        Me.txtnom.Location = New System.Drawing.Point(172, 80)
        Me.txtnom.Name = "txtnom"
        Me.txtnom.Size = New System.Drawing.Size(335, 20)
        Me.txtnom.TabIndex = 5
        '
        'txttip
        '
        Me.txttip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttip.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txttip.Enabled = False
        Me.txttip.Location = New System.Drawing.Point(45, 80)
        Me.txttip.MaxLength = 100
        Me.txttip.Name = "txttip"
        Me.txttip.Size = New System.Drawing.Size(121, 20)
        Me.txttip.TabIndex = 4
        '
        'c2
        '
        Me.c2.AutoSize = True
        Me.c2.Location = New System.Drawing.Point(16, 45)
        Me.c2.Name = "c2"
        Me.c2.Size = New System.Drawing.Size(74, 17)
        Me.c2.TabIndex = 2
        Me.c2.Text = "&Un Cliente"
        Me.c2.UseVisualStyleBackColor = True
        '
        'c1
        '
        Me.c1.AutoSize = True
        Me.c1.Checked = True
        Me.c1.Location = New System.Drawing.Point(15, 22)
        Me.c1.Name = "c1"
        Me.c1.Size = New System.Drawing.Size(106, 17)
        Me.c1.TabIndex = 1
        Me.c1.TabStop = True
        Me.c1.Text = "&Todos lo Clientes"
        Me.c1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.d2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.d1)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 138)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(526, 89)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'd2
        '
        Me.d2.AutoSize = True
        Me.d2.Location = New System.Drawing.Point(283, 38)
        Me.d2.Name = "d2"
        Me.d2.Size = New System.Drawing.Size(72, 17)
        Me.d2.TabIndex = 6
        Me.d2.Text = "&Resumido"
        Me.d2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 15)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Listar Documentos"
        '
        'd1
        '
        Me.d1.AutoSize = True
        Me.d1.Checked = True
        Me.d1.Location = New System.Drawing.Point(65, 38)
        Me.d1.Name = "d1"
        Me.d1.Size = New System.Drawing.Size(70, 17)
        Me.d1.TabIndex = 4
        Me.d1.TabStop = True
        Me.d1.Text = "&Detallado"
        Me.d1.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtdi2)
        Me.GroupBox4.Controls.Add(Me.txtdi1)
        Me.GroupBox4.Controls.Add(Me.cbfin)
        Me.GroupBox4.Controls.Add(Me.txtpfin)
        Me.GroupBox4.Controls.Add(Me.cbini)
        Me.GroupBox4.Controls.Add(Me.txtpini)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 233)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(526, 81)
        Me.GroupBox4.TabIndex = 78
        Me.GroupBox4.TabStop = False
        '
        'txtdi2
        '
        Me.txtdi2.Location = New System.Drawing.Point(328, 30)
        Me.txtdi2.MaxLength = 2
        Me.txtdi2.Name = "txtdi2"
        Me.txtdi2.Size = New System.Drawing.Size(30, 20)
        Me.txtdi2.TabIndex = 12
        Me.txtdi2.Text = "01"
        '
        'txtdi1
        '
        Me.txtdi1.Location = New System.Drawing.Point(103, 30)
        Me.txtdi1.MaxLength = 2
        Me.txtdi1.Name = "txtdi1"
        Me.txtdi1.Size = New System.Drawing.Size(30, 20)
        Me.txtdi1.TabIndex = 10
        Me.txtdi1.Text = "01"
        '
        'cbfin
        '
        Me.cbfin.DisplayMember = "01"
        Me.cbfin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbfin.FormattingEnabled = True
        Me.cbfin.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cbfin.Location = New System.Drawing.Point(363, 29)
        Me.cbfin.MaxLength = 2
        Me.cbfin.Name = "cbfin"
        Me.cbfin.Size = New System.Drawing.Size(39, 21)
        Me.cbfin.TabIndex = 13
        Me.cbfin.Tag = "1"
        Me.cbfin.ValueMember = "01"
        '
        'txtpfin
        '
        Me.txtpfin.Enabled = False
        Me.txtpfin.Location = New System.Drawing.Point(406, 30)
        Me.txtpfin.Name = "txtpfin"
        Me.txtpfin.Size = New System.Drawing.Size(42, 20)
        Me.txtpfin.TabIndex = 64
        Me.txtpfin.Text = "/0000"
        '
        'cbini
        '
        Me.cbini.DisplayMember = "01"
        Me.cbini.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbini.FormattingEnabled = True
        Me.cbini.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cbini.Location = New System.Drawing.Point(139, 30)
        Me.cbini.MaxLength = 2
        Me.cbini.Name = "cbini"
        Me.cbini.Size = New System.Drawing.Size(39, 21)
        Me.cbini.TabIndex = 11
        Me.cbini.Tag = "1"
        Me.cbini.ValueMember = "01"
        '
        'txtpini
        '
        Me.txtpini.Enabled = False
        Me.txtpini.Location = New System.Drawing.Point(182, 31)
        Me.txtpini.Name = "txtpini"
        Me.txtpini.Size = New System.Drawing.Size(42, 20)
        Me.txtpini.TabIndex = 62
        Me.txtpini.Text = "/0000"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(241, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 15)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "Fecha Final"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 15)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "Fecha Inicial"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.TextBox1)
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Controls.Add(Me.cmdpantalla)
        Me.GroupPanel1.Location = New System.Drawing.Point(7, 320)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(526, 85)
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
        Me.GroupPanel1.TabIndex = 79
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(22, 30)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 17
        Me.TextBox1.Visible = False
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.atras
        Me.cmdsalir.Location = New System.Drawing.Point(246, 12)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(59, 57)
        Me.cmdsalir.TabIndex = 15
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'cmdpantalla
        '
        Me.cmdpantalla.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdpantalla.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdpantalla.Image = Global.SAE.My.Resources.Resources.Excel_Pdf
        Me.cmdpantalla.Location = New System.Drawing.Point(181, 12)
        Me.cmdpantalla.Name = "cmdpantalla"
        Me.cmdpantalla.Size = New System.Drawing.Size(59, 57)
        Me.cmdpantalla.TabIndex = 14
        Me.cmdpantalla.Text = "&R"
        Me.cmdpantalla.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdpantalla.UseVisualStyleBackColor = False
        '
        'FrmInfoClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(537, 409)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInfoClientes"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SAE INFORME POR CLIENTE"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtnom As System.Windows.Forms.TextBox
    Friend WithEvents txttip As System.Windows.Forms.TextBox
    Friend WithEvents c2 As System.Windows.Forms.RadioButton
    Friend WithEvents c1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents d2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents d1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtdi2 As System.Windows.Forms.TextBox
    Friend WithEvents txtdi1 As System.Windows.Forms.TextBox
    Friend WithEvents cbfin As System.Windows.Forms.ComboBox
    Friend WithEvents txtpfin As System.Windows.Forms.TextBox
    Friend WithEvents cbini As System.Windows.Forms.ComboBox
    Friend WithEvents txtpini As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdpantalla As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents chcli As System.Windows.Forms.CheckBox
End Class
