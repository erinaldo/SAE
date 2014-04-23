<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGrafica
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGrafica))
        Me.ZedGraphControl1 = New ZedGraph.ZedGraphControl
        Me.lbform = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.Mi_Menu = New System.Windows.Forms.ToolStripMenuItem
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AtrásToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintForm1 = New Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ZedGraphControl1
        '
        Me.ZedGraphControl1.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.ZedGraphControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ZedGraphControl1.Enabled = False
        Me.ZedGraphControl1.Location = New System.Drawing.Point(2, 27)
        Me.ZedGraphControl1.Name = "ZedGraphControl1"
        Me.ZedGraphControl1.ScrollGrace = 0
        Me.ZedGraphControl1.ScrollMaxX = 0
        Me.ZedGraphControl1.ScrollMaxY = 0
        Me.ZedGraphControl1.ScrollMaxY2 = 0
        Me.ZedGraphControl1.ScrollMinX = 0
        Me.ZedGraphControl1.ScrollMinY = 0
        Me.ZedGraphControl1.ScrollMinY2 = 0
        Me.ZedGraphControl1.Size = New System.Drawing.Size(838, 541)
        Me.ZedGraphControl1.TabIndex = 4
        '
        'lbform
        '
        Me.lbform.AutoSize = True
        Me.lbform.Location = New System.Drawing.Point(175, 37)
        Me.lbform.Name = "lbform"
        Me.lbform.Size = New System.Drawing.Size(39, 13)
        Me.lbform.TabIndex = 5
        Me.lbform.Text = "Label1"
        Me.lbform.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Mi_Menu})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(842, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'Mi_Menu
        '
        Me.Mi_Menu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimirToolStripMenuItem, Me.AtrásToolStripMenuItem})
        Me.Mi_Menu.Name = "Mi_Menu"
        Me.Mi_Menu.Size = New System.Drawing.Size(60, 20)
        Me.Mi_Menu.Text = "&Archivo"
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.ImprimirToolStripMenuItem.Text = "&Imprimir"
        '
        'AtrásToolStripMenuItem
        '
        Me.AtrásToolStripMenuItem.Name = "AtrásToolStripMenuItem"
        Me.AtrásToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.AtrásToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.AtrásToolStripMenuItem.Text = "&Atrás"
        '
        'PrintForm1
        '
        Me.PrintForm1.DocumentName = "Graficas"
        Me.PrintForm1.Form = Me
        Me.PrintForm1.PrintAction = System.Drawing.Printing.PrintAction.PrintToPrinter
        Me.PrintForm1.PrinterSettings = CType(resources.GetObject("PrintForm1.PrinterSettings"), System.Drawing.Printing.PrinterSettings)
        Me.PrintForm1.PrintFileName = Nothing
        '
        'FrmGrafica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(842, 568)
        Me.Controls.Add(Me.lbform)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.ZedGraphControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmGrafica"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  SAE Gráficas     "
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ZedGraphControl1 As ZedGraph.ZedGraphControl
    Friend WithEvents lbform As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents Mi_Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AtrásToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintForm1 As Microsoft.VisualBasic.PowerPacks.Printing.PrintForm
End Class
