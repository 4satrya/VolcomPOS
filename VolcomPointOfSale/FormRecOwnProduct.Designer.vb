<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRecOwnProduct
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormRecOwnProduct))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.TxtPreparedBy = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.DECreated = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtRecNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnBrowseTo = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtDelSlip = New DevExpress.XtraEditors.TextEdit()
        Me.TxtToName = New DevExpress.XtraEditors.TextEdit()
        Me.TxtToCode = New DevExpress.XtraEditors.TextEdit()
        Me.TxtFromName = New DevExpress.XtraEditors.TextEdit()
        Me.TxtFromCode = New DevExpress.XtraEditors.TextEdit()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl6 = New DevExpress.XtraEditors.PanelControl()
        Me.TextEdit8 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnScan = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.LEReportStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.MemoEdit1 = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.TxtPreparedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DECreated.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DECreated.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtRecNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDelSlip.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtToName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtToCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFromName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFromCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.PanelControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl6.SuspendLayout()
        CType(Me.TextEdit8.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemoEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Controls.Add(Me.BtnClose)
        Me.PanelControl1.Controls.Add(Me.BtnSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 496)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(854, 38)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnPrint
        '
        Me.BtnPrint.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.Appearance.Options.UseFont = True
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Enabled = False
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(601, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(85, 34)
        Me.BtnPrint.TabIndex = 4
        Me.BtnPrint.Text = "Print"
        '
        'BtnClose
        '
        Me.BtnClose.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.Appearance.Options.UseFont = True
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(686, 2)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(85, 34)
        Me.BtnClose.TabIndex = 3
        Me.BtnClose.Text = "Close"
        '
        'BtnSave
        '
        Me.BtnSave.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.Appearance.Options.UseFont = True
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
        Me.BtnSave.Location = New System.Drawing.Point(771, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(81, 34)
        Me.BtnSave.TabIndex = 2
        Me.BtnSave.Text = "Save"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.PanelControl3)
        Me.PanelControl2.Controls.Add(Me.BtnBrowseTo)
        Me.PanelControl2.Controls.Add(Me.LabelControl3)
        Me.PanelControl2.Controls.Add(Me.LabelControl2)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Controls.Add(Me.TxtDelSlip)
        Me.PanelControl2.Controls.Add(Me.TxtToName)
        Me.PanelControl2.Controls.Add(Me.TxtToCode)
        Me.PanelControl2.Controls.Add(Me.TxtFromName)
        Me.PanelControl2.Controls.Add(Me.TxtFromCode)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(854, 101)
        Me.PanelControl2.TabIndex = 1
        '
        'PanelControl3
        '
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl3.Controls.Add(Me.TxtPreparedBy)
        Me.PanelControl3.Controls.Add(Me.LabelControl6)
        Me.PanelControl3.Controls.Add(Me.DECreated)
        Me.PanelControl3.Controls.Add(Me.LabelControl5)
        Me.PanelControl3.Controls.Add(Me.TxtRecNumber)
        Me.PanelControl3.Controls.Add(Me.LabelControl4)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl3.Enabled = False
        Me.PanelControl3.Location = New System.Drawing.Point(528, 2)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(324, 97)
        Me.PanelControl3.TabIndex = 13
        '
        'TxtPreparedBy
        '
        Me.TxtPreparedBy.Enabled = False
        Me.TxtPreparedBy.Location = New System.Drawing.Point(104, 61)
        Me.TxtPreparedBy.Name = "TxtPreparedBy"
        Me.TxtPreparedBy.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPreparedBy.Properties.Appearance.Options.UseFont = True
        Me.TxtPreparedBy.Size = New System.Drawing.Size(208, 20)
        Me.TxtPreparedBy.TabIndex = 18
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(11, 64)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl6.TabIndex = 17
        Me.LabelControl6.Text = "Prepared By"
        '
        'DECreated
        '
        Me.DECreated.EditValue = Nothing
        Me.DECreated.Location = New System.Drawing.Point(104, 35)
        Me.DECreated.Name = "DECreated"
        Me.DECreated.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DECreated.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DECreated.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DECreated.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DECreated.Size = New System.Drawing.Size(208, 20)
        Me.DECreated.TabIndex = 16
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(11, 38)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl5.TabIndex = 15
        Me.LabelControl5.Text = "Created Date"
        '
        'TxtRecNumber
        '
        Me.TxtRecNumber.Enabled = False
        Me.TxtRecNumber.Location = New System.Drawing.Point(104, 9)
        Me.TxtRecNumber.Name = "TxtRecNumber"
        Me.TxtRecNumber.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRecNumber.Properties.Appearance.Options.UseFont = True
        Me.TxtRecNumber.Size = New System.Drawing.Size(208, 20)
        Me.TxtRecNumber.TabIndex = 14
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(11, 12)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(78, 13)
        Me.LabelControl4.TabIndex = 12
        Me.LabelControl4.Text = "Receive Number"
        '
        'BtnBrowseTo
        '
        Me.BtnBrowseTo.Image = CType(resources.GetObject("BtnBrowseTo.Image"), System.Drawing.Image)
        Me.BtnBrowseTo.Location = New System.Drawing.Point(380, 63)
        Me.BtnBrowseTo.Name = "BtnBrowseTo"
        Me.BtnBrowseTo.Size = New System.Drawing.Size(24, 20)
        Me.BtnBrowseTo.TabIndex = 11
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(19, 66)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(12, 13)
        Me.LabelControl3.TabIndex = 10
        Me.LabelControl3.Text = "To"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(19, 40)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl2.TabIndex = 9
        Me.LabelControl2.Text = "From"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(19, 14)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl1.TabIndex = 8
        Me.LabelControl1.Text = "Delivery Slip"
        '
        'TxtDelSlip
        '
        Me.TxtDelSlip.Enabled = False
        Me.TxtDelSlip.Location = New System.Drawing.Point(90, 11)
        Me.TxtDelSlip.Name = "TxtDelSlip"
        Me.TxtDelSlip.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDelSlip.Properties.Appearance.Options.UseFont = True
        Me.TxtDelSlip.Size = New System.Drawing.Size(314, 20)
        Me.TxtDelSlip.TabIndex = 7
        '
        'TxtToName
        '
        Me.TxtToName.Enabled = False
        Me.TxtToName.Location = New System.Drawing.Point(161, 63)
        Me.TxtToName.Name = "TxtToName"
        Me.TxtToName.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtToName.Properties.Appearance.Options.UseFont = True
        Me.TxtToName.Size = New System.Drawing.Size(216, 20)
        Me.TxtToName.TabIndex = 5
        '
        'TxtToCode
        '
        Me.TxtToCode.Enabled = False
        Me.TxtToCode.Location = New System.Drawing.Point(90, 63)
        Me.TxtToCode.Name = "TxtToCode"
        Me.TxtToCode.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtToCode.Properties.Appearance.Options.UseFont = True
        Me.TxtToCode.Size = New System.Drawing.Size(69, 20)
        Me.TxtToCode.TabIndex = 4
        '
        'TxtFromName
        '
        Me.TxtFromName.Enabled = False
        Me.TxtFromName.Location = New System.Drawing.Point(161, 37)
        Me.TxtFromName.Name = "TxtFromName"
        Me.TxtFromName.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFromName.Properties.Appearance.Options.UseFont = True
        Me.TxtFromName.Size = New System.Drawing.Size(243, 20)
        Me.TxtFromName.TabIndex = 3
        '
        'TxtFromCode
        '
        Me.TxtFromCode.Enabled = False
        Me.TxtFromCode.Location = New System.Drawing.Point(90, 37)
        Me.TxtFromCode.Name = "TxtFromCode"
        Me.TxtFromCode.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFromCode.Properties.Appearance.Options.UseFont = True
        Me.TxtFromCode.Size = New System.Drawing.Size(69, 20)
        Me.TxtFromCode.TabIndex = 2
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 138)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(854, 276)
        Me.GCData.TabIndex = 2
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.LEReportStatus)
        Me.PanelControl4.Controls.Add(Me.LabelControl7)
        Me.PanelControl4.Controls.Add(Me.MemoEdit1)
        Me.PanelControl4.Controls.Add(Me.LabelControl8)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl4.Location = New System.Drawing.Point(0, 414)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(854, 82)
        Me.PanelControl4.TabIndex = 3
        '
        'PanelControl6
        '
        Me.PanelControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl6.Controls.Add(Me.TextEdit8)
        Me.PanelControl6.Controls.Add(Me.LabelControl9)
        Me.PanelControl6.Controls.Add(Me.SimpleButton2)
        Me.PanelControl6.Controls.Add(Me.BtnScan)
        Me.PanelControl6.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl6.Location = New System.Drawing.Point(0, 101)
        Me.PanelControl6.Name = "PanelControl6"
        Me.PanelControl6.Size = New System.Drawing.Size(854, 37)
        Me.PanelControl6.TabIndex = 19
        '
        'TextEdit8
        '
        Me.TextEdit8.EditValue = ""
        Me.TextEdit8.Location = New System.Drawing.Point(90, 8)
        Me.TextEdit8.Name = "TextEdit8"
        Me.TextEdit8.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdit8.Properties.Appearance.Options.UseFont = True
        Me.TextEdit8.Size = New System.Drawing.Size(196, 20)
        Me.TextEdit8.TabIndex = 19
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Location = New System.Drawing.Point(19, 11)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl9.TabIndex = 21
        Me.LabelControl9.Text = "Item Code"
        '
        'BtnScan
        '
        Me.BtnScan.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnScan.Image = CType(resources.GetObject("BtnScan.Image"), System.Drawing.Image)
        Me.BtnScan.Location = New System.Drawing.Point(771, 0)
        Me.BtnScan.Name = "BtnScan"
        Me.BtnScan.Size = New System.Drawing.Size(83, 37)
        Me.BtnScan.TabIndex = 0
        Me.BtnScan.Text = "Add"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton2.Image = CType(resources.GetObject("SimpleButton2.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(689, 0)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(82, 37)
        Me.SimpleButton2.TabIndex = 1
        Me.SimpleButton2.Text = "Delete"
        '
        'LEReportStatus
        '
        Me.LEReportStatus.Location = New System.Drawing.Point(73, 46)
        Me.LEReportStatus.Name = "LEReportStatus"
        Me.LEReportStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEReportStatus.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_report_status", "Id", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("report_status", "Status")})
        Me.LEReportStatus.Size = New System.Drawing.Size(291, 20)
        Me.LEReportStatus.TabIndex = 24
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(19, 49)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl7.TabIndex = 21
        Me.LabelControl7.Text = "Status"
        '
        'MemoEdit1
        '
        Me.MemoEdit1.Location = New System.Drawing.Point(73, 8)
        Me.MemoEdit1.Name = "MemoEdit1"
        Me.MemoEdit1.Size = New System.Drawing.Size(767, 32)
        Me.MemoEdit1.TabIndex = 23
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(19, 10)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl8.TabIndex = 22
        Me.LabelControl8.Text = "Remark"
        '
        'FormRecOwnProduct
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(854, 534)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl6)
        Me.Controls.Add(Me.PanelControl4)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MinimizeBox = False
        Me.Name = "FormRecOwnProduct"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Received Own Product"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.TxtPreparedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DECreated.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DECreated.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtRecNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDelSlip.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtToName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtToCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFromName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFromCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        Me.PanelControl4.PerformLayout()
        CType(Me.PanelControl6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl6.ResumeLayout(False)
        Me.PanelControl6.PerformLayout()
        CType(Me.TextEdit8.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemoEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TxtDelSlip As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtToName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtToCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtFromName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtFromCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BtnBrowseTo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DECreated As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtRecNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtPreparedBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl6 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TextEdit8 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnScan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LEReportStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MemoEdit1 As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
End Class
