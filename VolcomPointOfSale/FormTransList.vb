Public Class FormTransList
    Private Sub FormTransList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As DateTime = getTimeDB()
        DEFromRec.EditValue = dt
        DEUntilRec.EditValue = dt
        DEFromTrf.EditValue = dt
        DEUntilTrf.EditValue = dt
        DEFromRet.EditValue = dt
        DEUntilRet.EditValue = dt
    End Sub

    Private Sub BtnViewRec_Click(sender As Object, e As EventArgs) Handles BtnViewRec.Click
        viewRec()
    End Sub

    Sub viewRec()
        Cursor = Cursors.WaitCursor
        Dim date_from As String = ""
        Try
            date_from = DateTime.Parse(DEFromRec.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim date_until As String = ""
        Try
            date_until = DateTime.Parse(DEUntilRec.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim cond As String = "AND (DATE(r.rec_date)>='" + date_from + "' AND DATE(r.rec_date)<='" + date_until + "' )"


        Dim query As String = "SELECT r.id_rec_own AS `id_rec`, r.rec_number AS `number`, 'Own Product' AS `type`,
        CONCAT(cf.comp_number, ' - ', cf.comp_name) AS `from`,
        CONCAT(ct.comp_number, ' - ', ct.comp_name) AS `to`,
        r.rec_date AS `created_date`, del.item_code, del.item_name, cls.class_display AS `class`,
        del.id_size, sz.size, del.price, rd.qty, 
        rs.report_status AS `status`
        FROM tb_rec_own_det rd
        INNER JOIN tb_rec_own r ON r.id_rec_own = rd.id_rec_own
        INNER JOIN tb_delivery_slip del ON del.id_delivery_slip = rd.id_delivery_slip
        INNER JOIN tb_size sz ON sz.id_code_detail = del.id_size
        INNER JOIN tb_class cls ON cls.id_code_detail = del.id_class
        INNER JOIN tb_m_comp cf ON cf.id_comp = r.id_comp_from
        INNER JOIN tb_m_comp ct ON ct.id_comp = r.id_comp_to
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = r.id_report_status
        WHERE 1=1 " + cond + "
        UNION ALL
        SELECT r.id_rec AS `id_rec`, r.rec_number AS `number`, 'Other Product' AS `type`,
        CONCAT(cf.comp_number, ' - ', cf.comp_name) AS `from`,
        CONCAT(ct.comp_number, ' - ', ct.comp_name) AS `to`,
        r.rec_date AS `created_date`, i.item_code, i.item_name, cls.class_display AS `class`,
        i.id_size, sz.size, i.price, rd.rec_qty AS `qty`, 
        rs.report_status AS `status` 
        FROM tb_rec r
        INNER JOIN tb_rec_det rd ON rd.id_rec = r.id_rec
        INNER JOIN tb_item i ON i.id_item = rd.id_item
        INNER JOIN tb_size sz ON sz.id_size = i.id_size
        INNER JOIN tb_class cls ON cls.id_class =i.id_class
        INNER JOIN tb_m_comp cf ON cf.id_comp = r.id_comp_from
        INNER JOIN tb_m_comp ct ON ct.id_comp = r.id_comp_to
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = r.id_report_status
        WHERE 1=1 " + cond + " ORDER BY created_date ASC, item_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCReceive.DataSource = data
        GVReceive.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormTransList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnPrintRec_Click(sender As Object, e As EventArgs) Handles BtnPrintRec.Click
        Cursor = Cursors.WaitCursor
        print_raw(GCReceive, "")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrintTrf_Click(sender As Object, e As EventArgs) Handles BtnPrintTrf.Click
        Cursor = Cursors.WaitCursor
        print_raw(GCTrf, "")
        Cursor = Cursors.Default
    End Sub

    Sub viewTrf()
        Cursor = Cursors.WaitCursor
        Dim date_from As String = ""
        Try
            date_from = DateTime.Parse(DEFromTrf.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim date_until As String = ""
        Try
            date_until = DateTime.Parse(DEUntilTrf.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim cond As String = "AND (DATE(r.trf_date)>='" + date_from + "' AND DATE(r.trf_date)<='" + date_until + "' )"


        Dim query As String = "SELECT r.id_trf AS `id`, r.trf_number AS `number`, 
        CONCAT(cf.comp_number, ' - ', cf.comp_name) AS `from`,
        CONCAT(ct.comp_number, ' - ', ct.comp_name) AS `to`,
        r.trf_date AS `created_date`, i.item_code, i.item_name, cls.class_display AS `class`,
        i.id_size, sz.size, i.price, rd.trf_qty AS `qty`, 
        rs.report_status AS `status` 
        FROM tb_trf r
        INNER JOIN tb_trf_det rd ON rd.id_trf = r.id_trf
        INNER JOIN tb_item i ON i.id_item = rd.id_item
        INNER JOIN tb_size sz ON sz.id_size = i.id_size
        INNER JOIN tb_class cls ON cls.id_class =i.id_class
        INNER JOIN tb_m_comp cf ON cf.id_comp = r.id_comp_from
        INNER JOIN tb_m_comp ct ON ct.id_comp = r.id_comp_to
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = r.id_report_status
        WHERE 1=1 " + cond + " 
        ORDER BY r.id_trf ASC, i.item_name ASC, i.item_code ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCTrf.DataSource = data
        GVTrf.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewTrf_Click(sender As Object, e As EventArgs) Handles BtnViewTrf.Click
        viewTrf()
    End Sub

    Sub viewRet()
        Cursor = Cursors.WaitCursor
        Dim date_from As String = ""
        Try
            date_from = DateTime.Parse(DEFromRet.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim date_until As String = ""
        Try
            date_until = DateTime.Parse(DEUntilRet.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim cond As String = "AND (DATE(r.ret_date)>='" + date_from + "' AND DATE(r.ret_date)<='" + date_until + "' )"


        Dim query As String = "SELECT r.id_ret AS `id`, r.ret_number AS `number`, 
        CONCAT(cf.comp_number, ' - ', cf.comp_name) AS `from`,
        CONCAT(ct.comp_number, ' - ', ct.comp_name) AS `to`,
        r.ret_date AS `created_date`, i.item_code, i.item_name, cls.class_display AS `class`,
        i.id_size, sz.size, i.price, rd.ret_qty AS `qty`, 
        rs.report_status AS `status` 
        FROM tb_ret r
        INNER JOIN tb_ret_det rd ON rd.id_ret = r.id_ret
        INNER JOIN tb_item i ON i.id_item = rd.id_item
        INNER JOIN tb_size sz ON sz.id_size = i.id_size
        INNER JOIN tb_class cls ON cls.id_class =i.id_class
        INNER JOIN tb_m_comp cf ON cf.id_comp = r.id_comp_from
        INNER JOIN tb_m_comp ct ON ct.id_comp = r.id_comp_to
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = r.id_report_status
        WHERE 1=1 " + cond + " 
        ORDER BY r.id_ret ASC, i.item_name ASC, i.item_code ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRet.DataSource = data
        GVRet.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewRet_Click(sender As Object, e As EventArgs) Handles BtnViewRet.Click
        viewRet()
    End Sub

    Private Sub BtnPrintRet_Click(sender As Object, e As EventArgs) Handles BtnPrintRet.Click
        Cursor = Cursors.WaitCursor
        print_raw(GCRet, "")
        Cursor = Cursors.Default
    End Sub
End Class