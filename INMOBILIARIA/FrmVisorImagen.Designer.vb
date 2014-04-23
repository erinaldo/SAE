<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVisorImagen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVisorImagen))
        Me.Imagen2 = New System.Windows.Forms.PictureBox
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.CmdSiguiente = New System.Windows.Forms.Button
        Me.Lbdes = New System.Windows.Forms.Label
        Me.CmdAtras = New System.Windows.Forms.Button
        Me.txtinm = New System.Windows.Forms.TextBox
        Me.lbnum = New System.Windows.Forms.Label
        CType(Me.Imagen2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Imagen2
        '
        Me.Imagen2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Imagen2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Imagen2.Location = New System.Drawing.Point(0, 0)
        Me.Imagen2.Name = "Imagen2"
        Me.Imagen2.Size = New System.Drawing.Size(781, 429)
        Me.Imagen2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Imagen2.TabIndex = 0
        Me.Imagen2.TabStop = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Imagen2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lbnum)
        Me.SplitContainer1.Panel2.Controls.Add(Me.CmdSiguiente)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Lbdes)
        Me.SplitContainer1.Panel2.Controls.Add(Me.CmdAtras)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtinm)
        Me.SplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SplitContainer1.Size = New System.Drawing.Size(781, 514)
        Me.SplitContainer1.SplitterDistance = 429
        Me.SplitContainer1.TabIndex = 1
        '
        'CmdSiguiente
        '
        Me.CmdSiguiente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdSiguiente.Image = CType(resources.GetObject("CmdSiguiente.Image"), System.Drawing.Image)
        Me.CmdSiguiente.Location = New System.Drawing.Point(386, 31)
        Me.CmdSiguiente.Name = "CmdSiguiente"
        Me.CmdSiguiente.Size = New System.Drawing.Size(52, 38)
        Me.CmdSiguiente.TabIndex = 16
        Me.CmdSiguiente.UseVisualStyleBackColor = True
        '
        'Lbdes
        '
        Me.Lbdes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbdes.AutoSize = True
        Me.Lbdes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbdes.Location = New System.Drawing.Point(329, 12)
        Me.Lbdes.Name = "Lbdes"
        Me.Lbdes.Size = New System.Drawing.Size(91, 13)
        Me.Lbdes.TabIndex = 2
        Me.Lbdes.Text = "DESCRIPCION"
        Me.Lbdes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CmdAtras
        '
        Me.CmdAtras.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CmdAtras.Image = CType(resources.GetObject("CmdAtras.Image"), System.Drawing.Image)
        Me.CmdAtras.Location = New System.Drawing.Point(304, 31)
        Me.CmdAtras.Name = "CmdAtras"
        Me.CmdAtras.Size = New System.Drawing.Size(52, 38)
        Me.CmdAtras.TabIndex = 15
        Me.CmdAtras.Text = " "
        Me.CmdAtras.UseVisualStyleBackColor = True
        '
        'txtinm
        '
        Me.txtinm.Location = New System.Drawing.Point(695, 25)
        Me.txtinm.Name = "txtinm"
        Me.txtinm.Size = New System.Drawing.Size(65, 20)
        Me.txtinm.TabIndex = 1
        Me.txtinm.Visible = False
        '
        'lbnum
        '
        Me.lbnum.AutoSize = True
        Me.lbnum.Location = New System.Drawing.Point(51, 21)
        Me.lbnum.Name = "lbnum"
        Me.lbnum.Size = New System.Drawing.Size(39, 13)
        Me.lbnum.TabIndex = 17
        Me.lbnum.Text = "Label1"
        Me.lbnum.Visible = False
        '
        'FrmVisorImagen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(781, 514)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "FrmVisorImagen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Visor de Imagen"
        CType(Me.Imagen2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Imagen2 As System.Windows.Forms.PictureBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Lbdes As System.Windows.Forms.Label
    Friend WithEvents txtinm As System.Windows.Forms.TextBox
    Friend WithEvents CmdSiguiente As System.Windows.Forms.Button
    Friend WithEvents CmdAtras As System.Windows.Forms.Button
    Friend WithEvents lbnum As System.Windows.Forms.Label
End Class
