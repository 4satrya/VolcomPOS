Public Class FormAdjIn
    Public id As String = "-1"
    Public action As String = "-1"
    Public id_comp As String = "-1"
    Dim id_report_status_glb As String = "-1"
    Dim role_prepared As String = ""
    Dim spv As String = ""

    Private Sub FormAdjIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub FormAdjIn_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormAdjIn_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F5 Then 'save
            save()
        ElseIf e.KeyCode = Keys.Escape Then 'close
            closeForm()
        ElseIf e.KeyCode = Keys.F7 Then 'select
            selectList()
        ElseIf e.KeyCode = Keys.F8 Then 'add scan
            addScan()
        ElseIf e.KeyCode = Keys.F9 Then 'remove scan
            removeScan()
        ElseIf e.KeyCode = Keys.F10 Then 'print
            print()
        ElseIf e.KeyCode = Keys.F11 Then 'load xls
            importExcel()
        End If
    End Sub

    Sub save()
        If id_report_status_glb <> "5" And id_report_status_glb <> "6" Then
            Dim adj_in_note As String = addSlashes(MENote.Text)
            Dim id_report_status As String = LEReportStatus.EditValue.ToString
            Dim gv As DevExpress.XtraGrid.Views.Grid.GridView
            gv = GVScanSum

            If id_comp = "-1" Or gv.RowCount = 0 Then
                stopCustom("Data can't blank")
            Else
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to save this transaction?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    If action = "ins" Then
                        'main query
                        Dim query As String = "INSERT INTO tb_adj_in(id_comp, adj_in_number, adj_in_date, adj_in_note, id_report_status, id_prepared_by) 
                        VALUES('" + id_comp + "', header_number(7), NOW(), '" + adj_in_note + "', '1', '" + id_user + "'); SELECT LAST_INSERT_ID(); "
                        id = execute_query(query, 0, True, "", "", "", "")

                        'detail
                        Dim query_det As String = "INSERT INTO tb_adj_in_det(id_adj_in, id_item, price, adj_in_qty) VALUES "
                        For i As Integer = 0 To ((GVScanSum.RowCount - 1) - GetGroupRowCount(GVScanSum))
                            Dim id_item As String = GVScanSum.GetRowCellValue(i, "id_item").ToString
                            Dim price As String = decimalSQL(GVScanSum.GetRowCellValue(i, "price").ToString)
                            Dim adj_in_qty As String = decimalSQL(GVScanSum.GetRowCellValue(i, "adj_in_qty").ToString)
                            If i > 0 Then
                                query_det += ", "
                            End If
                            query_det += "('" + id + "','" + id_item + "', '" + price + "', '" + adj_in_qty + "')"
                        Next
                        If GVScanSum.RowCount > 0 Then
                            execute_non_query(query_det, True, "", "", "", "")
                        End If

                        FormAdj.viewAdjIn()
                        FormAdj.GVAdjIn.FocusedRowHandle = find_row(FormAdj.GVAdjIn, "id_adj_in", id)
                        action = "upd"
                        actionLoad()
                        infoCustom("Document #" + TxtNumber.Text + " was created successfully.")
                    Else
                        Dim query As String = "UPDATE tb_adj_in SET id_comp='" + id_comp + "', 
                        adj_in_note='" + adj_in_note + "', id_report_status='" + id_report_status + "' "
                        If id_report_status = "5" Or id_report_status = "6" Then 'final
                            query += ", final_status_time=NOW() "
                        End If
                        query += "WHERE id_adj_in ='" + id + "' "
                        execute_non_query(query, True, "", "", "", "")

                        'completed
                        If id_report_status = "6" Then
                            Dim query_stock As String = "INSERT INTO tb_storage_item(id_comp, id_storage_category, id_item, report_mark_type, id_report, storage_item_qty, storage_item_datetime, id_stock_status) 
                            SELECT tb_adj_in.id_comp, 1, tb_adj_in_det.id_item, 7, " + id + ", tb_adj_in_det.adj_in_qty, NOW(), 1 
                            FROM tb_adj_in_det 
                            INNER JOIN tb_adj_in ON tb_adj_in.id_adj_in = tb_adj_in_det.id_adj_in
                            WHERE tb_adj_in_det.id_adj_in=" + id + ""
                            execute_non_query(query_stock, True, "", "", "", "")
                        End If

                        FormAdj.viewAdjIn()
                        FormAdj.GVAdjIn.FocusedRowHandle = find_row(FormAdj.GVAdjIn, "id_adj_in", id)
                        action = "upd"
                        actionLoad()
                    End If
                    Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub

    Sub closeForm()
        Cursor = Cursors.WaitCursor
        Close()
        Cursor = Cursors.Default
    End Sub

    Sub selectList()
        Cursor = Cursors.WaitCursor
        GVScanSum.Focus()
        Cursor = Cursors.Default
    End Sub

    Sub addScan()
        If action = "ins" Then
            Cursor = Cursors.WaitCursor
            FormBlack.Show()
            FormAdjSingle.id_pop_up = "2"
            FormAdjSingle.ShowDialog()
            FormBlack.Close()
            BringToFront()
            BtnAddScan.Focus()
            Cursor = Cursors.Default
        End If
    End Sub

    Sub removeScan()
        If action = "ins" Then
            Cursor = Cursors.WaitCursor
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = DialogResult.Yes Then
                GVScanSum.DeleteSelectedRows()
                GCScanSum.RefreshDataSource()
                GVScanSum.RefreshData()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Sub print()
        Cursor = Cursors.WaitCursor
        FormBlack.Show()
        ReportAdjIn.id = id
        ReportAdjIn.dt = GCScanSum.DataSource
        Dim Report As New ReportAdjIn()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVScanSum.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVScanSum.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVScanSum)

        'Parse val
        Report.LabelFrom.Text = TxtCodeCompFrom.Text + " - " + TxtNameCompFrom.Text
        Report.LRecNumber.Text = TxtNumber.Text
        Report.LRecDate.Text = DECreated.Text
        Report.LabelNote.Text = MENote.Text
        Report.LabelStatus.Text = LEReportStatus.Text
        Report.LabelPreparedBy.Text = TxtPreparedBy.Text.ToUpper
        Report.LabelRoleBy.Text = role_prepared
        Report.LabelSpv.Text = spv.ToUpper


        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
        Tool.PreviewForm.FormBorderStyle = FormBorderStyle.None
        Tool.PreviewForm.WindowState = FormWindowState.Normal
        FormBlack.Close()
        Cursor = Cursors.Default
    End Sub

    Sub importExcel()
        If action = "ins" Then
            Cursor = Cursors.WaitCursor
            FormImportExcel.id_pop_up = "3"
            FormImportExcel.ShowDialog()
            BringToFront()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        save()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        closeForm()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        print()
    End Sub

    Sub actionLoad()
        If action = "upd" Then
            Dim adjin As New ClassAdj()
            Dim query As String = adjin.queryMainIn("AND i.id_adj_in=" + id + "", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtNumber.Text = data.Rows(0)("adj_in_number").ToString
            DECreated.EditValue = data.Rows(0)("adj_in_date")
            id_comp = data.Rows(0)("id_comp").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_number").ToString
            TxtNameCompFrom.Text = data.Rows(0)("comp_name").ToString
            MENote.Text = data.Rows(0)("adj_in_note").ToString
            id_report_status_glb = data.Rows(0)("id_report_status").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            TxtPreparedBy.Text = data.Rows(0)("employee_name").ToString
            role_prepared = data.Rows(0)("role").ToString
            spv = get_setup_field("spv").ToString

            viewDetail()
            allow_status()
        Else
            LEReportStatus.Enabled = False
            BtnPrint.Enabled = False
            viewDetail()
        End If
    End Sub

    Sub viewReportStatus()
        Dim query As String = queryReportStatus()
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL get_adj_in('" + id + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCScanSum.DataSource = data
    End Sub


    Sub allow_status()
        If check_status(id_report_status_glb) Then
            MENote.Enabled = True
            BtnSave.Enabled = True
            LEReportStatus.Enabled = True
        Else
            MENote.Enabled = False
            BtnSave.Enabled = False
            LEReportStatus.Enabled = False
        End If
        PanelControlItem.Enabled = False
        TxtCodeCompFrom.Enabled = False
        BtnBrowseFrom.Enabled = False

        If check_print_report_status(id_report_status_glb) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If
    End Sub

    Private Sub BtnBrowseFrom_Click(sender As Object, e As EventArgs) Handles BtnBrowseFrom.Click
        Cursor = Cursors.WaitCursor
        FormBlack.Show()
        FormPopUpContact.cond = "AND (tb_m_comp.id_comp_cat=5 OR tb_m_comp.id_comp_cat=6) "
        FormPopUpContact.id_pop_up = "9"
        FormPopUpContact.ShowDialog()
        FormBlack.Close()
        BringToFront()
        If TxtNameCompFrom.Text <> "" Then
            BtnAddScan.Focus()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtCodeCompFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeCompFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim dt As DataTable = get_company_by_code(addSlashes(TxtCodeCompFrom.Text), "AND (comp.id_comp_cat=5 OR comp.id_comp_cat=6) ")
            If dt.Rows.Count > 0 Then
                id_comp = dt.Rows(0)("id_comp").ToString
                TxtCodeCompFrom.Text = dt.Rows(0)("comp_number").ToString
                TxtNameCompFrom.Text = dt.Rows(0)("comp_name").ToString
                viewDetail()
                BtnAddScan.Focus()
            Else
                stopCustom("Account not found !")
                id_comp = "-1"
                TxtCodeCompFrom.Text = ""
                TxtNameCompFrom.Text = ""
                viewDetail()
                TxtCodeCompFrom.Focus()
            End If
        End If
    End Sub

    Private Sub BtnAddScan_Click(sender As Object, e As EventArgs) Handles BtnAddScan.Click
        addScan()
    End Sub

    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles BtnSelect.Click
        selectList()
    End Sub

    Private Sub BtnRemoveScan_Click(sender As Object, e As EventArgs) Handles BtnRemoveScan.Click
        removeScan()
    End Sub

    Private Sub GVScanSum_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVScanSum.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnXls.Click
        importExcel()
    End Sub

    Sub addRows(ByVal id_item As String, ByVal code As String, ByVal desc As String, ByVal size As String, ByVal qty As Decimal, ByVal price As Decimal)
        Dim gc As DevExpress.XtraGrid.GridControl = GCScanSum
        Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = GVScanSum
        Dim newRow As DataRow = (TryCast(gc.DataSource, DataTable)).NewRow()
        newRow("id_adj_in_det") = "0"
        newRow("id_item") = id_item
        newRow("item_code") = code
        newRow("item_name") = desc
        newRow("size") = size
        newRow("adj_in_qty") = qty
        newRow("price") = price
        TryCast(gc.DataSource, DataTable).Rows.Add(newRow)
        gc.RefreshDataSource()
        gv.RefreshData()
    End Sub

    Private Sub PCClose_Click(sender As Object, e As EventArgs) Handles PCClose.Click
        closeForm()
    End Sub
End Class