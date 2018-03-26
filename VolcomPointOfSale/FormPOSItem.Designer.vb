<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPOSItem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPOSItem))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAccept = New DevExpress.XtraEditors.SimpleButton()
        Me.GCItem = New DevExpress.XtraGrid.GridControl()
        Me.GVItem = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdItem = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnActive = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIsActive = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Controls.Add(Me.BtnAccept)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 292)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(511, 40)
        Me.PanelControl1.TabIndex = 1
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(417, 0)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(94, 40)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnAccept
        '
        Me.BtnAccept.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnAccept.Image = CType(resources.GetObject("BtnAccept.Image"), System.Drawing.Image)
        Me.BtnAccept.Location = New System.Drawing.Point(0, 0)
        Me.BtnAccept.Name = "BtnAccept"
        Me.BtnAccept.Size = New System.Drawing.Size(94, 40)
        Me.BtnAccept.TabIndex = 0
        Me.BtnAccept.Text = "Accept"
        '
        'GCItem
        '
        Me.GCItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCItem.Location = New System.Drawing.Point(0, 0)
        Me.GCItem.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.GCItem.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GCItem.MainView = Me.GVItem
        Me.GCItem.Name = "GCItem"
        Me.GCItem.Size = New System.Drawing.Size(511, 292)
        Me.GCItem.TabIndex = 0
        Me.GCItem.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVItem})
        '
        'GVItem
        '
        Me.GVItem.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdItem, Me.GridColumnCode, Me.GridColumnDescription, Me.GridColumnPrice, Me.GridColumnSize, Me.GridColumnActive, Me.GridColumnIsActive})
        Me.GVItem.GridControl = Me.GCItem
        Me.GVItem.Name = "GVItem"
        Me.GVItem.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVItem.OptionsBehavior.Editable = False
        Me.GVItem.OptionsCustomization.AllowColumnMoving = False
        Me.GVItem.OptionsCustomization.AllowFilter = False
        Me.GVItem.OptionsCustomization.AllowGroup = False
        Me.GVItem.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVItem.OptionsCustomization.AllowRowSizing = True
        Me.GVItem.OptionsFind.AlwaysVisible = True
        Me.GVItem.OptionsView.ShowGroupPanel = False
        Me.GVItem.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnCode, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnIdItem
        '
        Me.GridColumnIdItem.Caption = "Id"
        Me.GridColumnIdItem.FieldName = "id_item"
        Me.GridColumnIdItem.Name = "GridColumnIdItem"
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "item_code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 0
        Me.GridColumnCode.Width = 222
        '
        'GridColumnDescription
        '
        Me.GridColumnDescription.Caption = "Desription"
        Me.GridColumnDescription.FieldName = "item_name"
        Me.GridColumnDescription.Name = "GridColumnDescription"
        Me.GridColumnDescription.Visible = True
        Me.GridColumnDescription.VisibleIndex = 1
        Me.GridColumnDescription.Width = 467
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.Caption = "Price"
        Me.GridColumnPrice.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.Width = 341
        '
        'GridColumnSize
        '
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 2
        Me.GridColumnSize.Width = 57
        '
        'GridColumnActive
        '
        Me.GridColumnActive.Caption = "Status"
        Me.GridColumnActive.FieldName = "active"
        Me.GridColumnActive.Name = "GridColumnActive"
        Me.GridColumnActive.UnboundExpression = "Iif([is_active] = 1, 'Active', 'Not Active')"
        Me.GridColumnActive.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        '
        'GridColumnIsActive
        '
        Me.GridColumnIsActive.Caption = "IS_ACTIVE"
        Me.GridColumnIsActive.FieldName = "is_active"
        Me.GridColumnIsActive.Name = "GridColumnIsActive"
        '
        'FormPOSItem
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(511, 332)
        Me.Controls.Add(Me.GCItem)
        Me.Controls.Add(Me.PanelControl1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPOSItem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Product"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAccept As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCItem As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVItem As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdItem As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnActive As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIsActive As DevExpress.XtraGrid.Columns.GridColumn
End Class
