Public Class ClassTrf
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

        Dim query As String = "SELECT t.id_trf, 
        t.id_comp_from, cfr.comp_number AS `comp_number_from`, cfr.comp_name AS `comp_name_from`, CONCAT(cfr.comp_number,' - ', cfr.comp_name) AS `comp_from`,
        t.id_comp_to, cto.comp_number AS `comp_number_to`, cto.comp_name AS `comp_name_to`,CONCAT(cto.comp_number,' - ', cto.comp_name) AS `comp_to`,
        t.trf_number, t.trf_date, t.trf_note, 
        t.id_report_status, stt.report_status, t.id_prepared_by, e.employee_name, rl.role, SUM(td.trf_qty) AS `total_trf`
        FROM tb_trf t
        INNER JOIN tb_trf_det td ON td.id_trf = t.id_trf
        INNER JOIN tb_m_comp cfr ON cfr.id_comp = t.id_comp_from
        INNER JOIN tb_m_comp cto ON cto.id_comp = t.id_comp_to
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = t.id_report_status 
        INNER JOIN tb_user u ON u.id_user = t.id_prepared_by 
        INNER JOIN tb_role rl ON rl.id_role = u.id_role
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee 
        WHERE t.id_trf>0 "
        query += condition + " "
        query += "GROUP BY t.id_trf "
        query += "ORDER BY t.id_trf " + order_type
        Return query
    End Function
End Class
