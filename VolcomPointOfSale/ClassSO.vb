Public Class ClassSO
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

        Dim query As String = "SELECT s.id_so, 
        s.id_comp, c.comp_number AS `comp_number`, c.comp_name AS `comp_name`, CONCAT(c.comp_number,' - ', c.comp_name) AS `comp`,
        s.so_number, s.so_date, s.so_note, 
        s.id_report_status, stt.report_status, s.id_prepared_by, e.employee_name, rl.role
        FROM tb_so s
        INNER JOIN tb_m_comp c ON c.id_comp = s.id_comp
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = s.id_report_status 
        INNER JOIN tb_user u ON u.id_user = s.id_prepared_by 
        INNER JOIN tb_role rl ON rl.id_role = u.id_role
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee 
        WHERE s.id_so>0 "
        query += condition + " "
        query += "ORDER BY s.id_so " + order_type
        Return query
    End Function
End Class
