<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDept
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GCDept = New DevExpress.XtraGrid.GridControl()
        Me.GVDept = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.GCDept, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDept, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCDept
        '
        Me.GCDept.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDept.Location = New System.Drawing.Point(0, 0)
        Me.GCDept.MainView = Me.GVDept
        Me.GCDept.Name = "GCDept"
        Me.GCDept.Size = New System.Drawing.Size(487, 271)
        Me.GCDept.TabIndex = 0
        Me.GCDept.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDept})
        '
        'GVDept
        '
        Me.GVDept.GridControl = Me.GCDept
        Me.GVDept.Name = "GVDept"
        Me.GVDept.OptionsBehavior.Editable = False
        Me.GVDept.OptionsView.ShowGroupPanel = False
        '
        'FormDept
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 271)
        Me.Controls.Add(Me.GCDept)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormDept"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Departement"
        CType(Me.GCDept, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDept, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCDept As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDept As DevExpress.XtraGrid.Views.Grid.GridView
End Class
