Public Class ClassAdj
    Public Function queryMainOut(ByVal condition As String, ByVal order_type As String) As String
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

        Dim query As String = "SELECT o.id_adj_out, 
        o.id_comp, c.comp_number AS `comp_number`, c.comp_name AS `comp_name`, CONCAT(c.comp_number,' - ', c.comp_name) AS `comp`,
        o.adj_out_number, o.adj_out_date, o.adj_out_note, 
        o.id_report_status, stt.report_status, o.id_prepared_by, e.employee_name, rl.role
        FROM tb_adj_out o
        INNER JOIN tb_m_comp c ON c.id_comp = o.id_comp
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = o.id_report_status 
        INNER JOIN tb_user u ON u.id_user = o.id_prepared_by 
        INNER JOIN tb_role rl ON rl.id_role = u.id_role
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee 
        WHERE o.id_adj_out>0 "
        query += condition + " "
        query += "ORDER BY o.id_adj_out " + order_type
        Return query
    End Function

    Public Function queryMainIn(ByVal condition As String, ByVal order_type As String) As String
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

        Dim query As String = "SELECT i.id_adj_in, 
        i.id_comp, c.comp_number AS `comp_number`, c.comp_name AS `comp_name`, CONCAT(c.comp_number,' - ', c.comp_name) AS `comp`,
        i.adj_in_number, i.adj_in_date, i.adj_in_note, 
        i.id_report_status, stt.report_status, i.id_prepared_by, e.employee_name, rl.role
        FROM tb_adj_in i
        INNER JOIN tb_m_comp c ON c.id_comp = i.id_comp
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = i.id_report_status 
        INNER JOIN tb_user u ON u.id_user = i.id_prepared_by 
        INNER JOIN tb_role rl ON rl.id_role = u.id_role
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee 
        WHERE i.id_adj_in>0 "
        query += condition + " "
        query += "ORDER BY i.id_adj_in " + order_type
        Return query
    End Function
End Class
