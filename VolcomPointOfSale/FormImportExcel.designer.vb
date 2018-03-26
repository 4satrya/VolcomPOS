<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormImportExcel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormImportExcel))
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.PBC = New DevExpress.XtraEditors.ProgressBarControl()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BImport = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.CBWorksheetName = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LFileAddress = New DevExpress.XtraEditors.LabelControl()
        Me.TBFileAddress = New DevExpress.XtraEditors.TextEdit()
        Me.LWorksheetName = New DevExpress.XtraEditors.LabelControl()
        Me.BBrowse = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl5 = New DevExpress.XtraEditors.PanelControl()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PBC.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.CBWorksheetName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TBFileAddress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.GCData)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(20, 141)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(794, 159)
        Me.GroupControl1.TabIndex = 5
        Me.GroupControl1.Text = "Data"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(2, 22)
        Me.GCData.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.GCData.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(790, 135)
        Me.GCData.TabIndex = 86
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData, Me.GridView2})
        '
        'GVData
        '
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GCData
        Me.GridView2.Name = "GridView2"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BtnPrint)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Controls.Add(Me.PBC)
        Me.PanelControl2.Controls.Add(Me.BCancel)
        Me.PanelControl2.Controls.Add(Me.BImport)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(20, 300)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(794, 32)
        Me.PanelControl2.TabIndex = 4
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Location = New System.Drawing.Point(522, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(90, 28)
        Me.BtnPrint.TabIndex = 93
        Me.BtnPrint.Text = "Print"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(172, 9)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(90, 13)
        Me.LabelControl1.TabIndex = 92
        Me.LabelControl1.Text = "-/- rows processed"
        Me.LabelControl1.Visible = False
        '
        'PBC
        '
        Me.PBC.Dock = System.Windows.Forms.DockStyle.Left
        Me.PBC.Location = New System.Drawing.Point(2, 2)
        Me.PBC.Name = "PBC"
        Me.PBC.Size = New System.Drawing.Size(157, 28)
        Me.PBC.TabIndex = 91
        '
        'BCancel
        '
        Me.BCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCancel.Location = New System.Drawing.Point(612, 2)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(90, 28)
        Me.BCancel.TabIndex = 90
        Me.BCancel.Text = "Cancel"
        '
        'BImport
        '
        Me.BImport.Dock = System.Windows.Forms.DockStyle.Right
        Me.BImport.Location = New System.Drawing.Point(702, 2)
        Me.BImport.Name = "BImport"
        Me.BImport.Size = New System.Drawing.Size(90, 28)
        Me.BImport.TabIndex = 89
        Me.BImport.Text = "Import"
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.Controls.Add(Me.CBWorksheetName)
        Me.PanelControl1.Controls.Add(Me.LFileAddress)
        Me.PanelControl1.Controls.Add(Me.TBFileAddress)
        Me.PanelControl1.Controls.Add(Me.LWorksheetName)
        Me.PanelControl1.Controls.Add(Me.BBrowse)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(20, 74)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(794, 67)
        Me.PanelControl1.TabIndex = 3
        '
        'CBWorksheetName
        '
        Me.CBWorksheetName.Location = New System.Drawing.Point(107, 34)
        Me.CBWorksheetName.Name = "CBWorksheetName"
        Me.CBWorksheetName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CBWorksheetName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.CBWorksheetName.Size = New System.Drawing.Size(440, 20)
        Me.CBWorksheetName.TabIndex = 89
        '
        'LFileAddress
        '
        Me.LFileAddress.Location = New System.Drawing.Point(10, 10)
        Me.LFileAddress.Name = "LFileAddress"
        Me.LFileAddress.Size = New System.Drawing.Size(83, 13)
        Me.LFileAddress.TabIndex = 85
        Me.LFileAddress.Text = "Excel file address"
        '
        'TBFileAddress
        '
        Me.TBFileAddress.Location = New System.Drawing.Point(107, 9)
        Me.TBFileAddress.Name = "TBFileAddress"
        Me.TBFileAddress.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White
        Me.TBFileAddress.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.TBFileAddress.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.TBFileAddress.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.TBFileAddress.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.TBFileAddress.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black
        Me.TBFileAddress.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TBFileAddress.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.TBFileAddress.Properties.ReadOnly = True
        Me.TBFileAddress.Size = New System.Drawing.Size(383, 20)
        Me.TBFileAddress.TabIndex = 87
        '
        'LWorksheetName
        '
        Me.LWorksheetName.Location = New System.Drawing.Point(10, 35)
        Me.LWorksheetName.Name = "LWorksheetName"
        Me.LWorksheetName.Size = New System.Drawing.Size(81, 13)
        Me.LWorksheetName.TabIndex = 86
        Me.LWorksheetName.Text = "Worksheet name"
        '
        'BBrowse
        '
        Me.BBrowse.Location = New System.Drawing.Point(496, 6)
        Me.BBrowse.Name = "BBrowse"
        Me.BBrowse.Size = New System.Drawing.Size(51, 23)
        Me.BBrowse.TabIndex = 88
        Me.BBrowse.Text = "Browse"
        '
        'PanelControl3
        '
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl3.Controls.Add(Me.LabelControl13)
        Me.PanelControl3.Controls.Add(Me.PanelControl5)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(20, 20)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(794, 54)
        Me.PanelControl3.TabIndex = 6
        '
        'LabelControl13
        '
        Me.LabelControl13.Appearance.Font = New System.Drawing.Font("Segoe UI Light", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl13.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl13.Dock = System.Windows.Forms.DockStyle.Left
        Me.LabelControl13.Location = New System.Drawing.Point(40, 0)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Padding = New System.Windows.Forms.Padding(5, 6, 0, 0)
        Me.LabelControl13.Size = New System.Drawing.Size(144, 43)
        Me.LabelControl13.TabIndex = 1
        Me.LabelControl13.Text = "Import Excel"
        '
        'PanelControl5
        '
        Me.PanelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl5.ContentImage = CType(resources.GetObject("PanelControl5.ContentImage"), System.Drawing.Image)
        Me.PanelControl5.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl5.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl5.Name = "PanelControl5"
        Me.PanelControl5.Size = New System.Drawing.Size(40, 54)
        Me.PanelControl5.TabIndex = 4
        '
        'FormImportExcel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 352)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PanelControl3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.LookAndFeel.SkinName = "Metropolis"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MinimizeBox = False
        Me.Name = "FormImportExcel"
        Me.Padding = New System.Windows.Forms.Padding(20)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import Data From Excel"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.PBC.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.CBWorksheetName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TBFileAddress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BImport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CBWorksheetName As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LFileAddress As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TBFileAddress As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LWorksheetName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BBrowse As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PBC As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl5 As DevExpress.XtraEditors.PanelControl
End Class
