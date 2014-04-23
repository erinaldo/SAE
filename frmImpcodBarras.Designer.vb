<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImpcodBarras
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
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImpcodBarras))
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtmarca = New System.Windows.Forms.TextBox
        Me.gtDatos = New System.Windows.Forms.DataGridView
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Marca = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.precio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnVista = New System.Windows.Forms.Button
        Me.cbini = New System.Windows.Forms.ComboBox
        Me.vista = New System.Windows.Forms.PrintPreviewDialog
        Me.impresora = New System.Windows.Forms.PrintDialog
        Me.Documento = New System.Drawing.Printing.PrintDocument
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lbcant = New System.Windows.Forms.Label
        CType(Me.gtDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Filtar Codigos"
        '
        'txtmarca
        '
        Me.txtmarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtmarca.Location = New System.Drawing.Point(110, 17)
        Me.txtmarca.Name = "txtmarca"
        Me.txtmarca.Size = New System.Drawing.Size(100, 20)
        Me.txtmarca.TabIndex = 1
        '
        'gtDatos
        '
        Me.gtDatos.AllowUserToAddRows = False
        Me.gtDatos.AllowUserToDeleteRows = False
        Me.gtDatos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gtDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gtDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Descripcion, Me.Marca, Me.precio, Me.Cantidad})
        Me.gtDatos.GridColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gtDatos.Location = New System.Drawing.Point(12, 49)
        Me.gtDatos.Name = "gtDatos"
        Me.gtDatos.RowHeadersVisible = False
        Me.gtDatos.Size = New System.Drawing.Size(572, 326)
        Me.gtDatos.TabIndex = 4
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.MinimumWidth = 150
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 150
        '
        'Marca
        '
        Me.Marca.HeaderText = "Marca"
        Me.Marca.Name = "Marca"
        '
        'precio
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.precio.DefaultCellStyle = DataGridViewCellStyle17
        Me.precio.HeaderText = "Precio"
        Me.precio.Name = "precio"
        '
        'Cantidad
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle18
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        '
        'btnVista
        '
        Me.btnVista.Location = New System.Drawing.Point(266, 410)
        Me.btnVista.Name = "btnVista"
        Me.btnVista.Size = New System.Drawing.Size(75, 23)
        Me.btnVista.TabIndex = 5
        Me.btnVista.Text = "Vista Previa"
        Me.btnVista.UseVisualStyleBackColor = True
        '
        'cbini
        '
        Me.cbini.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbini.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbini.FormattingEnabled = True
        Me.cbini.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cbini.Location = New System.Drawing.Point(388, 14)
        Me.cbini.Name = "cbini"
        Me.cbini.Size = New System.Drawing.Size(50, 26)
        Me.cbini.TabIndex = 52
        '
        'vista
        '
        Me.vista.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.vista.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.vista.ClientSize = New System.Drawing.Size(400, 300)
        Me.vista.Enabled = True
        Me.vista.Icon = CType(resources.GetObject("vista.Icon"), System.Drawing.Icon)
        Me.vista.Name = "vista"
        Me.vista.Visible = False
        '
        'impresora
        '
        Me.impresora.UseEXDialog = True
        '
        'Documento
        '
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(246, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 13)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Cantidades del Periodo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(266, 383)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 13)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "Total Codigos a Imprimir"
        '
        'lbcant
        '
        Me.lbcant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbcant.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcant.Location = New System.Drawing.Point(419, 378)
        Me.lbcant.Name = "lbcant"
        Me.lbcant.Size = New System.Drawing.Size(134, 22)
        Me.lbcant.TabIndex = 55
        Me.lbcant.Text = "0"
        Me.lbcant.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmImpcodBarras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(597, 445)
        Me.Controls.Add(Me.lbcant)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbini)
        Me.Controls.Add(Me.btnVista)
        Me.Controls.Add(Me.gtDatos)
        Me.Controls.Add(Me.txtmarca)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmImpcodBarras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SAE Imprimir Codigo de Barra"
        CType(Me.gtDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtmarca As System.Windows.Forms.TextBox
    Friend WithEvents gtDatos As System.Windows.Forms.DataGridView
    Friend WithEvents btnVista As System.Windows.Forms.Button
    Friend WithEvents cbini As System.Windows.Forms.ComboBox
    Friend WithEvents vista As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents impresora As System.Windows.Forms.PrintDialog
    Friend WithEvents Documento As System.Drawing.Printing.PrintDocument
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Marca As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents precio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbcant As System.Windows.Forms.Label
End Class
