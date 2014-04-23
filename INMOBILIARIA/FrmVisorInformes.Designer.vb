<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVisorInformes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVisorInformes))
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.ReportInfServC1 = New SAE.ReportInfServC
        Me.ReportInfServD1 = New SAE.ReportInfServD
        Me.ReportInfServInm1 = New SAE.ReportInfServInm
        Me.ReportInfFacInm1 = New SAE.ReportInfFacInm
        Me.ReportInmNovT1 = New SAE.ReportInmNovT
        Me.ReportEstCuentArr1 = New SAE.ReportEstCuentArr
        Me.ReportContrato1 = New SAE.ReportContrato
        Me.ReportSaldosInici1 = New SAE.ReportSaldosInici
        Me.ReportInfPagServ1 = New SAE.ReportInfPagServ
        Me.ReportInmueble1 = New SAE.ReportInmueble
        Me.ReportNovedad1 = New SAE.ReportNovedad
        Me.ReportEstCProAnt1 = New SAE.ReportEstCProAnt
        Me.ReportEstCuen_Pro1 = New SAE.ReportEstCuen_Pro
        Me.ReportTercInmD1 = New SAE.ReportTercInmD
        Me.ReportInfCont1 = New SAE.ReportInfCont
        Me.ReportInmPro1 = New SAE.ReportInmPro
        Me.ReportInfInmu1 = New SAE.ReportInfInmu
        Me.ReportTercInm1 = New SAE.ReportTercInm
        Me.ReportEstCuent_inm1 = New SAE.ReportEstCuent_inm
        Me.ReportOtccinm1 = New SAE.ReportOtccinm
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
        Me.CrystalReportViewer1.ReportSource = Me.ReportOtccinm1
        Me.CrystalReportViewer1.ShowRefreshButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(549, 384)
        Me.CrystalReportViewer1.TabIndex = 0
        '
        'FrmVisorInformes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(549, 384)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmVisorInformes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Informe"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents ReportEstCuent_inm1 As SAE.ReportEstCuent_inm
    Friend WithEvents ReportTercInm1 As SAE.ReportTercInm
    Friend WithEvents ReportInfInmu1 As SAE.ReportInfInmu
    Friend WithEvents ReportInmPro1 As SAE.ReportInmPro
    Friend WithEvents ReportInfCont1 As SAE.ReportInfCont
    Friend WithEvents ReportTercInmD1 As SAE.ReportTercInmD
    Friend WithEvents ReportEstCuen_Pro1 As SAE.ReportEstCuen_Pro
    Friend WithEvents ReportEstCProAnt1 As SAE.ReportEstCProAnt
    Friend WithEvents ReportNovedad1 As SAE.ReportNovedad
    Friend WithEvents ReportInmueble1 As SAE.ReportInmueble
    Friend WithEvents ReportInfPagServ1 As SAE.ReportInfPagServ
    Friend WithEvents ReportSaldosInici1 As SAE.ReportSaldosInici
    Friend WithEvents ReportContrato1 As SAE.ReportContrato
    Friend WithEvents ReportEstCuentArr1 As SAE.ReportEstCuentArr
    Friend WithEvents ReportInmNovT1 As SAE.ReportInmNovT
    Friend WithEvents ReportInfFacInm1 As SAE.ReportInfFacInm
    Friend WithEvents ReportInfServInm1 As SAE.ReportInfServInm
    Friend WithEvents ReportInfServD1 As SAE.ReportInfServD
    Friend WithEvents ReportInfServC1 As SAE.ReportInfServC
    Friend WithEvents ReportOtccinm1 As SAE.ReportOtccinm
End Class
