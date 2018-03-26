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
        r.id_report_status, stt.report_status, r.id_prepared_by, e.employee_name, rl.role, SUM(rd.rec_qty) AS `total_rec`
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
End Class
