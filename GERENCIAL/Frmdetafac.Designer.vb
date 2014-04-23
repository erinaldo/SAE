<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frmdetafac
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
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.gdetaF = New System.Windows.Forms.DataGridView
        Me.lbtitulo = New System.Windows.Forms.Label
        Me.CmdSalir = New System.Windows.Forms.Button
        Me.item = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descrip = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cant = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.valor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1.SuspendLayout()
        CType(Me.gdetaF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(8, 38)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(667, 23)
        Me.Panel1.TabIndex = 43
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(4, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "ITEM"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(584, 4)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
        Me.Label8.TabIndex = 41
        Me.Label8.Text = "VALOR"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(485, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "CANTIDAD"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(260, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "DESCRIPCION"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(59, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "CODIGO"
        '
        'gdetaF
        '
        Me.gdetaF.AllowUserToAddRows = False
        Me.gdetaF.AllowUserToDeleteRows = False
        Me.gdetaF.AllowUserToResizeColumns = False
        Me.gdetaF.AllowUserToResizeRows = False
        Me.gdetaF.BackgroundColor = System.Drawing.Color.White
        Me.gdetaF.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gdetaF.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.gdetaF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gdetaF.ColumnHeadersVisible = False
        Me.gdetaF.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.item, Me.codigo, Me.descrip, Me.cant, Me.valor})
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gdetaF.DefaultCellStyle = DataGridViewCellStyle23
        Me.gdetaF.Location = New System.Drawing.Point(8, 61)
        Me.gdetaF.Name = "gdetaF"
        Me.gdetaF.ReadOnly = True
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gdetaF.RowHeadersDefaultCellStyle = DataGridViewCellStyle24
        Me.gdetaF.RowHeadersVisible = False
        Me.gdetaF.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gdetaF.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gdetaF.Size = New System.Drawing.Size(667, 249)
        Me.gdetaF.TabIndex = 44
        '
        'lbtitulo
        '
        Me.lbtitulo.AutoSize = True
        Me.lbtitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbtitulo.Location = New System.Drawing.Point(12, 10)
        Me.lbtitulo.Name = "lbtitulo"
        Me.lbtitulo.Size = New System.Drawing.Size(104, 13)
        Me.lbtitulo.TabIndex = 45
        Me.lbtitulo.Text = "DETALLES DOC "
        '
        'CmdSalir
        '
        Me.CmdSalir.Image = Global.SAE.My.Resources.Resources.salir
        Me.CmdSalir.Location = New System.Drawing.Point(618, -1)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(52, 35)
        Me.CmdSalir.TabIndex = 46
        Me.CmdSalir.UseVisualStyleBackColor = True
        '
        'item
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.item.DefaultCellStyle = DataGridViewCellStyle18
        Me.item.HeaderText = "item"
        Me.item.MinimumWidth = 50
        Me.item.Name = "item"
        Me.item.ReadOnly = True
        Me.item.Width = 50
        '
        'codigo
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.codigo.DefaultCellStyle = DataGridViewCellStyle19
        Me.codigo.HeaderText = "codigo"
        Me.codigo.MinimumWidth = 80
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.Width = 80
        '
        'descrip
        '
        DataGridViewCellStyle20.NullValue = Nothing
        Me.descrip.DefaultCellStyle = DataGridViewCellStyle20
        Me.descrip.HeaderText = "descrip"
        Me.descrip.MinimumWidth = 350
        Me.descrip.Name = "descrip"
        Me.descrip.ReadOnly = True
        Me.descrip.Width = 350
        '
        'cant
        '
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle21.Format = "N2"
        DataGridViewCellStyle21.NullValue = Nothing
        Me.cant.DefaultCellStyle = DataGridViewCellStyle21
        Me.cant.HeaderText = "cantidad"
        Me.cant.MinimumWidth = 60
        Me.cant.Name = "cant"
        Me.cant.ReadOnly = True
        Me.cant.Width = 60
        '
        'valor
        '
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle22.Format = "N2"
        DataGridViewCellStyle22.NullValue = Nothing
        Me.valor.DefaultCellStyle = DataGridViewCellStyle22
        Me.valor.HeaderText = "valor"
        Me.valor.MinimumWidth = 120
        Me.valor.Name = "valor"
        Me.valor.ReadOnly = True
        Me.valor.Width = 120
        '
        'Frmdetafac
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(685, 320)
        Me.Controls.Add(Me.CmdSalir)
        Me.Controls.Add(Me.lbtitulo)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.gdetaF)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frmdetafac"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detalles de Documento"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.gdetaF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gdetaF As System.Windows.Forms.DataGridView
    Friend WithEvents lbtitulo As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descrip As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valor As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
