Public Class ClassComp
    Public Function queryMain(ByVal condition As String, ByVal order_type As String, ByVal is_all As Boolean) As String
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

        Dim query As String = "SELECT comp.id_comp, comp.id_comp_cat, cat.comp_cat_name,
        ct.id_comp_contact, ct.contact_person, ct.contact_number,
        CONCAT(comp.comp_number,' - ', comp.comp_name) AS `comp`, comp.comp_number, comp.comp_name, comp.comp_display_name, comp.address_primary
        FROM tb_m_comp comp 
        INNER JOIN tb_m_comp_cat cat ON cat.id_comp_cat = comp.id_comp_cat 
        INNER JOIN tb_m_comp_contact ct ON ct.id_comp = comp.id_comp AND ct.is_default=1 
        WHERE comp.id_comp>0 "
        query += condition + " "
        query += "ORDER BY comp.id_comp " + order_type

        'all item include
        If is_all Then
            Dim query_all As String = "(SELECT 0 AS `id_comp`, 0 AS `id_comp_cat`, '-' AS `comp_cat_name`,
            0 AS `id_comp_contact`, '-' AS contact_person, 0 AS `contact_number`,
            'All Account' AS `comp`, '0' AS comp_number, 'All Account' AS `comp_name`, 'All Account' AS `comp_display_name`, '-' AS `address_primary`) "
            query = query_all + " UNION ALL " + "(" + query + ")"
        End If

        Return query
    End Function
End Class
