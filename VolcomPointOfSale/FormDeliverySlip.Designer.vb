<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDeliverySlip
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
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GridColumid_delivery_slip = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_pl_sales_order_del = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnitem_code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnitem_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnqty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndesign_cat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnprice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnamount = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumid_delivery_slip, Me.GridColumnid_pl_sales_order_del, Me.GridColumnnumber, Me.GridColumncreated_date, Me.GridColumnitem_code, Me.GridColumnitem_name, Me.GridColumnqty, Me.GridColumndesign_cat, Me.GridColumnprice, Me.GridColumnamount})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(669, 420)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GridColumid_delivery_slip
        '
        Me.GridColumid_delivery_slip.Caption = "id_delivery_slip"
        Me.GridColumid_delivery_slip.FieldName = "id_delivery_slip"
        Me.GridColumid_delivery_slip.Name = "GridColumid_delivery_slip"
        '
        'GridColumnid_pl_sales_order_del
        '
        Me.GridColumnid_pl_sales_order_del.Caption = "id_pl_sales_order_del"
        Me.GridColumnid_pl_sales_order_del.FieldName = "id_pl_sales_order_del"
        Me.GridColumnid_pl_sales_order_del.Name = "GridColumnid_pl_sales_order_del"
        '
        'GridColumnnumber
        '
        Me.GridColumnnumber.Caption = "Number"
        Me.GridColumnnumber.FieldName = "number"
        Me.GridColumnnumber.Name = "GridColumnnumber"
        Me.GridColumnnumber.Visible = True
        Me.GridColumnnumber.VisibleIndex = 0
        '
        'GridColumncreated_date
        '
        Me.GridColumncreated_date.Caption = "Date"
        Me.GridColumncreated_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumncreated_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumncreated_date.FieldName = "created_date"
        Me.GridColumncreated_date.Name = "GridColumncreated_date"
        Me.GridColumncreated_date.Visible = True
        Me.GridColumncreated_date.VisibleIndex = 1
        '
        'GridColumnitem_code
        '
        Me.GridColumnitem_code.Caption = "Code"
        Me.GridColumnitem_code.FieldName = "item_code"
        Me.GridColumnitem_code.Name = "GridColumnitem_code"
        Me.GridColumnitem_code.Visible = True
        Me.GridColumnitem_code.VisibleIndex = 2
        '
        'GridColumnitem_name
        '
        Me.GridColumnitem_name.Caption = "Name"
        Me.GridColumnitem_name.FieldName = "item_name"
        Me.GridColumnitem_name.Name = "GridColumnitem_name"
        Me.GridColumnitem_name.Visible = True
        Me.GridColumnitem_name.VisibleIndex = 3
        '
        'GridColumnqty
        '
        Me.GridColumnqty.Caption = "Qty"
        Me.GridColumnqty.DisplayFormat.FormatString = "N0"
        Me.GridColumnqty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnqty.FieldName = "qty"
        Me.GridColumnqty.Name = "GridColumnqty"
        Me.GridColumnqty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N0}")})
        Me.GridColumnqty.Visible = True
        Me.GridColumnqty.VisibleIndex = 4
        '
        'GridColumndesign_cat
        '
        Me.GridColumndesign_cat.Caption = "Price Type"
        Me.GridColumndesign_cat.FieldName = "design_cat"
        Me.GridColumndesign_cat.Name = "GridColumndesign_cat"
        Me.GridColumndesign_cat.Visible = True
        Me.GridColumndesign_cat.VisibleIndex = 5
        '
        'GridColumnprice
        '
        Me.GridColumnprice.Caption = "Price"
        Me.GridColumnprice.DisplayFormat.FormatString = "N2"
        Me.GridColumnprice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnprice.FieldName = "price"
        Me.GridColumnprice.Name = "GridColumnprice"
        Me.GridColumnprice.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "price", "{0:N2}")})
        Me.GridColumnprice.Visible = True
        Me.GridColumnprice.VisibleIndex = 6
        '
        'GridColumnamount
        '
        Me.GridColumnamount.Caption = "Amount"
        Me.GridColumnamount.DisplayFormat.FormatString = "N2"
        Me.GridColumnamount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnamount.FieldName = "amount"
        Me.GridColumnamount.Name = "GridColumnamount"
        Me.GridColumnamount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        Me.GridColumnamount.UnboundExpression = "[qty] * [price]"
        Me.GridColumnamount.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnamount.Visible = True
        Me.GridColumnamount.VisibleIndex = 7
        '
        'FormDeliverySlip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 420)
        Me.Controls.Add(Me.GCData)
        Me.LookAndFeel.SkinName = "Visual Studio 2013 Light"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MinimizeBox = False
        Me.Name = "FormDeliverySlip"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delivery Slip Detail"
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridColumid_delivery_slip As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_pl_sales_order_del As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnitem_code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnitem_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnqty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndesign_cat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnprice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnamount As DevExpress.XtraGrid.Columns.GridColumn
End Class
