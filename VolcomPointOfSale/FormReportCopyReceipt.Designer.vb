<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReportCopyReceipt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormReportCopyReceipt))
        Me.PanelControlTitle = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControlBack = New DevExpress.XtraEditors.PanelControl()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPOS = New DevExpress.XtraTab.XtraTabPage()
        Me.BtnViewPOS = New DevExpress.XtraEditors.SimpleButton()
        Me.CEPOS = New DevExpress.XtraEditors.CheckEdit()
        Me.TxtPOSNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPClosing = New DevExpress.XtraTab.XtraTabPage()
        Me.BtnViewClosing = New DevExpress.XtraEditors.SimpleButton()
        Me.CEClosing = New DevExpress.XtraEditors.CheckEdit()
        Me.LECashier = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LEPOSDev = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LEShift = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PanelControlTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlTitle.SuspendLayout()
        CType(Me.PanelControlBack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XTPPOS.SuspendLayout()
        CType(Me.CEPOS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPOSNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPClosing.SuspendLayout()
        CType(Me.CEClosing.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LECashier.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEPOSDev.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEShift.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControlTitle
        '
        Me.PanelControlTitle.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlTitle.Controls.Add(Me.LabelControl13)
        Me.PanelControlTitle.Controls.Add(Me.PanelControlBack)
        Me.PanelControlTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlTitle.Location = New System.Drawing.Point(20, 20)
        Me.PanelControlTitle.Name = "PanelControlTitle"
        Me.PanelControlTitle.Size = New System.Drawing.Size(608, 61)
        Me.PanelControlTitle.TabIndex = 5
        '
        'LabelControl13
        '
        Me.LabelControl13.Appearance.Font = New System.Drawing.Font("Segoe UI Light", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl13.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl13.Dock = System.Windows.Forms.DockStyle.Left
        Me.LabelControl13.Location = New System.Drawing.Point(40, 0)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Padding = New System.Windows.Forms.Padding(5, 9, 0, 0)
        Me.LabelControl13.Size = New System.Drawing.Size(155, 46)
        Me.LabelControl13.TabIndex = 1
        Me.LabelControl13.Text = "Copy Receipt"
        '
        'PanelControlBack
        '
        Me.PanelControlBack.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlBack.ContentImage = CType(resources.GetObject("PanelControlBack.ContentImage"), System.Drawing.Image)
        Me.PanelControlBack.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControlBack.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlBack.Name = "PanelControlBack"
        Me.PanelControlBack.Size = New System.Drawing.Size(40, 61)
        Me.PanelControlBack.TabIndex = 4
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(20, 81)
        Me.XtraTabControl1.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.XtraTabControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XTPPOS
        Me.XtraTabControl1.Size = New System.Drawing.Size(608, 246)
        Me.XtraTabControl1.TabIndex = 6
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPOS, Me.XTPClosing})
        '
        'XTPPOS
        '
        Me.XTPPOS.Controls.Add(Me.BtnViewPOS)
        Me.XTPPOS.Controls.Add(Me.CEPOS)
        Me.XTPPOS.Controls.Add(Me.TxtPOSNumber)
        Me.XTPPOS.Controls.Add(Me.LabelControl1)
        Me.XTPPOS.Name = "XTPPOS"
        Me.XTPPOS.Size = New System.Drawing.Size(602, 218)
        Me.XTPPOS.Text = "POS Receipt "
        '
        'BtnViewPOS
        '
        Me.BtnViewPOS.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnViewPOS.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnViewPOS.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnViewPOS.Appearance.Options.UseBackColor = True
        Me.BtnViewPOS.Appearance.Options.UseFont = True
        Me.BtnViewPOS.Appearance.Options.UseForeColor = True
        Me.BtnViewPOS.Location = New System.Drawing.Point(13, 64)
        Me.BtnViewPOS.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnViewPOS.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Red
        Me.BtnViewPOS.LookAndFeel.SkinName = "Metropolis"
        Me.BtnViewPOS.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnViewPOS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnViewPOS.Name = "BtnViewPOS"
        Me.BtnViewPOS.Size = New System.Drawing.Size(58, 20)
        Me.BtnViewPOS.TabIndex = 3
        Me.BtnViewPOS.Text = "Process"
        '
        'CEPOS
        '
        Me.CEPOS.Location = New System.Drawing.Point(275, 38)
        Me.CEPOS.Name = "CEPOS"
        Me.CEPOS.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CEPOS.Properties.Appearance.Options.UseFont = True
        Me.CEPOS.Properties.Caption = "Preview Only"
        Me.CEPOS.Size = New System.Drawing.Size(138, 19)
        Me.CEPOS.TabIndex = 2
        '
        'TxtPOSNumber
        '
        Me.TxtPOSNumber.Location = New System.Drawing.Point(13, 38)
        Me.TxtPOSNumber.Name = "TxtPOSNumber"
        Me.TxtPOSNumber.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPOSNumber.Properties.Appearance.Options.UseFont = True
        Me.TxtPOSNumber.Size = New System.Drawing.Size(256, 20)
        Me.TxtPOSNumber.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(13, 19)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(103, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Transaction Number"
        '
        'XTPClosing
        '
        Me.XTPClosing.Controls.Add(Me.BtnViewClosing)
        Me.XTPClosing.Controls.Add(Me.CEClosing)
        Me.XTPClosing.Controls.Add(Me.LECashier)
        Me.XTPClosing.Controls.Add(Me.LabelControl4)
        Me.XTPClosing.Controls.Add(Me.LEPOSDev)
        Me.XTPClosing.Controls.Add(Me.LabelControl5)
        Me.XTPClosing.Controls.Add(Me.LEShift)
        Me.XTPClosing.Controls.Add(Me.LabelControl3)
        Me.XTPClosing.Controls.Add(Me.DEFrom)
        Me.XTPClosing.Controls.Add(Me.LabelControl2)
        Me.XTPClosing.Name = "XTPClosing"
        Me.XTPClosing.Size = New System.Drawing.Size(602, 218)
        Me.XTPClosing.Text = "Closing Receipt"
        '
        'BtnViewClosing
        '
        Me.BtnViewClosing.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnViewClosing.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnViewClosing.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnViewClosing.Appearance.Options.UseBackColor = True
        Me.BtnViewClosing.Appearance.Options.UseFont = True
        Me.BtnViewClosing.Appearance.Options.UseForeColor = True
        Me.BtnViewClosing.Location = New System.Drawing.Point(15, 104)
        Me.BtnViewClosing.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnViewClosing.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Red
        Me.BtnViewClosing.LookAndFeel.SkinName = "Metropolis"
        Me.BtnViewClosing.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnViewClosing.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnViewClosing.Name = "BtnViewClosing"
        Me.BtnViewClosing.Size = New System.Drawing.Size(58, 20)
        Me.BtnViewClosing.TabIndex = 16
        Me.BtnViewClosing.Text = "Process"
        '
        'CEClosing
        '
        Me.CEClosing.Location = New System.Drawing.Point(329, 68)
        Me.CEClosing.Name = "CEClosing"
        Me.CEClosing.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CEClosing.Properties.Appearance.Options.UseFont = True
        Me.CEClosing.Properties.Caption = "Preview Only"
        Me.CEClosing.Size = New System.Drawing.Size(138, 19)
        Me.CEClosing.TabIndex = 15
        '
        'LECashier
        '
        Me.LECashier.Location = New System.Drawing.Point(75, 68)
        Me.LECashier.Name = "LECashier"
        Me.LECashier.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LECashier.Properties.Appearance.Options.UseFont = True
        Me.LECashier.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LECashier.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_user", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("employee_name", "Name")})
        Me.LECashier.Size = New System.Drawing.Size(248, 20)
        Me.LECashier.TabIndex = 14
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(15, 71)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(38, 13)
        Me.LabelControl4.TabIndex = 13
        Me.LabelControl4.Text = "Cashier"
        '
        'LEPOSDev
        '
        Me.LEPOSDev.Location = New System.Drawing.Point(177, 42)
        Me.LEPOSDev.Name = "LEPOSDev"
        Me.LEPOSDev.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LEPOSDev.Properties.Appearance.Options.UseFont = True
        Me.LEPOSDev.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEPOSDev.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_pos_dev", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("pos_dev", "POS")})
        Me.LEPOSDev.Size = New System.Drawing.Size(146, 20)
        Me.LEPOSDev.TabIndex = 11
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(150, 45)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl5.TabIndex = 12
        Me.LabelControl5.Text = "POS"
        '
        'LEShift
        '
        Me.LEShift.Location = New System.Drawing.Point(75, 42)
        Me.LEShift.Name = "LEShift"
        Me.LEShift.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LEShift.Properties.Appearance.Options.UseFont = True
        Me.LEShift.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEShift.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_shift_type", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("shift_type", "Shift")})
        Me.LEShift.Size = New System.Drawing.Size(69, 20)
        Me.LEShift.TabIndex = 8
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(15, 45)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl3.TabIndex = 9
        Me.LabelControl3.Text = "Shift"
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(75, 16)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEFrom.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DEFrom.Properties.Appearance.Options.UseFont = True
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFrom.Size = New System.Drawing.Size(248, 20)
        Me.DEFrom.TabIndex = 2
        Me.DEFrom.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(15, 19)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "Date"
        '
        'FormReportCopyReceipt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(648, 347)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.PanelControlTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.LookAndFeel.SkinName = "Metropolis"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormReportCopyReceipt"
        Me.Padding = New System.Windows.Forms.Padding(20)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormReportCopyReceipt"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControlTitle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlTitle.ResumeLayout(False)
        Me.PanelControlTitle.PerformLayout()
        CType(Me.PanelControlBack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XTPPOS.ResumeLayout(False)
        Me.XTPPOS.PerformLayout()
        CType(Me.CEPOS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPOSNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPClosing.ResumeLayout(False)
        Me.XTPClosing.PerformLayout()
        CType(Me.CEClosing.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LECashier.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEPOSDev.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEShift.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControlTitle As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControlBack As DevExpress.XtraEditors.PanelControl
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPOS As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents CEPOS As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents TxtPOSNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnViewPOS As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XTPClosing As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LEShift As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEPOSDev As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LECashier As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnViewClosing As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CEClosing As DevExpress.XtraEditors.CheckEdit
End Class
