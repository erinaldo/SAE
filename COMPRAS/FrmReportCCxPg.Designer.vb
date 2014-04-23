<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportCCxPg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReportCCxPg))
        Me.ReportOrdenP1 = New SAE.ReportOrdenP
        Me.ReportDeducc1 = New SAE.ReportDeducc
        Me.ReportOrdResol1 = New SAE.ReportOrdResol
        Me.ReportInfOrden1 = New SAE.ReportInfOrden
        Me.ReportComprOrden1 = New SAE.ReportComprOrden
        Me.ReportOrdenPago1 = New SAE.ReportOrdenPago
        Me.ReportCCxPg1 = New SAE.ReportCCxPg
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.ReportConciB1 = New SAE.ReportConciB
        Me.ReportCIorden1 = New SAE.ReportCIorden
        Me.ReportComprOrden31 = New SAE.ReportComprOrden3
        Me.ReportNCE1 = New SAE.ReportNCE
        Me.ReportCompOrdenP1 = New SAE.ReportCompOrdenP
        Me.ReportEgreRb1 = New SAE.ReportEgreRb
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
        Me.CrystalReportViewer1.ReportSource = Me.ReportEgreRb1
        Me.CrystalReportViewer1.ShowRefreshButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(415, 319)
        Me.CrystalReportViewer1.TabIndex = 0
        '
        'FrmReportCCxPg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 319)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmReportCCxPg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Informe "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents ReportCCxPg1 As SAE.ReportCCxPg
    Friend WithEvents ReportOrdenPago1 As SAE.ReportOrdenPago
    Friend WithEvents ReportComprOrden1 As SAE.ReportComprOrden
    Friend WithEvents ReportInfOrden1 As SAE.ReportInfOrden
    Friend WithEvents ReportOrdResol1 As SAE.ReportOrdResol
    Friend WithEvents ReportDeducc1 As SAE.ReportDeducc
    Friend WithEvents ReportOrdenP1 As SAE.ReportOrdenP
    Friend WithEvents ReportCompOrdenP1 As SAE.ReportCompOrdenP
    Friend WithEvents ReportNCE1 As SAE.ReportNCE
    Friend WithEvents ReportComprOrden31 As SAE.ReportComprOrden3
    Friend WithEvents ReportCIorden1 As SAE.ReportCIorden
    Friend WithEvents ReportConciB1 As SAE.ReportConciB
    Friend WithEvents ReportEgreRb1 As SAE.ReportEgreRb
End Class
