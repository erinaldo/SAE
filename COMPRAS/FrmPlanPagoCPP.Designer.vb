﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPlanPagoCPP
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
        Me.txtfechavmto = New System.Windows.Forms.DateTimePicker
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.filtrofecha = New System.Windows.Forms.CheckBox
        Me.checkresumido = New System.Windows.Forms.CheckBox
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdpantalla = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.fecha2 = New System.Windows.Forms.DateTimePicker
        Me.fecha1 = New System.Windows.Forms.DateTimePicker
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtdias = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.chcli = New System.Windows.Forms.CheckBox
        Me.txtcliente = New System.Windows.Forms.TextBox
        Me.txtnitc = New System.Windows.Forms.TextBox
        Me.c2 = New System.Windows.Forms.RadioButton
        Me.c1 = New System.Windows.Forms.RadioButton
        Me.GroupPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtfechavmto
        '
        Me.txtfechavmto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtfechavmto.Location = New System.Drawing.Point(615, 34)
        Me.txtfechavmto.Name = "txtfechavmto"
        Me.txtfechavmto.Size = New System.Drawing.Size(78, 20)
        Me.txtfechavmto.TabIndex = 132
        Me.txtfechavmto.Value = New Date(2011, 9, 9, 0, 0, 0, 0)
        Me.txtfechavmto.Visible = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.TextBox1)
        Me.GroupPanel1.Controls.Add(Me.filtrofecha)
        Me.GroupPanel1.Controls.Add(Me.checkresumido)
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Controls.Add(Me.cmdpantalla)
        Me.GroupPanel1.Location = New System.Drawing.Point(5, 120)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(544, 85)
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
        Me.GroupPanel1.TabIndex = 2
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(375, 6)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(140, 20)
        Me.TextBox1.TabIndex = 130
        Me.TextBox1.Visible = False
        '
        'filtrofecha
        '
        Me.filtrofecha.AutoSize = True
        Me.filtrofecha.Checked = True
        Me.filtrofecha.CheckState = System.Windows.Forms.CheckState.Checked
        Me.filtrofecha.Location = New System.Drawing.Point(26, 52)
        Me.filtrofecha.Name = "filtrofecha"
        Me.filtrofecha.Size = New System.Drawing.Size(131, 17)
        Me.filtrofecha.TabIndex = 127
        Me.filtrofecha.Text = "Aplicar Filtro de Fecha"
        Me.filtrofecha.UseVisualStyleBackColor = True
        Me.filtrofecha.Visible = False
        '
        'checkresumido
        '
        Me.checkresumido.AutoSize = True
        Me.checkresumido.Location = New System.Drawing.Point(41, 15)
        Me.checkresumido.Name = "checkresumido"
        Me.checkresumido.Size = New System.Drawing.Size(73, 17)
        Me.checkresumido.TabIndex = 128
        Me.checkresumido.Text = "Resumido"
        Me.checkresumido.UseVisualStyleBackColor = True
        Me.checkresumido.Visible = False
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.atras
        Me.cmdsalir.Location = New System.Drawing.Point(273, 12)
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
        Me.cmdpantalla.Image = Global.SAE.My.Resources.Resources.pdf
        Me.cmdpantalla.Location = New System.Drawing.Point(208, 12)
        Me.cmdpantalla.Name = "cmdpantalla"
        Me.cmdpantalla.Size = New System.Drawing.Size(59, 57)
        Me.cmdpantalla.TabIndex = 14
        Me.cmdpantalla.Text = "&R"
        Me.cmdpantalla.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.cmdpantalla.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.fecha2)
        Me.GroupBox1.Controls.Add(Me.fecha1)
        Me.GroupBox1.Location = New System.Drawing.Point(562, 93)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(544, 71)
        Me.GroupBox1.TabIndex = 130
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fecha de Vencimiento"
        Me.GroupBox1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(182, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Fecha Final"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Fecha Inicial"
        '
        'fecha2
        '
        Me.fecha2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha2.Location = New System.Drawing.Point(248, 32)
        Me.fecha2.Name = "fecha2"
        Me.fecha2.Size = New System.Drawing.Size(78, 20)
        Me.fecha2.TabIndex = 1
        Me.fecha2.Value = New Date(2011, 9, 9, 0, 0, 0, 0)
        '
        'fecha1
        '
        Me.fecha1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha1.Location = New System.Drawing.Point(82, 33)
        Me.fecha1.Name = "fecha1"
        Me.fecha1.Size = New System.Drawing.Size(78, 20)
        Me.fecha1.TabIndex = 0
        Me.fecha1.Value = New Date(2011, 9, 9, 0, 0, 0, 0)
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtdias)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Location = New System.Drawing.Point(348, 13)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(169, 47)
        Me.GroupBox4.TabIndex = 1
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
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.chcli)
        Me.GroupBox3.Controls.Add(Me.txtcliente)
        Me.GroupBox3.Controls.Add(Me.txtnitc)
        Me.GroupBox3.Controls.Add(Me.c2)
        Me.GroupBox3.Controls.Add(Me.c1)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 9)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(544, 105)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Informe Para"
        '
        'chcli
        '
        Me.chcli.AutoSize = True
        Me.chcli.Location = New System.Drawing.Point(131, 48)
        Me.chcli.Name = "chcli"
        Me.chcli.Size = New System.Drawing.Size(152, 17)
        Me.chcli.TabIndex = 3
        Me.chcli.Text = "Buscar Cliente por Apellido"
        Me.chcli.UseVisualStyleBackColor = True
        Me.chcli.Visible = False
        '
        'txtcliente
        '
        Me.txtcliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtcliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtcliente.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtcliente.Enabled = False
        Me.txtcliente.Location = New System.Drawing.Point(131, 73)
        Me.txtcliente.Name = "txtcliente"
        Me.txtcliente.Size = New System.Drawing.Size(306, 20)
        Me.txtcliente.TabIndex = 4
        '
        'txtnitc
        '
        Me.txtnitc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnitc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtnitc.Enabled = False
        Me.txtnitc.Location = New System.Drawing.Point(15, 73)
        Me.txtnitc.MaxLength = 20
        Me.txtnitc.Name = "txtnitc"
        Me.txtnitc.Size = New System.Drawing.Size(111, 20)
        Me.txtnitc.TabIndex = 4
        '
        'c2
        '
        Me.c2.AutoSize = True
        Me.c2.Location = New System.Drawing.Point(16, 47)
        Me.c2.Name = "c2"
        Me.c2.Size = New System.Drawing.Size(91, 17)
        Me.c2.TabIndex = 2
        Me.c2.Text = "&Un Proveedor"
        Me.c2.UseVisualStyleBackColor = True
        '
        'c1
        '
        Me.c1.AutoSize = True
        Me.c1.Checked = True
        Me.c1.Location = New System.Drawing.Point(15, 20)
        Me.c1.Name = "c1"
        Me.c1.Size = New System.Drawing.Size(134, 17)
        Me.c1.TabIndex = 1
        Me.c1.TabStop = True
        Me.c1.Text = "&Todos los Proveedores"
        Me.c1.UseVisualStyleBackColor = True
        '
        'FrmPlanPagoCPP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(555, 209)
        Me.Controls.Add(Me.txtfechavmto)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPlanPagoCPP"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Plan Semanal Pagos"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtfechavmto As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdpantalla As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents checkresumido As System.Windows.Forms.CheckBox
    Friend WithEvents filtrofecha As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtdias As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fecha2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents fecha1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtcliente As System.Windows.Forms.TextBox
    Friend WithEvents txtnitc As System.Windows.Forms.TextBox
    Friend WithEvents c2 As System.Windows.Forms.RadioButton
    Friend WithEvents c1 As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents chcli As System.Windows.Forms.CheckBox
End Class
