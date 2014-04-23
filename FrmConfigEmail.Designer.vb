<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfigEmail
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cbdia = New System.Windows.Forms.ComboBox
        Me.Chfin = New System.Windows.Forms.CheckBox
        Me.Chinicio = New System.Windows.Forms.CheckBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.gfacturacion = New System.Windows.Forms.GroupBox
        Me.ChFacVen = New System.Windows.Forms.CheckBox
        Me.ChFacDoc = New System.Windows.Forms.CheckBox
        Me.ginventarios = New System.Windows.Forms.GroupBox
        Me.ChInvCF = New System.Windows.Forms.CheckBox
        Me.ChInvDoc = New System.Windows.Forms.CheckBox
        Me.gcontabilidad = New System.Windows.Forms.GroupBox
        Me.ChLMB = New System.Windows.Forms.CheckBox
        Me.ChDiario = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtdestino2 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtdestino1 = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtpass2 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtpass1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtcorreo = New System.Windows.Forms.TextBox
        Me.cbhost = New System.Windows.Forms.ComboBox
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmdsalir = New System.Windows.Forms.Button
        Me.cmdemail = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.gfacturacion.SuspendLayout()
        Me.ginventarios.SuspendLayout()
        Me.gcontabilidad.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(569, 399)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.cbdia)
        Me.GroupBox5.Controls.Add(Me.Chfin)
        Me.GroupBox5.Controls.Add(Me.Chinicio)
        Me.GroupBox5.Location = New System.Drawing.Point(15, 331)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(540, 56)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Forma de Envio"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(19, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Día de Envío"
        '
        'cbdia
        '
        Me.cbdia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbdia.FormattingEnabled = True
        Me.cbdia.Items.AddRange(New Object() {"Todos Los Dias", "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo"})
        Me.cbdia.Location = New System.Drawing.Point(97, 23)
        Me.cbdia.Name = "cbdia"
        Me.cbdia.Size = New System.Drawing.Size(138, 21)
        Me.cbdia.TabIndex = 0
        '
        'Chfin
        '
        Me.Chfin.AutoSize = True
        Me.Chfin.Location = New System.Drawing.Point(390, 25)
        Me.Chfin.Name = "Chfin"
        Me.Chfin.Size = New System.Drawing.Size(133, 17)
        Me.Chfin.TabIndex = 2
        Me.Chfin.Text = "Al Cerrar La Aplicación"
        Me.Chfin.UseVisualStyleBackColor = True
        '
        'Chinicio
        '
        Me.Chinicio.AutoSize = True
        Me.Chinicio.Location = New System.Drawing.Point(250, 25)
        Me.Chinicio.Name = "Chinicio"
        Me.Chinicio.Size = New System.Drawing.Size(133, 17)
        Me.Chinicio.TabIndex = 1
        Me.Chinicio.Text = "Al Iniciar La Aplicación"
        Me.Chinicio.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.gfacturacion)
        Me.GroupBox4.Controls.Add(Me.ginventarios)
        Me.GroupBox4.Controls.Add(Me.gcontabilidad)
        Me.GroupBox4.Location = New System.Drawing.Point(15, 222)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(540, 104)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Reportes a Enviar"
        '
        'gfacturacion
        '
        Me.gfacturacion.Controls.Add(Me.ChFacVen)
        Me.gfacturacion.Controls.Add(Me.ChFacDoc)
        Me.gfacturacion.Location = New System.Drawing.Point(360, 19)
        Me.gfacturacion.Name = "gfacturacion"
        Me.gfacturacion.Size = New System.Drawing.Size(163, 75)
        Me.gfacturacion.TabIndex = 2
        Me.gfacturacion.TabStop = False
        Me.gfacturacion.Text = "Facturación"
        '
        'ChFacVen
        '
        Me.ChFacVen.AutoSize = True
        Me.ChFacVen.Location = New System.Drawing.Point(6, 45)
        Me.ChFacVen.Name = "ChFacVen"
        Me.ChFacVen.Size = New System.Drawing.Size(143, 17)
        Me.ChFacVen.TabIndex = 3
        Me.ChFacVen.Text = "Reporte Por Vendedores"
        Me.ChFacVen.UseVisualStyleBackColor = True
        '
        'ChFacDoc
        '
        Me.ChFacDoc.AutoSize = True
        Me.ChFacDoc.Location = New System.Drawing.Point(6, 22)
        Me.ChFacDoc.Name = "ChFacDoc"
        Me.ChFacDoc.Size = New System.Drawing.Size(152, 17)
        Me.ChFacDoc.TabIndex = 2
        Me.ChFacDoc.Text = "Resumen por Documentos"
        Me.ChFacDoc.UseVisualStyleBackColor = True
        '
        'ginventarios
        '
        Me.ginventarios.Controls.Add(Me.ChInvCF)
        Me.ginventarios.Controls.Add(Me.ChInvDoc)
        Me.ginventarios.Location = New System.Drawing.Point(188, 19)
        Me.ginventarios.Name = "ginventarios"
        Me.ginventarios.Size = New System.Drawing.Size(163, 75)
        Me.ginventarios.TabIndex = 1
        Me.ginventarios.TabStop = False
        Me.ginventarios.Text = "Inventarios"
        '
        'ChInvCF
        '
        Me.ChInvCF.AutoSize = True
        Me.ChInvCF.Location = New System.Drawing.Point(6, 45)
        Me.ChInvCF.Name = "ChInvCF"
        Me.ChInvCF.Size = New System.Drawing.Size(153, 17)
        Me.ChInvCF.TabIndex = 3
        Me.ChInvCF.Text = "Tarjeta Para Conteo Físico"
        Me.ChInvCF.UseVisualStyleBackColor = True
        '
        'ChInvDoc
        '
        Me.ChInvDoc.AutoSize = True
        Me.ChInvDoc.Location = New System.Drawing.Point(6, 22)
        Me.ChInvDoc.Name = "ChInvDoc"
        Me.ChInvDoc.Size = New System.Drawing.Size(152, 17)
        Me.ChInvDoc.TabIndex = 2
        Me.ChInvDoc.Text = "Resumen por Documentos"
        Me.ChInvDoc.UseVisualStyleBackColor = True
        '
        'gcontabilidad
        '
        Me.gcontabilidad.Controls.Add(Me.ChLMB)
        Me.gcontabilidad.Controls.Add(Me.ChDiario)
        Me.gcontabilidad.Location = New System.Drawing.Point(17, 19)
        Me.gcontabilidad.Name = "gcontabilidad"
        Me.gcontabilidad.Size = New System.Drawing.Size(163, 75)
        Me.gcontabilidad.TabIndex = 0
        Me.gcontabilidad.TabStop = False
        Me.gcontabilidad.Text = "Contabilidad"
        '
        'ChLMB
        '
        Me.ChLMB.AutoSize = True
        Me.ChLMB.Location = New System.Drawing.Point(7, 45)
        Me.ChLMB.Name = "ChLMB"
        Me.ChLMB.Size = New System.Drawing.Size(151, 17)
        Me.ChLMB.TabIndex = 1
        Me.ChLMB.Text = "Libro Mayor y de Balances"
        Me.ChLMB.UseVisualStyleBackColor = True
        '
        'ChDiario
        '
        Me.ChDiario.AutoSize = True
        Me.ChDiario.Location = New System.Drawing.Point(7, 22)
        Me.ChDiario.Name = "ChDiario"
        Me.ChDiario.Size = New System.Drawing.Size(134, 17)
        Me.ChDiario.TabIndex = 0
        Me.ChDiario.Text = "Comprobante de Diario"
        Me.ChDiario.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.txtdestino2)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtdestino1)
        Me.GroupBox3.Location = New System.Drawing.Point(14, 119)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(541, 100)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Correo Destino"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Correo Destino 2"
        '
        'txtdestino2
        '
        Me.txtdestino2.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtdestino2.Location = New System.Drawing.Point(110, 53)
        Me.txtdestino2.Name = "txtdestino2"
        Me.txtdestino2.Size = New System.Drawing.Size(408, 20)
        Me.txtdestino2.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Correo Destino 1"
        '
        'txtdestino1
        '
        Me.txtdestino1.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtdestino1.Location = New System.Drawing.Point(110, 25)
        Me.txtdestino1.Name = "txtdestino1"
        Me.txtdestino1.Size = New System.Drawing.Size(408, 20)
        Me.txtdestino1.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtpass2)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtpass1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtcorreo)
        Me.GroupBox2.Controls.Add(Me.cbhost)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(541, 100)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos Correo Origen"
        '
        'txtpass2
        '
        Me.txtpass2.Location = New System.Drawing.Point(355, 65)
        Me.txtpass2.Name = "txtpass2"
        Me.txtpass2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpass2.Size = New System.Drawing.Size(162, 20)
        Me.txtpass2.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(241, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Confirmar Contraseña"
        '
        'txtpass1
        '
        Me.txtpass1.Location = New System.Drawing.Point(73, 65)
        Me.txtpass1.Name = "txtpass1"
        Me.txtpass1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpass1.Size = New System.Drawing.Size(162, 20)
        Me.txtpass1.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Contraseña"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(127, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Correo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Host"
        '
        'txtcorreo
        '
        Me.txtcorreo.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtcorreo.Location = New System.Drawing.Point(171, 26)
        Me.txtcorreo.Name = "txtcorreo"
        Me.txtcorreo.Size = New System.Drawing.Size(345, 20)
        Me.txtcorreo.TabIndex = 1
        '
        'cbhost
        '
        Me.cbhost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbhost.FormattingEnabled = True
        Me.cbhost.Items.AddRange(New Object() {"hotmail", "gmail"})
        Me.cbhost.Location = New System.Drawing.Point(41, 25)
        Me.cbhost.Name = "cbhost"
        Me.cbhost.Size = New System.Drawing.Size(80, 21)
        Me.cbhost.TabIndex = 0
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmdsalir)
        Me.GroupPanel1.Controls.Add(Me.cmdemail)
        Me.GroupPanel1.Location = New System.Drawing.Point(7, 406)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(569, 85)
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
        Me.GroupPanel1.TabIndex = 33
        '
        'cmdsalir
        '
        Me.cmdsalir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdsalir.Image = Global.SAE.My.Resources.Resources.back
        Me.cmdsalir.Location = New System.Drawing.Point(288, 5)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(70, 70)
        Me.cmdsalir.TabIndex = 2
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdsalir, "Salir Alt + F4 ")
        Me.cmdsalir.UseVisualStyleBackColor = False
        '
        'cmdemail
        '
        Me.cmdemail.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdemail.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdemail.Image = Global.SAE.My.Resources.Resources.correo
        Me.cmdemail.Location = New System.Drawing.Point(214, 5)
        Me.cmdemail.Name = "cmdemail"
        Me.cmdemail.Size = New System.Drawing.Size(70, 70)
        Me.cmdemail.TabIndex = 0
        Me.cmdemail.Text = "&C"
        Me.cmdemail.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolTip1.SetToolTip(Me.cmdemail, "Configurar Email Alt + C")
        Me.cmdemail.UseVisualStyleBackColor = False
        '
        'FrmConfigEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(584, 496)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmConfigEmail"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Configuración Email Para Envios de Informes Períodicos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.gfacturacion.ResumeLayout(False)
        Me.gfacturacion.PerformLayout()
        Me.ginventarios.ResumeLayout(False)
        Me.ginventarios.PerformLayout()
        Me.gcontabilidad.ResumeLayout(False)
        Me.gcontabilidad.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbhost As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtcorreo As System.Windows.Forms.TextBox
    Friend WithEvents txtpass2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtpass1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtdestino2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtdestino1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents gcontabilidad As System.Windows.Forms.GroupBox
    Friend WithEvents gfacturacion As System.Windows.Forms.GroupBox
    Friend WithEvents ginventarios As System.Windows.Forms.GroupBox
    Friend WithEvents ChFacVen As System.Windows.Forms.CheckBox
    Friend WithEvents ChFacDoc As System.Windows.Forms.CheckBox
    Friend WithEvents ChInvCF As System.Windows.Forms.CheckBox
    Friend WithEvents ChInvDoc As System.Windows.Forms.CheckBox
    Friend WithEvents ChLMB As System.Windows.Forms.CheckBox
    Friend WithEvents ChDiario As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Chfin As System.Windows.Forms.CheckBox
    Friend WithEvents Chinicio As System.Windows.Forms.CheckBox
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents cmdemail As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbdia As System.Windows.Forms.ComboBox
End Class
