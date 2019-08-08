Public Class FormRecOwnProduct
    Public id As String = "-1"
    Public id_pl_sales_order_del As String = "-1"
    Public id_comp_from As String = "-1"
    Public id_comp_to As String = "-1"
    Dim ref_date As String = ""
    Public action As String = "-1"
    Dim id_report_status As String = "-1"
    Dim role_prepared As String = ""
    Dim spv As String = ""

    Private Sub FormRecOwnProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub FormRecOwnProduct_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewReportStatus()
        Dim query As String = queryReportStatus()
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            DECreated.EditValue = getTimeDB()

            'get del slip & prepared by
            Dim query As String = "SELECT d.id_pl_sales_order_del, d.number, d.id_wh, wh.comp_number AS `wh_number`, wh.comp_name AS `wh_name`,
            d.id_store, store.comp_number AS `store_number`, store.comp_name AS `store_name`
            FROM tb_delivery_slip d
            INNER JOIN tb_m_comp wh ON wh.id_comp = d.id_wh
            INNER JOIN tb_m_comp store ON store.id_comp = d.id_store
            WHERE d.id_pl_sales_order_del=" + id_pl_sales_order_del + "
            GROUP BY d.id_pl_sales_order_del "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtDelSlip.Text = data.Rows(0)("number").ToString
            id_comp_from = data.Rows(0)("id_store").ToString
            TxtFromCode.Text = data.Rows(0)("store_number").ToString
            TxtFromName.Text = data.Rows(0)("store_name").ToString
            TxtPreparedBy.Text = name_user
            viewSummary()
            viewDetail()
        ElseIf action = "upd" Then
            Dim r As New ClassRec()
            Dim query As String = r.queryMainOwn("AND r.id_rec_own=" + id + " ", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            id_pl_sales_order_del = data.Rows(0)("id_pl_sales_order_del").ToString
            TxtDelSlip.Text = data.Rows(0)("ref").ToString
            id_comp_from = data.Rows(0)("id_comp_from").ToString
            TxtFromCode.Text = data.Rows(0)("comp_number_from").ToString
            TxtFromName.Text = data.Rows(0)("comp_name_from").ToString
            id_comp_to = data.Rows(0)("id_comp_to").ToString
            TxtToCode.Text = data.Rows(0)("comp_number_to").ToString
            TxtToName.Text = data.Rows(0)("comp_name_to").ToString
            TxtRecNumber.Text = data.Rows(0)("rec_number").ToString
            DECreated.EditValue = data.Rows(0)("rec_date")
            TxtPreparedBy.Text = data.Rows(0)("prepared_by").ToString
            MENote.Text = data.Rows(0)("rec_note").ToString
            id_report_status = data.Rows(0)("id_report_status").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            role_prepared = data.Rows(0)("role").ToString
            spv = get_setup_field("spv").ToString

            viewSummary()
            viewDetail()
            allowStatus()
        End If
    End Sub

    Sub viewSummary()
        Cursor = Cursors.WaitCursor
        If action = "ins" Then
            Dim r As New ClassRec()
            Dim data As DataTable = r.dataBalRecOwnProduct(id_pl_sales_order_del)
            GCSummary.DataSource = data
            GVSummary.BestFitColumns()
        ElseIf action = "upd" Then
            Dim query As String = "SELECT rd.id_delivery_slip, del.id_product, del.id_design, del.item_code, del.item_name, del.id_size, sz.size, 
            del.price, del.id_design_cat, dcat.design_cat, SUM(rd.qty) AS `qty`
            FROM tb_rec_own_det rd
            INNER JOIN tb_delivery_slip del ON del.id_delivery_slip = rd.id_delivery_slip
            INNER JOIN tb_size sz ON sz.id_code_detail = del.id_size
            INNER JOIN tb_lookup_design_cat dcat ON dcat.id_design_cat = del.id_design_cat
            WHERE rd.id_rec_own=" + id + " 
            GROUP BY rd.id_delivery_slip "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCSummary.DataSource = data
            GVSummary.BestFitColumns()
        End If
        Cursor = Cursors.Default
    End Sub


    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT rd.id_rec_own_det, rd.id_rec_own, 
        rd.id_delivery_slip, del.id_product, del.id_design, del.item_code, del.item_name, del.id_size, sz.size, 
        del.price, del.id_design_cat, dcat.design_cat,
        rd.qty 
        FROM tb_rec_own_det rd
        INNER JOIN tb_delivery_slip del ON del.id_delivery_slip = rd.id_delivery_slip
        INNER JOIN tb_size sz ON sz.id_code_detail = del.id_size
        INNER JOIN tb_lookup_design_cat dcat ON dcat.id_design_cat = del.id_design_cat
        WHERE rd.id_rec_own=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub allowStatus()
        GridColumndiff.Visible = False
        GridColumnqty_avl.Visible = False
        BtnPrint.Enabled = True
        BtnBrowseTo.Enabled = False
        PanelControlNav.Visible = False
        If id_report_status = "1" Then
            MENote.Enabled = True
            LEReportStatus.Enabled = True
            BtnSave.Enabled = True
        Else
            MENote.Enabled = False
            LEReportStatus.Enabled = False
            BtnSave.Enabled = False
        End If

        'jika cancell
        If id_report_status = "5" Then
            BtnPrint.Enabled = False
        End If
    End Sub

    Private Sub GVSummary_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSummary.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnBrowseTo_Click(sender As Object, e As EventArgs) Handles BtnBrowseTo.Click
        Cursor = Cursors.WaitCursor
        FormPopUpContact.id_pop_up = "10"
        FormPopUpContact.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSummary_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVSummary.RowCellStyle
        If e.Column.FieldName = "diff" And action = "ins" Then
            If e.CellValue < 0 Then
                e.Appearance.BackColor = Color.Yellow
            ElseIf e.CellValue > 0 Then
                e.Appearance.BackColor = Color.Salmon
            Else
                e.Appearance.BackColor = Color.LightGreen
            End If
        End If
    End Sub

    Private Sub BtnScan_Click(sender As Object, e As EventArgs) Handles BtnScan.Click
        TxtItemCode.Focus()
    End Sub

    Private Sub TxtItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtItemCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            'cek gundang
            If id_comp_to = "-1" Then
                stopCustom("Please select destination account first")
                TxtItemCode.Text = ""
                TxtItemCode.Focus()
                Exit Sub
            End If

            Dim code As String = addSlashes(TxtItemCode.Text)
            Dim id_delivery_slip As String = ""
            Dim is_unique_code As String = "1"
            Dim item_code As String = ""
            Dim item_name As String = ""
            Dim size As String = ""

            'find in summary
            Dim cond_valid_qty As Boolean = False
            Dim cond_ketemu As Boolean = False
            makeSafeGV(GVSummary)
            GVSummary.ActiveFilterString = "[item_code]='" + code + "'"
            If GVSummary.RowCount > 0 Then
                id_delivery_slip = GVSummary.GetFocusedRowCellValue("id_delivery_slip").ToString
                is_unique_code = GVSummary.GetFocusedRowCellValue("is_unique_code").ToString
                item_code = GVSummary.GetFocusedRowCellValue("item_code").ToString
                item_name = GVSummary.GetFocusedRowCellValue("item_name").ToString
                size = GVSummary.GetFocusedRowCellValue("size").ToString
                cond_ketemu = True

                'cek dengan available qty
                If GVSummary.GetFocusedRowCellValue("qty") < GVSummary.GetFocusedRowCellValue("qty_avl") Then
                    cond_valid_qty = True
                End If
            End If
            makeSafeGV(GVSummary)
            If Not cond_ketemu Then
                stopCustom("Code not found")
                TxtItemCode.Text = ""
                TxtItemCode.Focus()
                Exit Sub
            End If

            'jika code unik
            If is_unique_code = "1" Then
                'cek duplikat
                Dim cond_duplikat As Boolean = False
                makeSafeGV(GVData)
                GVData.ActiveFilterString = "[item_code]='" + code + "'"
                If GVData.RowCount > 0 Then
                    cond_duplikat = True
                End If
                makeSafeGV(GVData)
                If cond_duplikat Then
                    stopCustom("Duplicate code")
                    TxtItemCode.Text = ""
                    TxtItemCode.Focus()
                    Exit Sub
                End If

                'jika unik cek posisi di gudang ada ato enggak
                Dim qst As String = "SELECT s.id_item, IFNULL(SUM(IF(s.id_stock_status=1, (IF(s.id_storage_category=2, CONCAT('-', s.storage_item_qty), s.storage_item_qty)),0)),0) AS qty_tot
                FROM tb_storage_item s
                INNER JOIN tb_item i ON i.id_item = s.id_item
                WHERE s.id_comp=" + id_comp_to + " AND i.item_code='" + code + "'
                GROUP BY s.id_item "
                Dim dst As DataTable = execute_query(qst, -1, True, "", "", "", "")
                If dst.Rows.Count > 0 Then
                    If dst.Rows(0)("qty_tot") > 0 Then
                        stopCustom("This product is already in " + TxtToCode.Text)
                        TxtItemCode.Text = ""
                        TxtItemCode.Focus()
                        Exit Sub
                    End If
                End If
            End If

            'cek valid qty
            If cond_valid_qty Then
                Dim newRow As DataRow = (TryCast(GCData.DataSource, DataTable)).NewRow()
                newRow("id_delivery_slip") = id_delivery_slip
                newRow("item_code") = item_code
                newRow("item_name") = item_name
                newRow("size") = size
                TryCast(GCData.DataSource, DataTable).Rows.Add(newRow)
                GCData.RefreshDataSource()
                GVData.RefreshData()
                countQty(id_delivery_slip)
                TxtItemCode.Text = ""
                TxtItemCode.Focus()
            Else
                stopCustom("No qty available")
                TxtItemCode.Text = ""
                TxtItemCode.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Sub countQty(ByVal id_delivery_slip_par As String)
        makeSafeGV(GVData)
        GVData.ActiveFilterString = "[id_delivery_slip]='" + id_delivery_slip_par + "' "
        Dim tot As Integer = GVData.RowCount
        makeSafeGV(GVData)
        GVSummary.FocusedRowHandle = find_row(GVSummary, "id_delivery_slip", id_delivery_slip_par)
        GVSummary.SetFocusedRowCellValue("qty", tot)
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Cursor = Cursors.WaitCursor
        FormDeleteScan.id_pop_up = "1"
        FormDeleteScan.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        FormBlack.Show()
        ReportRecOwn.id = id
        ReportRecOwn.dt = GCSummary.DataSource
        Dim Report As New ReportRecOwn()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVSummary.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVSummary.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVSummary)

        'Parse val
        Report.LabelFrom.Text = TxtFromCode.Text + " - " + TxtFromName.Text
        Report.LabelTo.Text = TxtToCode.Text + " - " + TxtToName.Text
        Report.LRecNumber.Text = TxtRecNumber.Text
        Report.LRecDate.Text = DECreated.Text
        Report.LabelNote.Text = MENote.Text
        Report.LabelRef.Text = TxtDelSlip.Text
        Report.LabelStatus.Text = LEReportStatus.Text
        Report.LabelPreparedBy.Text = TxtPreparedBy.Text.ToUpper
        Report.LabelRoleBy.Text = role_prepared
        'Report.LabelAckFrom.Text = TxtNameCompFrom.Text
        Report.LabelSpv.Text = spv.ToUpper


        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
        FormBlack.Close()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        makeSafeGV(GVData)
        makeSafeGV(GVSummary)

        'cek limit
        Dim cond_limit As Boolean = True
        If action = "ins" Then
            Dim r As New ClassRec()
            Dim dt As DataTable = r.dataBalRecOwnProduct(id_pl_sales_order_del)
            For i As Integer = 0 To GVSummary.RowCount - 1
                Dim item_code As String = GVSummary.GetRowCellValue(i, "item_code").ToString
                Dim dtf As DataRow() = dt.Select("[item_code]='" + item_code + "'")

                If dtf.Length > 0 Then
                    GVSummary.SetRowCellValue(i, "qty_avl", dtf(0)("qty_avl"))
                Else
                    GVSummary.SetRowCellValue(i, "qty_avl", 0)
                End If
            Next

            'cari diff > 0
            makeSafeGV(GVSummary)
            GVSummary.ActiveFilterString = "[diff]>0"
            If GVSummary.RowCount > 0 Then
                cond_limit = False
            End If
            makeSafeGV(GVSummary)
        End If


        If GVData.RowCount <= 0 Then
            stopCustom("Item data can't blank")
        ElseIf id_comp_to = "-1" Then
            stopCustom("Please select destination account first")
        ElseIf Not cond_limit Then
            stopCustom("Some items exceed available qty, please correct them first")
        Else
            Dim rec_note As String = addSlashes(MENote.Text)
            Dim id_report_status_saved As String = LEReportStatus.EditValue.ToString

            If action = "ins" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to save this transaction?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor

                    'save header
                    Dim ref As String = addSlashes(TxtDelSlip.Text)
                    Dim query As String = "INSERT INTO tb_rec_own(id_comp_from, id_comp_to, rec_date, id_pl_sales_order_del, ref, rec_note, id_prepared_by, id_report_status) 
                    VALUES(" + id_comp_from + ", " + id_comp_to + ", NOW(), " + id_pl_sales_order_del + ", '" + ref + "', '" + rec_note + "', " + id_user + ", " + id_report_status_saved + "); SELECT LAST_INSERT_ID(); "
                    id = execute_query(query, 0, True, "", "", "", "")
                    execute_non_query("CALL gen_number(" + id + ", 8)", True, "", "", "", "")

                    'save detil
                    Dim query_det As String = "INSERT INTO tb_rec_own_det(id_rec_own, id_delivery_slip, qty) VALUES "
                    For j As Integer = 0 To GVData.RowCount - 1
                        Dim id_delivery_slip As String = GVData.GetRowCellValue(j, "id_delivery_slip").ToString
                        If j > 0 Then
                            query_det += ", "
                        End If
                        query_det += "(" + id + ", " + id_delivery_slip + ", 1) "
                    Next
                    If GVData.RowCount > 0 Then
                        execute_non_query(query_det, True, "", "", "", "")
                    End If

                    'refresh
                    action = "upd"
                    actionLoad()
                    FormRec.XTCOwn.SelectedTabPageIndex = 0
                    FormRec.viewRecOwn()
                    FormRec.GVRecOwn.FocusedRowHandle = find_row(FormRec.GVRecOwn, "id_rec_own", id)
                    infoCustom("Document #" + TxtRecNumber.Text + " was created successfully.")
                    Cursor = Cursors.Default
                End If
            ElseIf action = "upd" Then
                Cursor = Cursors.WaitCursor
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to save changes this transaction and set status to '" + LEReportStatus.Text + "' ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = DialogResult.Yes Then
                    'jika completed masuk master dan stok
                    If id_report_status_saved = "6" Then
                        'masuk ke master
                        Dim qf As String = "/*master*/
                        INSERT INTO tb_item (`id_size`,`id_class`,`id_color`,`id_comp_sup`,`id_so_type`,`id_design_cat`,`item_code` , `item_code_group`,
                        `item_name`,`price`,`price_date`,`comm`,`id_product`, `id_design`,`is_active`,`is_own_product`, `is_unique_code`,`last_updated`)
                        SELECT sz.`id_size`,cls.`id_class`,col.`id_color`, str.id_comp AS `id_comp_sup`, 1 AS `id_so_type`, ds.id_design_cat, ds.item_code, ds.item_code_group,
                        ds.`item_name`,ds.`price`, NOW() AS `price_date`, str.comp_commission AS `comm`, ds.id_product, ds.id_design, 1, 1, ds.is_unique_code, NOW()
                        FROM tb_rec_own_det rd 
                        INNER JOIN tb_delivery_slip ds ON ds.id_delivery_slip = rd.id_delivery_slip
                        INNER JOIN tb_size sz ON sz.id_code_detail = ds.id_size
                        INNER JOIN tb_class cls ON cls.id_code_detail = ds.id_class
                        INNER JOIN tb_color col ON col.id_code_detail = ds.id_color
                        INNER JOIN tb_m_comp str ON str.id_comp = ds.id_store
                        LEFT JOIN tb_item i ON i.item_code = ds.item_code
                        WHERE rd.id_rec_own=" + id + " AND ISNULL(i.id_item);
                        /*storage*/
                        INSERT INTO tb_storage_item(id_comp, id_storage_category, id_item, report_mark_type, id_report, storage_item_qty, storage_item_datetime, id_stock_status)
                        SELECT r.id_comp_to, 1, i.id_item, 8, r.id_rec_own, rd.qty, NOW(), 1
                        FROM tb_rec_own_det rd 
                        INNER JOIN tb_rec_own r ON r.id_rec_own = rd.id_rec_own
                        INNER JOIN tb_delivery_slip ds ON ds.id_delivery_slip = rd.id_delivery_slip
                        INNER JOIN tb_m_comp str ON str.id_comp = ds.id_store
                        INNER JOIN tb_item i ON i.item_code = ds.item_code
                        WHERE rd.id_rec_own=" + id + "; "
                        execute_non_query(qf, True, "", "", "", "")
                    End If

                    Dim query As String = "UPDATE tb_rec_own SET rec_note='" + rec_note + "', id_report_status=" + id_report_status_saved + " "
                    If id_report_status_saved = "6" Or id_report_status_saved = "5" Then
                        query += ", final_status_time=NOW() "
                    End If
                    query += "WHERE id_rec_own=" + id + " "
                    execute_non_query(query, True, "", "", "", "")

                    'tandai ada master baru
                    If id_report_status_saved = "6" Then
                        FormRec.is_new_rec = "1"
                    End If

                    'refresh
                    action = "upd"
                    actionLoad()
                    FormRec.viewRecOwn()
                    FormRec.GVRecOwn.FocusedRowHandle = find_row(FormRec.GVRecOwn, "id_rec_own", id)
                End If
                Cursor = Cursors.Default
            End If
        End If
    End Sub
End Class