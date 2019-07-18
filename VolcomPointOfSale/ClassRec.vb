Public Class ClassRec
    Public Function queryMain(ByVal condition As String, ByVal order_type As String) As String
        If order_type = "1" Then
            order_type = "ASC "
        ElseIf order_type = "2" Then
            order_type = "DESC "
        End If

        If condition <> "-1" Then
            condition = condition
        Else
            condition = ""
        End If

        Dim query As String = "SELECT r.id_rec, 
        r.id_comp_from, cfr.comp_number AS `comp_number_from`, cfr.comp_name AS `comp_name_from`, CONCAT(cfr.comp_number,' - ', cfr.comp_name) AS `comp_from`,
        r.id_comp_to, cto.comp_number AS `comp_number_to`, cto.comp_name AS `comp_name_to`,CONCAT(cto.comp_number,' - ', cto.comp_name) AS `comp_to`,
        r.rec_number, r.rec_date, r.ref, r.ref_date, r.rec_note, 
        r.id_report_status, stt.report_status, r.id_prepared_by, e.employee_name, rl.role, SUM(rd.rec_qty) AS `total_qty`
        FROM tb_rec r
        INNER JOIN tb_rec_det rd ON rd.id_rec = r.id_rec
        INNER JOIN tb_m_comp cfr ON cfr.id_comp = r.id_comp_from
        INNER JOIN tb_m_comp cto ON cto.id_comp = r.id_comp_to
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = r.id_report_status 
        INNER JOIN tb_user u ON u.id_user = r.id_prepared_by 
        INNER JOIN tb_role rl ON rl.id_role = u.id_role
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee 
        WHERE r.id_rec>0 "
        query += condition + " "
        query += "GROUP BY r.id_rec "
        query += "ORDER BY r.id_rec " + order_type
        Return query
    End Function

    Public Function queryMainOwn(ByVal condition As String, ByVal order_type As String) As String
        If order_type = "1" Then
            order_type = "ASC "
        ElseIf order_type = "2" Then
            order_type = "DESC "
        End If

        If condition <> "-1" Then
            condition = condition
        Else
            condition = ""
        End If

        Dim query As String = "SELECT r.id_rec_own, 
        r.id_comp_from, cfr.comp_number AS `comp_number_from`, cfr.comp_name AS `comp_name_from`, CONCAT(cfr.comp_number, ' - ', cfr.comp_name) AS `comp_from`,
        r.id_comp_to, cto.comp_number AS `comp_number_to`, cto.comp_name AS `comp_name_to`, CONCAT(cto.comp_number, ' - ', cto.comp_name) AS `comp_to`,
        r.rec_number, r.rec_date,
        r.id_pl_sales_order_del, r.ref, r.rec_note, r.id_prepared_by, emp.employee_name AS `prepared_by`, 
        r.id_report_status, stt.report_status, r.final_status_time, SUM(rd.qty) AS `total_qty`
        FROM tb_rec_own r
        INNER JOIN tb_rec_own_det rd ON rd.id_rec_own = r.id_rec_own
        INNER JOIN tb_m_comp cfr ON cfr.id_comp = r.id_comp_from
        INNER JOIN tb_m_comp cto ON cto.id_comp = r.id_comp_to
        INNER JOIN tb_user u ON u.id_user = r.id_prepared_by
        INNER JOIN tb_m_employee emp ON emp.id_employee = u.id_employee
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = r.id_report_status
        WHERE r.id_rec_own>0 "
        query += condition + " "
        query += "GROUP BY r.id_rec_own "
        query += "ORDER BY r.id_rec_own " + order_type
        Return query
    End Function

    Public Function dataBalRecOwnProduct(ByVal id_pl As String) As DataTable
        Dim query As String = "SELECT del.id_delivery_slip, del.id_product, del.id_design, del.item_code, del.item_name, del.id_size, sz.size, 
        del.price, del.id_design_cat, dcat.design_cat, (del.qty-IFNULL(rec.qty_rec,0)) AS `qty_avl`, 0 AS `qty`
        FROM tb_delivery_slip del
        INNER JOIN tb_size sz ON sz.id_code_detail = del.id_size
        INNER JOIN tb_lookup_design_cat dcat ON dcat.id_design_cat = del.id_design_cat
        LEFT JOIN (
	        SELECT rd.id_delivery_slip, SUM(rd.qty) AS `qty_rec` 
	        FROM tb_rec_own_det rd
	        INNER JOIN tb_rec_own r ON r.id_rec_own = rd.id_rec_own
	        WHERE r.id_pl_sales_order_del=" + id_pl + " AND r.id_report_status!=5
	        GROUP BY rd.id_delivery_slip
        ) rec ON rec.id_delivery_slip = del.id_delivery_slip
        WHERE del.id_pl_sales_order_del=" + id_pl + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function
End Class
