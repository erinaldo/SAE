<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportCMov_cue
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReportCMov_cue))
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.ReportUtilDiaria1 = New SAE.ReportUtilDiaria
        Me.ReportMovCentroCosto1 = New SAE.ReportMovCentroCosto
        Me.ReportCheque1 = New SAE.ReportCheque
        Me.ReportCMovContablResA1 = New SAE.ReportCMovContablResA
        Me.ReportCMovContablRes1 = New SAE.ReportCMovContablRes
        Me.ReportCMovContabl1 = New SAE.ReportCMovContabl
        Me.ReportCMov_cue1 = New SAE.ReportCMov_cue
        Me.ReportTransCuenta1 = New SAE.ReportTransCuenta
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = 0
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.ReportSource = Me.ReportTransCuenta1
        Me.CrystalReportViewer1.ShowRefreshButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(432, 317)
        Me.CrystalReportViewer1.TabIndex = 0
        '
        'FrmReportCMov_cue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(432, 317)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmReportCMov_cue"
        Me.Text = "Informe  Movimiento de Cuentas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents ReportCMov_cue1 As SAE.ReportCMov_cue
    Friend WithEvents ReportCMovContabl1 As SAE.ReportCMovContabl
    Friend WithEvents ReportCMovContablRes1 As SAE.ReportCMovContablRes
    Friend WithEvents ReportCMovContablResA1 As SAE.ReportCMovContablResA
    Friend WithEvents ReportCheque1 As SAE.ReportCheque
    Friend WithEvents ReportMovCentroCosto1 As SAE.ReportMovCentroCosto
    Friend WithEvents ReportUtilDiaria1 As SAE.ReportUtilDiaria
    Friend WithEvents ReportTransCuenta1 As SAE.ReportTransCuenta
End Class
