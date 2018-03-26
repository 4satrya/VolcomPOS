<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportTransSum
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelTime = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.LTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelStatus = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelUntil = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelFrom = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelControlSalesContribution = New DevExpress.XtraEditors.LabelControl()
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCSales = New DevExpress.XtraGrid.GridControl()
        Me.GVSales = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnComm = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCons = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.WinControlContainer2 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.WinControlContainer3 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCPayment = New DevExpress.XtraGrid.GridControl()
        Me.GVPayment = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPayment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCash = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCard = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnVoucher = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.WinControlContainer4 = New DevExpress.XtraReports.UI.WinControlContainer()
        CType(Me.GCSales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCPayment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPayment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer4, Me.WinControlContainer3, Me.WinControlContainer2, Me.WinControlContainer1})
        Me.Detail.HeightF = 513.5417!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelStatus, Me.XrLabel14, Me.XrLabel13, Me.LabelUntil, Me.XrLabel11, Me.XrLabel10, Me.LabelFrom, Me.XrLabel8, Me.XrLabel3, Me.LTitle})
        Me.TopMargin.HeightF = 112.5!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDate, Me.XrLabel1, Me.XrLabel2, Me.LabelTime, Me.XrLabel6, Me.XrLabel5, Me.XrPageInfo1})
        Me.BottomMargin.HeightF = 25.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel5
        '
        Me.XrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(114.8541!, 0!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(29.30629!, 19.16673!)
        Me.XrLabel5.StylePriority.UseBorders = False
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.Text = "Time"
        Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'XrLabel6
        '
        Me.XrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(144.1606!, 0.4488309!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(7.431259!, 18.71793!)
        Me.XrLabel6.StylePriority.UseBorders = False
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = ":"
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'LabelTime
        '
        Me.LabelTime.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelTime.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTime.LocationFloat = New DevExpress.Utils.PointFloat(151.5918!, 0!)
        Me.LabelTime.Name = "LabelTime"
        Me.LabelTime.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelTime.SizeF = New System.Drawing.SizeF(61.59798!, 19.16673!)
        Me.LabelTime.StylePriority.UseBorders = False
        Me.LabelTime.StylePriority.UseFont = False
        Me.LabelTime.StylePriority.UseTextAlignment = False
        Me.LabelTime.Text = "11:25:00"
        Me.LabelTime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'XrLabel2
        '
        Me.XrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(31.24161!, 0!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(7.431274!, 19.16673!)
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = ":"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'LabelDate
        '
        Me.LabelDate.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelDate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDate.LocationFloat = New DevExpress.Utils.PointFloat(38.67289!, 0!)
        Me.LabelDate.Name = "LabelDate"
        Me.LabelDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelDate.SizeF = New System.Drawing.SizeF(76.1813!, 19.16673!)
        Me.LabelDate.StylePriority.UseBorders = False
        Me.LabelDate.StylePriority.UseFont = False
        Me.LabelDate.StylePriority.UseTextAlignment = False
        Me.LabelDate.Text = "25/11/2015"
        Me.LabelDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'XrLabel1
        '
        Me.XrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.8936564!, 0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(30.34795!, 19.16673!)
        Me.XrLabel1.StylePriority.UseBorders = False
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "Date"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrPageInfo1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(961.9999!, 0.4487991!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(150.0!, 18.71793!)
        Me.XrPageInfo1.StylePriority.UseBorders = False
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'LTitle
        '
        Me.LTitle.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTitle.LocationFloat = New DevExpress.Utils.PointFloat(0!, 10.00001!)
        Me.LTitle.Name = "LTitle"
        Me.LTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTitle.SizeF = New System.Drawing.SizeF(313.4215!, 25.08335!)
        Me.LTitle.StylePriority.UseFont = False
        Me.LTitle.StylePriority.UseTextAlignment = False
        Me.LTitle.Text = "TRANSACTION SUMMARY"
        Me.LTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LabelStatus
        '
        Me.LabelStatus.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelStatus.LocationFloat = New DevExpress.Utils.PointFloat(61.7376!, 73.4375!)
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelStatus.SizeF = New System.Drawing.SizeF(251.6839!, 19.16673!)
        Me.LabelStatus.StylePriority.UseBorders = False
        Me.LabelStatus.StylePriority.UseFont = False
        Me.LabelStatus.StylePriority.UseTextAlignment = False
        Me.LabelStatus.Text = "Closed"
        Me.LabelStatus.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'XrLabel14
        '
        Me.XrLabel14.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel14.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(50.13965!, 73.4375!)
        Me.XrLabel14.Name = "XrLabel14"
        Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel14.SizeF = New System.Drawing.SizeF(11.59796!, 19.16673!)
        Me.XrLabel14.StylePriority.UseBorders = False
        Me.XrLabel14.StylePriority.UseFont = False
        Me.XrLabel14.StylePriority.UseTextAlignment = False
        Me.XrLabel14.Text = ":"
        Me.XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'XrLabel13
        '
        Me.XrLabel13.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel13.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(0.00003178914!, 73.4375!)
        Me.XrLabel13.Name = "XrLabel13"
        Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel13.SizeF = New System.Drawing.SizeF(50.13963!, 19.16673!)
        Me.XrLabel13.StylePriority.UseBorders = False
        Me.XrLabel13.StylePriority.UseFont = False
        Me.XrLabel13.StylePriority.UseTextAlignment = False
        Me.XrLabel13.Text = "Status"
        Me.XrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'LabelUntil
        '
        Me.LabelUntil.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelUntil.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelUntil.LocationFloat = New DevExpress.Utils.PointFloat(61.7376!, 54.27077!)
        Me.LabelUntil.Name = "LabelUntil"
        Me.LabelUntil.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelUntil.SizeF = New System.Drawing.SizeF(251.6839!, 19.16673!)
        Me.LabelUntil.StylePriority.UseBorders = False
        Me.LabelUntil.StylePriority.UseFont = False
        Me.LabelUntil.StylePriority.UseTextAlignment = False
        Me.LabelUntil.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'XrLabel11
        '
        Me.XrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel11.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(50.13965!, 54.27077!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(11.59796!, 19.16673!)
        Me.XrLabel11.StylePriority.UseBorders = False
        Me.XrLabel11.StylePriority.UseFont = False
        Me.XrLabel11.StylePriority.UseTextAlignment = False
        Me.XrLabel11.Text = ":"
        Me.XrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'XrLabel10
        '
        Me.XrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel10.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(0.00003178914!, 54.27077!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(50.13963!, 19.16673!)
        Me.XrLabel10.StylePriority.UseBorders = False
        Me.XrLabel10.StylePriority.UseFont = False
        Me.XrLabel10.StylePriority.UseTextAlignment = False
        Me.XrLabel10.Text = "Until"
        Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'LabelFrom
        '
        Me.LabelFrom.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelFrom.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFrom.LocationFloat = New DevExpress.Utils.PointFloat(61.7376!, 35.10402!)
        Me.LabelFrom.Name = "LabelFrom"
        Me.LabelFrom.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelFrom.SizeF = New System.Drawing.SizeF(251.6839!, 19.16673!)
        Me.LabelFrom.StylePriority.UseBorders = False
        Me.LabelFrom.StylePriority.UseFont = False
        Me.LabelFrom.StylePriority.UseTextAlignment = False
        Me.LabelFrom.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'XrLabel8
        '
        Me.XrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(50.13965!, 35.10402!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(11.59796!, 19.16673!)
        Me.XrLabel8.StylePriority.UseBorders = False
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.Text = ":"
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'XrLabel3
        '
        Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(0.00003178914!, 35.10402!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(50.13963!, 19.16673!)
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "From"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'LabelControlSalesContribution
        '
        Me.LabelControlSalesContribution.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControlSalesContribution.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelControlSalesContribution.Location = New System.Drawing.Point(0, 25)
        Me.LabelControlSalesContribution.Name = "LabelControlSalesContribution"
        Me.LabelControlSalesContribution.Padding = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.LabelControlSalesContribution.Size = New System.Drawing.Size(127, 25)
        Me.LabelControlSalesContribution.TabIndex = 10
        Me.LabelControlSalesContribution.Text = "SALES CONTRIBUTION"
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(132.0!, 26.0!)
        Me.WinControlContainer1.WinControl = Me.LabelControlSalesContribution
        '
        'GCSales
        '
        Me.GCSales.Location = New System.Drawing.Point(20, 153)
        Me.GCSales.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCSales.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GCSales.MainView = Me.GVSales
        Me.GCSales.Name = "GCSales"
        Me.GCSales.Size = New System.Drawing.Size(1068, 127)
        Me.GCSales.TabIndex = 11
        Me.GCSales.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSales})
        '
        'GVSales
        '
        Me.GVSales.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn, Me.GridColumn2, Me.GridColumn4, Me.GridColumnQty, Me.GridColumnTotal, Me.GridColumnComm, Me.GridColumnCons})
        Me.GVSales.GridControl = Me.GCSales
        Me.GVSales.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_qty", Me.GridColumnQty, "{0:n0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", Me.GridColumnTotal, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "commission", Me.GridColumnComm, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "consignment", Me.GridColumnCons, "{0:n2}")})
        Me.GVSales.Name = "GVSales"
        Me.GVSales.OptionsBehavior.Editable = False
        Me.GVSales.OptionsView.ShowFooter = True
        Me.GVSales.OptionsView.ShowGroupPanel = False
        '
        'GridColumn
        '
        Me.GridColumn.Caption = "NO"
        Me.GridColumn.FieldName = "no"
        Me.GridColumn.Name = "GridColumn"
        Me.GridColumn.Visible = True
        Me.GridColumn.VisibleIndex = 0
        Me.GridColumn.Width = 41
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "SUPPLIER CODE"
        Me.GridColumn2.FieldName = "comp_number"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 118
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "SUPPLIER"
        Me.GridColumn4.FieldName = "comp_name"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        Me.GridColumn4.Width = 182
        '
        'GridColumnQty
        '
        Me.GridColumnQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.Caption = "QTY"
        Me.GridColumnQty.DisplayFormat.FormatString = "{0:n0}"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "total_qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_qty", "{0:n0}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 3
        Me.GridColumnQty.Width = 53
        '
        'GridColumnTotal
        '
        Me.GridColumnTotal.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotal.Caption = "SALES"
        Me.GridColumnTotal.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotal.FieldName = "total"
        Me.GridColumnTotal.Name = "GridColumnTotal"
        Me.GridColumnTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:n2}")})
        Me.GridColumnTotal.Visible = True
        Me.GridColumnTotal.VisibleIndex = 4
        Me.GridColumnTotal.Width = 223
        '
        'GridColumnComm
        '
        Me.GridColumnComm.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnComm.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnComm.Caption = "COMMISSION"
        Me.GridColumnComm.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnComm.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnComm.FieldName = "commission"
        Me.GridColumnComm.Name = "GridColumnComm"
        Me.GridColumnComm.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "commission", "{0:n2}")})
        Me.GridColumnComm.Visible = True
        Me.GridColumnComm.VisibleIndex = 5
        Me.GridColumnComm.Width = 223
        '
        'GridColumnCons
        '
        Me.GridColumnCons.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnCons.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnCons.Caption = "CONSIGNMENT"
        Me.GridColumnCons.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnCons.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCons.FieldName = "consignment"
        Me.GridColumnCons.Name = "GridColumnCons"
        Me.GridColumnCons.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "consignment", "{0:n2}")})
        Me.GridColumnCons.Visible = True
        Me.GridColumnCons.VisibleIndex = 6
        Me.GridColumnCons.Width = 238
        '
        'WinControlContainer2
        '
        Me.WinControlContainer2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 25.99999!)
        Me.WinControlContainer2.Name = "WinControlContainer2"
        Me.WinControlContainer2.SizeF = New System.Drawing.SizeF(1112.0!, 132.375!)
        Me.WinControlContainer2.WinControl = Me.GCSales
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelControl2.Location = New System.Drawing.Point(0, 0)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Padding = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.LabelControl2.Size = New System.Drawing.Size(92, 25)
        Me.LabelControl2.TabIndex = 12
        Me.LabelControl2.Text = "SALES PAYMENT"
        '
        'WinControlContainer3
        '
        Me.WinControlContainer3.LocationFloat = New DevExpress.Utils.PointFloat(0.8936564!, 158.375!)
        Me.WinControlContainer3.Name = "WinControlContainer3"
        Me.WinControlContainer3.SizeF = New System.Drawing.SizeF(96.0!, 26.0!)
        Me.WinControlContainer3.WinControl = Me.LabelControl2
        '
        'GCPayment
        '
        Me.GCPayment.Location = New System.Drawing.Point(20, 403)
        Me.GCPayment.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCPayment.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GCPayment.MainView = Me.GVPayment
        Me.GCPayment.Name = "GCPayment"
        Me.GCPayment.Size = New System.Drawing.Size(1067, 316)
        Me.GCPayment.TabIndex = 13
        Me.GCPayment.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPayment})
        '
        'GVPayment
        '
        Me.GVPayment.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumnPayment, Me.GridColumnCash, Me.GridColumnCard, Me.GridColumnVoucher})
        Me.GVPayment.GridControl = Me.GCPayment
        Me.GVPayment.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cash", Me.GridColumnCash, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "card", Me.GridColumnCard, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "voucher", Me.GridColumnVoucher, "{0:n2}")})
        Me.GVPayment.Name = "GVPayment"
        Me.GVPayment.OptionsBehavior.Editable = False
        Me.GVPayment.OptionsView.ShowFooter = True
        Me.GVPayment.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "NO"
        Me.GridColumn1.FieldName = "no"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 50
        '
        'GridColumnPayment
        '
        Me.GridColumnPayment.Caption = "PAYMENT"
        Me.GridColumnPayment.FieldName = "payment"
        Me.GridColumnPayment.Name = "GridColumnPayment"
        Me.GridColumnPayment.Visible = True
        Me.GridColumnPayment.VisibleIndex = 1
        Me.GridColumnPayment.Width = 255
        '
        'GridColumnCash
        '
        Me.GridColumnCash.Caption = "CASH"
        Me.GridColumnCash.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnCash.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCash.FieldName = "cash"
        Me.GridColumnCash.Name = "GridColumnCash"
        Me.GridColumnCash.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cash", "{0:n2}")})
        Me.GridColumnCash.Visible = True
        Me.GridColumnCash.VisibleIndex = 2
        Me.GridColumnCash.Width = 255
        '
        'GridColumnCard
        '
        Me.GridColumnCard.Caption = "CARD"
        Me.GridColumnCard.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnCard.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCard.FieldName = "card"
        Me.GridColumnCard.Name = "GridColumnCard"
        Me.GridColumnCard.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "card", "{0:n2}")})
        Me.GridColumnCard.Visible = True
        Me.GridColumnCard.VisibleIndex = 3
        Me.GridColumnCard.Width = 255
        '
        'GridColumnVoucher
        '
        Me.GridColumnVoucher.Caption = "VOUCHER"
        Me.GridColumnVoucher.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnVoucher.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnVoucher.FieldName = "voucher"
        Me.GridColumnVoucher.Name = "GridColumnVoucher"
        Me.GridColumnVoucher.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "voucher", "{0:n2}")})
        Me.GridColumnVoucher.Visible = True
        Me.GridColumnVoucher.VisibleIndex = 4
        Me.GridColumnVoucher.Width = 263
        '
        'WinControlContainer4
        '
        Me.WinControlContainer4.LocationFloat = New DevExpress.Utils.PointFloat(0.8936564!, 184.375!)
        Me.WinControlContainer4.Name = "WinControlContainer4"
        Me.WinControlContainer4.SizeF = New System.Drawing.SizeF(1111.106!, 329.1667!)
        Me.WinControlContainer4.WinControl = Me.GCPayment
        '
        'ReportTransSum
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(25, 32, 112, 25)
        Me.PageHeight = 827
        Me.PageWidth = 1169
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.GCSales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCPayment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPayment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents LabelDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelTime As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents LTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelStatus As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelUntil As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelFrom As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents LabelControlSalesContribution As DevExpress.XtraEditors.LabelControl
    Friend WithEvents WinControlContainer2 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCSales As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSales As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnComm As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCons As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents WinControlContainer3 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents WinControlContainer4 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCPayment As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPayment As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPayment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCash As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCard As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnVoucher As DevExpress.XtraGrid.Columns.GridColumn
End Class
