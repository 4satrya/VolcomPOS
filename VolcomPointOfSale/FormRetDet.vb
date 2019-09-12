﻿Imports DevExpress.XtraReports.UI
Imports FastMember

Public Class FormRetDet
    Public id As String = "-1"
    Public action As String = "-1"
    Public id_comp_from As String = "-1"
    Public id_comp_to As String = "-1"
    Dim id_report_status_glb As String = "-1"
    Dim item As New ClassItem()
    Dim role_prepared As String = ""
    Dim spv As String = ""

    'scan variable
    Private cforKeyDown As Char = vbNullChar
    Private _lastKeystroke As DateTime = DateTime.Now
    Public UseKeyboard As String = "-1"
    Public speed_barcode_read As Integer = 0
    Public speed_barcode_read_timer As Integer = 0

    Private Sub FormRetDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'scan opt
        Dim query_opt As String = "SELECT is_use_keyboard, speed_barcode_read, speed_barcode_read_timer  FROM tb_opt; "
        Dim data_opt As DataTable = execute_query(query_opt, -1, True, "", "", "", "")
        UseKeyboard = data_opt.Rows(0)("is_use_keyboard").ToString
        speed_barcode_read = data_opt.Rows(0)("speed_barcode_read")
        speed_barcode_read_timer = data_opt.Rows(0)("speed_barcode_read_timer")
        Timer1.Interval = speed_barcode_read_timer

        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = queryReportStatus()
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        If action = "upd" Then
            Dim rt As New ClassRet()
            Dim query As String = rt.queryMain("AND r.id_ret=" + id + "", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtNumber.Text = data.Rows(0)("ret_number").ToString
            DECreated.EditValue = data.Rows(0)("ret_date")
            id_comp_from = data.Rows(0)("id_comp_from").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_number_from").ToString
            TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
            id_comp_to = data.Rows(0)("id_comp_to").ToString
            TxtCodeCompTo.Text = data.Rows(0)("comp_number_to").ToString
            TxtNameCompTo.Text = data.Rows(0)("comp_name_to").ToString
            TxtRef.Text = data.Rows(0)("ref").ToString
            DERefDate.EditValue = data.Rows(0)("ref_date")
            MENote.Text = data.Rows(0)("ret_note").ToString
            id_report_status_glb = data.Rows(0)("id_report_status").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            TxtPreparedBy.Text = data.Rows(0)("employee_name").ToString
            role_prepared = data.Rows(0)("role").ToString
            spv = get_setup_field("spv").ToString

            viewDetail()
            allow_status()
            XTPScanned.PageVisible = False
            XTPSummary.PageVisible = True
            GridColumnStatus.Visible = False
            GridColumnAvail.Visible = False
        Else
            DERefDate.EditValue = getTimeDB()
            LEReportStatus.Enabled = False
            BtnPrint.Enabled = False
            XTPSummary.PageVisible = True
        End If
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL get_ret('" + id + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If action = "ins" Then
            GCScan.DataSource = data
        Else
            GCScanSum.DataSource = data
        End If
    End Sub


    Sub allow_status()
        If id_report_status_glb = "1" Then
            MENote.Enabled = True
            BtnSave.Enabled = True
            TxtRef.Enabled = True
            DERefDate.Enabled = True
            LEReportStatus.Enabled = True
        Else
            MENote.Enabled = False
            BtnSave.Enabled = False
            TxtRef.Enabled = False
            DERefDate.Enabled = False
            LEReportStatus.Enabled = False
        End If
        BtnPrint.Enabled = True
        PanelControlItem.Visible = False
        TxtCodeCompFrom.Enabled = False
        TxtCodeCompTo.Enabled = False
        BtnBrowseFrom.Enabled = False
        BtnBrowseTo.Enabled = False

        'jika cancell
        If id_report_status_glb = "5" Then
            BtnPrint.Enabled = False
        End If
    End Sub

    Private Sub BtnBrowseFrom_Click(sender As Object, e As EventArgs) Handles BtnBrowseFrom.Click
        Cursor = Cursors.WaitCursor
        FormBlack.Show()
        FormPopUpContact.id_cat = "5"
        FormPopUpContact.id_pop_up = "3"
        FormPopUpContact.ShowDialog()
        FormBlack.Close()
        BringToFront()
        If TxtNameCompFrom.Text <> "" Then
            TxtCodeCompTo.Focus()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnBrowseTo_Click(sender As Object, e As EventArgs) Handles BtnBrowseTo.Click
        Cursor = Cursors.WaitCursor
        FormBlack.Show()
        FormPopUpContact.id_pop_up = "4"
        FormPopUpContact.ShowDialog()
        FormBlack.Close()
        BringToFront()
        If TxtNameCompTo.Text <> "" Then
            TxtRef.Focus()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtRef_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtRef.KeyDown
        If e.KeyCode = Keys.Enter Then
            DERefDate.Focus()
        End If
    End Sub

    Private Sub FormRetDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub TxtCodeCompFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeCompFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim dt As DataTable = get_company_by_code(addSlashes(TxtCodeCompFrom.Text), "AND comp.id_comp_cat=5 ")
            If dt.Rows.Count > 0 Then
                id_comp_from = dt.Rows(0)("id_comp").ToString
                TxtCodeCompFrom.Text = dt.Rows(0)("comp_number").ToString
                TxtNameCompFrom.Text = dt.Rows(0)("comp_name").ToString
                TxtCodeCompTo.Focus()
            Else
                stopCustom("Account not found !")
                id_comp_from = "-1"
                TxtCodeCompFrom.Text = ""
                TxtNameCompFrom.Text = ""
                TxtCodeCompFrom.Focus()
            End If
        End If
    End Sub

    Private Sub TxtCodeCompTo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeCompTo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim dt As DataTable = get_company_by_code(addSlashes(TxtCodeCompTo.Text), "AND comp.id_comp_cat=1 ")
            If dt.Rows.Count > 0 Then
                id_comp_to = dt.Rows(0)("id_comp").ToString
                TxtCodeCompTo.Text = dt.Rows(0)("comp_number").ToString
                TxtNameCompTo.Text = dt.Rows(0)("comp_name").ToString
                viewDetail()
                TxtRef.Focus()

            Else
                stopCustom("Account not found !")
                id_comp_to = "-1"
                TxtCodeCompTo.Text = ""
                TxtNameCompTo.Text = ""
                viewDetail()
                TxtCodeCompTo.Focus()
            End If
        End If
    End Sub

    Private Sub FormRetDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F5 Then 'save
            save()
        ElseIf e.KeyCode = Keys.F6 Then 'close
            closeForm()
        ElseIf e.KeyCode = Keys.F7 Then 'add scan
            addScan()
        ElseIf e.KeyCode = Keys.F8 Then 'remove scan
            removeScan()
        ElseIf e.KeyCode = Keys.F9 Then 'print
            print()
        ElseIf e.KeyCode = Keys.F10 Then 'print
            prePrinting()
        End If
    End Sub

    Dim dts As DataTable
    Sub viewSummary()
        If GVScan.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            dts = New DataTable()
            Dim data_temp As DataTable = GCScan.DataSource
            Dim connection_string As String = String.Format("Data Source={0};User Id={1};Password={2};Database={3};Convert Zero Datetime=True", app_host, app_username, app_password, app_database)
            Dim connection As New MySql.Data.MySqlClient.MySqlConnection(connection_string)
            connection.Open()
            Dim command As MySql.Data.MySqlClient.MySqlCommand = connection.CreateCommand()
            Dim qry As String = "DROP TABLE IF EXISTS tb_ret_temp; CREATE TEMPORARY TABLE IF NOT EXISTS tb_ret_temp AS ( SELECT * FROM ("
            For d As Integer = 0 To data_temp.Rows.Count - 1
                Dim id_item As String = data_temp.Rows(d)("id_item").ToString
                Dim item_code As String = data_temp.Rows(d)("item_code").ToString
                Dim item_name As String = data_temp.Rows(d)("item_name").ToString
                Dim size As String = data_temp.Rows(d)("size").ToString
                Dim price As String = decimalSQL(data_temp.Rows(d)("price").ToString)
                If d > 0 Then
                    qry += "UNION ALL "
                End If
                qry += "SELECT '" + id_item + "' AS `id_item`, '" + item_code + "' AS `item_code`, '" + item_name + "' AS `item_name`, '" + size + "' AS `size` , " + price + " AS `price` "
            Next
            qry += ") a ); ALTER TABLE tb_ret_temp CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci; "
            command.CommandText = qry
            command.ExecuteNonQuery()
            command.Dispose()
            ' Console.WriteLine(qry)

            Dim data_view As New DataTable
            Dim qry_view As String = "SELECT a.id_item, a.item_code, a.item_name, a.size, COUNT(a.id_item) AS `ret_qty`, a.price 
                                FROM tb_ret_temp a 
                                GROUP BY a.id_item"
            Dim adapter As New MySql.Data.MySqlClient.MySqlDataAdapter(qry_view, connection)
            adapter.SelectCommand.CommandTimeout = 300
            adapter.Fill(data_view)
            adapter.Dispose()
            connection.Close()
            connection.Dispose()

            'get data stock
            Dim query_stock As String = "CALL view_stock_item('AND f.is_active=1 AND j.id_comp=" + id_comp_from + " AND f.id_comp_sup=" + id_comp_to + " AND j.storage_item_datetime<=''9999-12-01'' ', '2')"
            Dim data_stock As DataTable = execute_query(query_stock, -1, True, "", "", "", "")
            Dim tb1 = data_view.AsEnumerable()
            Dim tb2 = data_stock.AsEnumerable()
            Dim query_cek = From table1 In tb1
                            Group Join table_tmp In tb2 On table1("id_item").ToString Equals table_tmp("id_item").ToString
                            Into Group
                            From y1 In Group.DefaultIfEmpty()
                            Select New With
                            {
                                .id_item = table1.Field(Of String)("id_item").ToString,
                                .item_code = table1.Field(Of String)("item_code").ToString,
                                .item_name = table1.Field(Of String)("item_name").ToString,
                                .size = table1.Field(Of String)("size").ToString,
                                .ret_qty = table1("ret_qty"),
                                .qty_avl = If(y1 Is Nothing, 0, y1("qty_avl")),
                                .price = table1("price"),
                                .amount = table1("ret_qty") * table1("price"),
                                .status = If(table1("ret_qty") <= If(y1 Is Nothing, 0, y1("qty_avl")), "OK", "Can't exceed " + If(y1 Is Nothing, 0, y1("qty_avl").ToString))
                            }
            GCScanSum.DataSource = Nothing
            GCScanSum.DataSource = query_cek.ToList()


            Using reader = ObjectReader.Create(GCScanSum.DataSource, "item_code", "item_name", "size", "ret_qty", "price")
                dts.Load(reader)
            End Using
            Cursor = Cursors.Default
        End If
    End Sub

    Sub save()
        If id_report_status_glb <> "5" And id_report_status_glb <> "6" Then
            Cursor = Cursors.WaitCursor
            Dim ref As String = addSlashes(TxtRef.Text)
            Dim ref_date As String = DateTime.Parse(DERefDate.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim ret_note As String = addSlashes(MENote.Text)
            Dim id_report_status As String = LEReportStatus.EditValue.ToString
            Dim gv As DevExpress.XtraGrid.Views.Grid.GridView
            If action = "ins" Then
                gv = GVScan
            Else
                gv = GVScanSum
            End If

            'cek stock
            Dim cond_stk As Boolean = True
            If action = "ins" Then
                viewSummary()

                'filter OK
                GVScanSum.ActiveFilterString = "[status]<>'OK' "
                If GVScanSum.RowCount > 0 Then
                    cond_stk = False
                End If
                GCScanSum.RefreshDataSource()
                GVScanSum.RefreshData()

                'remove filter
                GVScanSum.ActiveFilterString = ""
                GCScanSum.RefreshDataSource()
                GVScanSum.RefreshData()
            End If


            If id_comp_from = "-1" Or id_comp_to = "-1" Or ref = "" Or ref_date = "" Or gv.RowCount = 0 Then
                stopCustom("Data can't blank")
            ElseIf Not cond_stk Then
                stopCustom("Some item can't exceed qty limit, please see error in column status!")
                XTPSummary.PageVisible = True
                XTCItem.SelectedTabPageIndex = 1
            Else
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to save this transaction?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    If action = "ins" Then
                        'main query
                        Dim query As String = "INSERT INTO tb_ret(id_comp_from, id_comp_to, ret_number, ret_date, ref, ref_date, ret_note, id_report_status, id_prepared_by) 
                        VALUES('" + id_comp_from + "', '" + id_comp_to + "', '', NOW(), '" + ref + "', '" + ref_date + "', '" + ret_note + "', '1', '" + id_user + "'); SELECT LAST_INSERT_ID(); "
                        id = execute_query(query, 0, True, "", "", "", "")
                        execute_non_query("CALL gen_number(" + id + ", 2)", True, "", "", "", "")

                        'detail
                        Dim query_det As String = "INSERT INTO tb_ret_det(id_ret, id_item, price, ret_qty) VALUES "
                        For i As Integer = 0 To ((GVScanSum.RowCount - 1) - GetGroupRowCount(GVScanSum))
                            Dim id_item As String = GVScanSum.GetRowCellValue(i, "id_item").ToString
                            Dim price As String = decimalSQL(GVScanSum.GetRowCellValue(i, "price").ToString)
                            Dim ret_qty As String = decimalSQL(GVScanSum.GetRowCellValue(i, "ret_qty").ToString)
                            If i > 0 Then
                                query_det += ", "
                            End If
                            query_det += "('" + id + "','" + id_item + "', '" + price + "', '" + ret_qty + "')"
                        Next
                        If GVScanSum.RowCount > 0 Then
                            execute_non_query(query_det, True, "", "", "", "")
                        End If


                        'reserved
                        Dim query_res As String = "INSERT INTO tb_storage_item(id_comp, id_storage_category, id_item, report_mark_type, id_report, storage_item_qty, storage_item_datetime, id_stock_status) 
                                                SELECT tb_ret.id_comp_from, 2, tb_ret_det.id_item, 2, " + id + ", tb_ret_det.ret_qty, NOW(), 2 
                                                FROM tb_ret_det 
                                                INNER JOIN tb_ret ON tb_ret.id_ret = tb_ret_det.id_ret
                                                WHERE tb_ret_det.id_ret=" + id + ""
                        execute_non_query(query_res, True, "", "", "", "")

                        FormRet.viewRet()
                        FormRet.GVRet.FocusedRowHandle = find_row(FormRet.GVRet, "id_ret", id)
                        action = "upd"
                        actionLoad()
                        infoCustom("Document #" + TxtNumber.Text + " was created successfully.")
                    Else
                        Dim query As String = "UPDATE tb_ret SET ref='" + ref + "', ref_date='" + ref_date + "', ret_note='" + ret_note + "', id_report_status='" + id_report_status + "' "
                        If id_report_status = "5" Or id_report_status = "6" Then 'final
                            query += ", final_status_time=NOW() "
                        End If
                        query += "WHERE id_ret ='" + id + "' "
                        execute_non_query(query, True, "", "", "", "")

                        'completed
                        If id_report_status = "6" Then 'completed
                            Dim query_stk As String = "INSERT INTO tb_storage_item(id_comp, id_storage_category, id_item, report_mark_type, id_report, storage_item_qty, storage_item_datetime, id_stock_status) 
                                                (SELECT tb_ret.id_comp_from, 1, tb_ret_det.id_item, 2, " + id + ", tb_ret_det.ret_qty, NOW(), 2 
                                                FROM tb_ret_det 
                                                INNER JOIN tb_ret ON tb_ret.id_ret = tb_ret_det.id_ret
                                                WHERE tb_ret_det.id_ret=" + id + ") 
                                                UNION ALL 
                                                (SELECT tb_ret.id_comp_from, 2, tb_ret_det.id_item, 2, " + id + ", tb_ret_det.ret_qty, NOW(), 1 
                                                FROM tb_ret_det 
                                                INNER JOIN tb_ret ON tb_ret.id_ret = tb_ret_det.id_ret
                                                WHERE tb_ret_det.id_ret=" + id + ") "
                            execute_non_query(query_stk, True, "", "", "", "")
                        ElseIf id_report_status = "5" Then 'cancelled
                            Dim query_stk As String = "INSERT INTO tb_storage_item(id_comp, id_storage_category, id_item, report_mark_type, id_report, storage_item_qty, storage_item_datetime, id_stock_status) 
                                                SELECT tb_ret.id_comp_from, 1, tb_ret_det.id_item, 2, " + id + ", tb_ret_det.ret_qty, NOW(), 2 
                                                FROM tb_ret_det 
                                                INNER JOIN tb_ret ON tb_ret.id_ret = tb_ret_det.id_ret
                                                WHERE tb_ret_det.id_ret=" + id + ""
                            execute_non_query(query_stk, True, "", "", "", "")
                        End If

                        FormRet.viewRet()
                        FormRet.GVRet.FocusedRowHandle = find_row(FormRet.GVRet, "id_ret", id)
                        action = "upd"
                        actionLoad()
                    End If
                    Cursor = Cursors.Default
                End If
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Sub closeForm()
        Cursor = Cursors.WaitCursor
        Close()
        Cursor = Cursors.Default
    End Sub

    Sub selectList()
        Cursor = Cursors.WaitCursor
        GVScan.Focus()
        Cursor = Cursors.Default
    End Sub

    Sub addScan()
        Cursor = Cursors.WaitCursor
        TxtItemCode.Focus()
        Cursor = Cursors.Default
    End Sub

    Sub removeScan()
        If (id_report_status_glb = "1" Or id_report_status_glb = "-1") And action = "ins" Then
            'Cursor = Cursors.WaitCursor
            'Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            'If confirm = DialogResult.Yes Then
            '    GVScan.DeleteSelectedRows()
            '    GCScan.RefreshDataSource()
            '    GVScan.RefreshData()
            'End If
            'Cursor = Cursors.Default

            Cursor = Cursors.WaitCursor
            FormDeleteScan.id_pop_up = "3"
            FormDeleteScan.cforKeyDown = cforKeyDown
            FormDeleteScan._lastKeystroke = _lastKeystroke
            FormDeleteScan.UseKeyboard = UseKeyboard
            FormDeleteScan.speed_barcode_read = speed_barcode_read
            FormDeleteScan.speed_barcode_read_timer = speed_barcode_read_timer
            FormDeleteScan.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Sub prePrinting()
        Cursor = Cursors.WaitCursor
        XTCItem.SelectedTabPageIndex = 1
        ReportRet.id = id
        ReportRet.is_pre_printing = "1"
        ReportRet.dt = dts
        Dim Report As New ReportRet()
        Report.LRecNumber.Text = "(PREVIEW ONLY NOT SAVED)"
        Report.LabelFrom.Text = TxtCodeCompFrom.Text + " - " + TxtNameCompFrom.Text
        Report.LabelTo.Text = TxtCodeCompTo.Text + " - " + TxtNameCompTo.Text
        Report.LabelRef.Text = TxtRef.Text
        Report.LabelRefDate.Text = DERefDate.Text
        Report.LabelStatus.Text = "Prepared"
        Report.LabelNote.Text = MENote.Text
        Report.RowTotalQty.Text = Decimal.Parse(GVScanSum.Columns("ret_qty").SummaryItem.SummaryValue.ToString).ToString("N0")
        Report.RowTotalAmount.Text = Double.Parse(GVScanSum.Columns("amount").SummaryItem.SummaryValue.ToString).ToString("N0")

        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
        Cursor = Cursors.Default
    End Sub

    Sub print()
        Cursor = Cursors.WaitCursor
        ReportRet.id = id
        ReportRet.is_pre_printing = "-1"
        Dim Report As New ReportRet()

        If CEPrintPreview.EditValue = True Then
            ' Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        Else
            Dim instance As New Printing.PrinterSettings
            Dim DefaultPrinter As String = instance.PrinterName

            ' THIS IS TO PRINT THE REPORT
            Report.PrinterName = DefaultPrinter
            Report.CreateDocument()
            Report.PrintingSystem.ShowMarginsWarning = False
            Report.Print()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVScan_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVScan.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles BtnSelect.Click
        selectList()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles BtnAddScan.Click
        addScan()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles BtnRemoveScan.Click
        removeScan()
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

    Private Sub TxtItemCode_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtItemCode.KeyUp
        If UseKeyboard = "2" Then
            'barcode scanner
            If Len(TxtItemCode.Text) > 1 Then
                If cforKeyDown <> ChrW(e.KeyCode) OrElse cforKeyDown = vbNullChar Then
                    cforKeyDown = vbNullChar
                    TxtItemCode.Text = ""
                    Return
                End If


                Dim elapsed As TimeSpan = DateTime.Now - _lastKeystroke
                '(DateTime.Now.Millisecond - _lastKeystroke)
                If elapsed.TotalMilliseconds > speed_barcode_read Then TxtItemCode.Text = ""

                'If e.KeyCode <> Keys.[Return] Then
                '    TxtItemCode.Text += ChrW(e.KeyData)
                'End If

                If e.KeyCode = Keys.[Return] AndAlso TxtItemCode.Text.Count > 0 Then
                    checkCode(TxtItemCode.Text)
                End If

            End If
            _lastKeystroke = DateTime.Now
        Else
            'keyboard
            If e.KeyCode = Keys.[Return] AndAlso TxtItemCode.Text.Count > 0 Then
                checkCode(TxtItemCode.Text)
            End If
        End If
    End Sub

    Private Sub TxtItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtItemCode.KeyDown
        cforKeyDown = ChrW(e.KeyCode)
    End Sub

    Sub checkCode(ByVal code_check As String)
        Dim code As String = addSlashes(code_check)
        Dim query As String = "CALL view_stock_item('AND f.is_active=1 AND f.item_code=''" + code + "'' AND j.id_comp=" + id_comp_from + " AND f.id_comp_sup=" + id_comp_to + " AND j.storage_item_datetime<=''9999-12-01'' ', '2')"
        'Dim query As String = item.queryMain("AND i.is_active=1 AND i.item_code='" + code + "' AND i.id_comp_sup='" + id_comp_to + "' ", "1", False)
        Dim dt As DataTable = execute_query(query, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            'cek available 
            makeSafeGV(GVScan)
            GVScan.ActiveFilterString = "[id_item]='" + dt(0)("id_item").ToString + "'"
            If GVScan.RowCount >= dt.Rows(0)("qty_avl") Then
                stopCustomDialog("No available qty")
                makeSafeGV(GVScan)
                GVScan.FocusedRowHandle = GVScan.RowCount - 1
                TxtItemCode.Text = ""
                TxtItemCode.Focus()
                Exit Sub
            End If
            makeSafeGV(GVScan)

            Dim newRow As DataRow = (TryCast(GCScan.DataSource, DataTable)).NewRow()
            newRow("id_ret_det") = "0"
            newRow("id_item") = dt(0)("id_item").ToString
            newRow("item_code") = dt(0)("item_code").ToString
            newRow("item_name") = dt(0)("item_name").ToString
            newRow("size") = dt(0)("size").ToString
            newRow("ret_qty") = 1
            newRow("price") = dt(0)("price")
            TryCast(GCScan.DataSource, DataTable).Rows.Add(newRow)
            GCScan.RefreshDataSource()
            GVScan.RefreshData()
            GVScan.FocusedRowHandle = GVScan.RowCount - 1
        Else
            stopCustomDialog("Code not found")
        End If
        TxtItemCode.Text = ""
        TxtItemCode.Focus()
    End Sub

    Private Sub GVScanSum_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVScanSum.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub PCClose_MouseHover(sender As Object, e As EventArgs)
        Cursor = Cursors.Hand
    End Sub

    Private Sub PCClose_MouseLeave(sender As Object, e As EventArgs)
        Cursor = Cursors.Default
    End Sub

    Private Sub PCClose_Click(sender As Object, e As EventArgs)
        closeForm()
    End Sub

    Private Sub DERefDate_KeyDown(sender As Object, e As KeyEventArgs) Handles DERefDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtItemCode.Focus()
        End If
    End Sub

    Private Sub XTCItem_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCItem.SelectedPageChanged
        If XTCItem.SelectedTabPageIndex = 1 Then
            viewSummary()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If UseKeyboard = "2" Then
            TxtItemCode.Text = ""
            Timer1.Stop()
        End If
    End Sub

    Private Sub TxtItemCode_TextChanged(sender As Object, e As EventArgs) Handles TxtItemCode.TextChanged
        If UseKeyboard = "2" Then
            Timer1.Stop()
            Timer1.Start()
        End If
    End Sub

    Private Sub BtnPrePrint_Click(sender As Object, e As EventArgs) Handles BtnPrePrint.Click
        prePrinting()
    End Sub
End Class