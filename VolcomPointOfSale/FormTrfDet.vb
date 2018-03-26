Public Class FormTrfDet
    Public id As String = "-1"
    Public action As String = "-1"
    Public id_comp_from As String = "-1"
    Public id_comp_to As String = "-1"
    Dim id_report_status_glb As String = "-1"
    Dim role_prepared As String = ""
    Dim spv As String = ""

    Private Sub FormTrfDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = queryReportStatus()
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        If action = "upd" Then
            Dim rt As New ClassTrf()
            Dim query As String = rt.queryMain("AND t.id_trf=" + id + "", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtNumber.Text = data.Rows(0)("trf_number").ToString
            DECreated.EditValue = data.Rows(0)("trf_date")
            id_comp_from = data.Rows(0)("id_comp_from").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_number_from").ToString
            TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
            id_comp_to = data.Rows(0)("id_comp_to").ToString
            TxtCodeCompTo.Text = data.Rows(0)("comp_number_to").ToString
            TxtNameCompTo.Text = data.Rows(0)("comp_name_to").ToString
            MENote.Text = data.Rows(0)("trf_note").ToString
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
            LEReportStatus.Enabled = False
            BtnPrint.Enabled = False
            XTPSummary.PageVisible = False
        End If
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL get_trf('" + id + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If action = "ins" Then
            GCScan.DataSource = data
        Else
            GCScanSum.DataSource = data
        End If
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
        TxtCodeCompTo.Enabled = False
        BtnBrowseFrom.Enabled = False
        BtnBrowseTo.Enabled = False

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
        FormPopUpContact.id_pop_up = "5"
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
        FormPopUpContact.cond = "AND (tb_m_comp.id_comp_cat=5 OR tb_m_comp.id_comp_cat=6) "
        FormPopUpContact.id_pop_up = "6"
        FormPopUpContact.ShowDialog()
        FormBlack.Close()
        BringToFront()
        If TxtNameCompTo.Text <> "" Then
            TxtItemCode.Focus()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormTrfDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub TxtCodeCompFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeCompFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim dt As DataTable = get_company_by_code(addSlashes(TxtCodeCompFrom.Text), "AND (comp.id_comp_cat=5 OR comp.id_comp_cat=6) ")
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
            Dim dt As DataTable = get_company_by_code(addSlashes(TxtCodeCompTo.Text), "AND (comp.id_comp_cat=5 OR comp.id_comp_cat=6) ")
            If dt.Rows.Count > 0 Then
                id_comp_to = dt.Rows(0)("id_comp").ToString
                TxtCodeCompTo.Text = dt.Rows(0)("comp_number").ToString
                TxtNameCompTo.Text = dt.Rows(0)("comp_name").ToString
                viewDetail()
                TxtItemCode.Focus()
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

    Private Sub FormTrfDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
        End If
    End Sub

    Sub save()
        If id_report_status_glb <> "5" And id_report_status_glb <> "6" Then
            Cursor = Cursors.WaitCursor
            Dim trf_note As String = addSlashes(MENote.Text)
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
                Dim data_temp As DataTable = GCScan.DataSource
                Dim connection_string As String = String.Format("Data Source={0};User Id={1};Password={2};Database={3};Convert Zero Datetime=True", app_host, app_username, app_password, app_database)
                Dim connection As New MySql.Data.MySqlClient.MySqlConnection(connection_string)
                connection.Open()
                Dim command As MySql.Data.MySqlClient.MySqlCommand = connection.CreateCommand()
                Dim qry As String = "DROP TABLE IF EXISTS tb_trf_temp; CREATE TEMPORARY TABLE IF NOT EXISTS tb_trf_temp AS ( SELECT * FROM ("
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
                qry += ") a ); ALTER TABLE tb_trf_temp CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci; "
                command.CommandText = qry
                command.ExecuteNonQuery()
                command.Dispose()
                ' Console.WriteLine(qry)

                Dim data_view As New DataTable
                Dim qry_view As String = "SELECT a.id_item, a.item_code, a.item_name, a.size, COUNT(a.id_item) AS `trf_qty`, a.price 
                                FROM tb_trf_temp a 
                                GROUP BY a.id_item"
                Dim adapter As New MySql.Data.MySqlClient.MySqlDataAdapter(qry_view, connection)
                adapter.SelectCommand.CommandTimeout = 300
                adapter.Fill(data_view)
                adapter.Dispose()
                connection.Close()
                connection.Dispose()

                'get data stock
                Dim query_stock As String = "CALL view_stock_item('AND f.is_active=1 AND j.id_comp=" + id_comp_from + " AND j.storage_item_datetime<=''9999-12-01'' ', '2')"
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
                                    .trf_qty = table1("trf_qty"),
                                    .qty_avl = If(y1 Is Nothing, 0, y1("qty_avl")),
                                    .price = table1("price"),
                                    .amount = table1("trf_qty") * table1("price"),
                                    .status = If(table1("trf_qty") <= If(y1 Is Nothing, 0, y1("qty_avl")), "OK", "Can't exceed " + If(y1 Is Nothing, 0, y1("qty_avl").ToString))
                                }
                GCScanSum.DataSource = Nothing
                GCScanSum.DataSource = query_cek.ToList()

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


            If id_comp_from = "-1" Or id_comp_to = "-1" Or gv.RowCount = 0 Then
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
                        Dim query As String = "INSERT INTO tb_trf(id_comp_from, id_comp_to, trf_number, trf_date, trf_note, id_report_status, id_prepared_by) 
                        VALUES('" + id_comp_from + "', '" + id_comp_to + "', header_number(3), NOW(), '" + trf_note + "', '1', '" + id_user + "'); SELECT LAST_INSERT_ID(); "
                        id = execute_query(query, 0, True, "", "", "", "")

                        'detail
                        Dim query_det As String = "INSERT INTO tb_trf_det(id_trf, id_item, price, trf_qty) VALUES "
                        For i As Integer = 0 To ((GVScanSum.RowCount - 1) - GetGroupRowCount(GVScanSum))
                            Dim id_item As String = GVScanSum.GetRowCellValue(i, "id_item").ToString
                            Dim price As String = decimalSQL(GVScanSum.GetRowCellValue(i, "price").ToString)
                            Dim trf_qty As String = decimalSQL(GVScanSum.GetRowCellValue(i, "trf_qty").ToString)
                            If i > 0 Then
                                query_det += ", "
                            End If
                            query_det += "('" + id + "','" + id_item + "', '" + price + "', '" + trf_qty + "')"
                        Next
                        If GVScanSum.RowCount > 0 Then
                            execute_non_query(query_det, True, "", "", "", "")
                        End If


                        'reserved
                        Dim query_res As String = "INSERT INTO tb_storage_item(id_comp, id_storage_category, id_item, report_mark_type, id_report, storage_item_qty, storage_item_datetime, id_stock_status) 
                                                SELECT tb_trf.id_comp_from, 2, tb_trf_det.id_item, 3, " + id + ", tb_trf_det.trf_qty, NOW(), 2 
                                                FROM tb_trf_det 
                                                INNER JOIN tb_trf ON tb_trf.id_trf = tb_trf_det.id_trf
                                                WHERE tb_trf_det.id_trf=" + id + ""
                        execute_non_query(query_res, True, "", "", "", "")

                        FormTrf.viewTrf()
                        FormTrf.GVTrf.FocusedRowHandle = find_row(FormTrf.GVTrf, "id_trf", id)
                        action = "upd"
                        actionLoad()
                        infoCustom("Document #" + TxtNumber.Text + " was created successfully.")
                    Else
                        Dim query As String = "UPDATE tb_trf SET trf_note='" + trf_note + "', id_report_status='" + id_report_status + "' "
                        If id_report_status = "5" Or id_report_status = "6" Then 'final
                            query += ", final_status_time=NOW() "
                        End If
                        query += "WHERE id_trf ='" + id + "' "
                        execute_non_query(query, True, "", "", "", "")

                        'completed
                        If id_report_status = "6" Then 'completed
                            Dim query_stk As String = "INSERT INTO tb_storage_item(id_comp, id_storage_category, id_item, report_mark_type, id_report, storage_item_qty, storage_item_datetime, id_stock_status) 
                                                (SELECT tb_trf.id_comp_from, 1, tb_trf_det.id_item, 3, " + id + ", tb_trf_det.trf_qty, NOW(), 2 
                                                FROM tb_trf_det 
                                                INNER JOIN tb_trf ON tb_trf.id_trf = tb_trf_det.id_trf
                                                WHERE tb_trf_det.id_trf=" + id + ") 
                                                UNION ALL 
                                                (SELECT tb_trf.id_comp_from, 2, tb_trf_det.id_item, 3, " + id + ", tb_trf_det.trf_qty, NOW(), 1 
                                                FROM tb_trf_det 
                                                INNER JOIN tb_trf ON tb_trf.id_trf = tb_trf_det.id_trf
                                                WHERE tb_trf_det.id_trf=" + id + ") 
                                                UNION ALL
                                                (SELECT tb_trf.id_comp_to, 1, tb_trf_det.id_item, 3, " + id + ", tb_trf_det.trf_qty, NOW(), 1 
                                                FROM tb_trf_det 
                                                INNER JOIN tb_trf ON tb_trf.id_trf = tb_trf_det.id_trf
                                                WHERE tb_trf_det.id_trf=" + id + ") 
                                               "
                            execute_non_query(query_stk, True, "", "", "", "")
                        ElseIf id_report_status = "5" Then 'cancelled
                            Dim query_stk As String = "INSERT INTO tb_storage_item(id_comp, id_storage_category, id_item, report_mark_type, id_report, storage_item_qty, storage_item_datetime, id_stock_status) 
                                                SELECT tb_trf.id_comp_from, 1, tb_trf_det.id_item, 3, " + id + ", tb_trf_det.trf_qty, NOW(), 2 
                                                FROM tb_trf_det 
                                                INNER JOIN tb_trf ON tb_trf.id_trf = tb_trf_det.id_trf
                                                WHERE tb_trf_det.id_trf=" + id + ""
                            execute_non_query(query_stk, True, "", "", "", "")
                        End If

                        FormTrf.viewTrf()
                        FormTrf.GVTrf.FocusedRowHandle = find_row(FormTrf.GVTrf, "id_trf", id)
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
        If action = "ins" Then
            Cursor = Cursors.WaitCursor
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = DialogResult.Yes Then
                GVScan.DeleteSelectedRows()
                GCScan.RefreshDataSource()
                GVScan.RefreshData()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Sub print()
        Cursor = Cursors.WaitCursor
        FormBlack.Show()
        ReportTrf.id = id
        ReportTrf.dt = GCScanSum.DataSource
        Dim Report As New ReportTrf()

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
        Report.LabelTo.Text = TxtCodeCompTo.Text + " - " + TxtNameCompTo.Text
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
        FormBlack.Close()
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

    Private Sub TxtItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtItemCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim code As String = TxtItemCode.Text
            Dim query As String = "CALL view_stock_item('AND f.is_active=1 AND j.id_comp=" + id_comp_from + " AND f.item_code=" + code + " AND j.storage_item_datetime<=''9999-12-01'' ', '2')"
            Dim dt As DataTable = execute_query(query, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                Dim newRow As DataRow = (TryCast(GCScan.DataSource, DataTable)).NewRow()
                newRow("id_trf_det") = "0"
                newRow("id_item") = dt(0)("id_item").ToString
                newRow("item_code") = dt(0)("item_code").ToString
                newRow("item_name") = dt(0)("item_name").ToString
                newRow("size") = dt(0)("size").ToString
                newRow("trf_qty") = 1
                newRow("price") = dt(0)("price")
                TryCast(GCScan.DataSource, DataTable).Rows.Add(newRow)
                GCScan.RefreshDataSource()
                GVScan.RefreshData()
            Else
                stopCustom("Code not found")
            End If
            TxtItemCode.Text = ""
            TxtItemCode.Focus()
        End If
    End Sub

    Private Sub GVScanSum_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVScanSum.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub PCClose_MouseHover(sender As Object, e As EventArgs) Handles PCClose.MouseHover
        Cursor = Cursors.Hand
    End Sub

    Private Sub PCClose_MouseLeave(sender As Object, e As EventArgs) Handles PCClose.MouseLeave
        Cursor = Cursors.Default
    End Sub

    Private Sub PCClose_Click(sender As Object, e As EventArgs) Handles PCClose.Click
        closeForm()
    End Sub
End Class