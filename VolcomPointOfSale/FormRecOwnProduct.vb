Public Class FormRecOwnProduct
    Public id As String = "-1"
    Public id_pl_sales_order_del As String = "-1"
    Public id_comp_from As String = "-1"
    Public id_comp_to As String = "-1"
    Dim ref_date As String = ""
    Public action As String = "-1"
    Dim id_report_status As String = "-1"

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
            Dim query As String = "SELECT d.id_pl_sales_order_del, d.number, d.id_wh, wh.comp_number AS `wh_number`, wh.comp_name AS `wh_name` 
            FROM tb_delivery_slip d
            INNER JOIN tb_m_comp wh ON wh.id_comp = d.id_wh
            WHERE d.id_pl_sales_order_del=" + id_pl_sales_order_del + "
            GROUP BY d.id_pl_sales_order_del "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtDelSlip.Text = data.Rows(0)("number").ToString
            id_comp_from = data.Rows(0)("id_wh").ToString
            TxtFromCode.Text = data.Rows(0)("wh_number").ToString
            TxtFromName.Text = data.Rows(0)("wh_name").ToString
            TxtPreparedBy.Text = name_user
            viewSummary()
            viewDetail()
        ElseIf action = "upd" Then
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
            GCData.DataSource = data
            GVData.BestFitColumns()
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
        If e.Column.FieldName = "diff" Then
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
End Class