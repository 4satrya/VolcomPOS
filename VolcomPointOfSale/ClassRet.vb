Public Class ClassRet
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

        Dim query As String = "SELECT r.id_ret, 
        r.id_comp_from, cfr.comp_number AS `comp_number_from`, cfr.comp_name AS `comp_name_from`, CONCAT(cfr.comp_number,' - ', cfr.comp_name) AS `comp_from`,
        r.id_comp_to, cto.comp_number AS `comp_number_to`, cto.comp_name AS `comp_name_to`,CONCAT(cto.comp_number,' - ', cto.comp_name) AS `comp_to`,
        r.ret_number, r.ret_date, r.ref, r.ref_date, r.ret_note, 
        r.id_report_status, stt.report_status, r.id_prepared_by, e.employee_name, rl.role, SUM(rd.ret_qty) AS `total_ret`
        FROM tb_ret r
        INNER JOIN tb_ret_det rd ON rd.id_ret = r.id_ret
        INNER JOIN tb_m_comp cfr ON cfr.id_comp = r.id_comp_from
        INNER JOIN tb_m_comp cto ON cto.id_comp = r.id_comp_to
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = r.id_report_status 
        INNER JOIN tb_user u ON u.id_user = r.id_prepared_by 
        INNER JOIN tb_role rl ON rl.id_role = u.id_role
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee 
        WHERE r.id_ret>0 "
        query += condition + " "
        query += "GROUP BY r.id_ret "
        query += "ORDER BY r.id_ret " + order_type
        Return query
    End Function
End Class
