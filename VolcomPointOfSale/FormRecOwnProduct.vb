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
End Class