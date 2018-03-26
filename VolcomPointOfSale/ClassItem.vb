Public Class ClassItem
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

        Dim query As String = "SELECT i.id_item, i.item_code, i.item_name, CONCAT(i.item_code,' - ', i.item_name) AS `item`, 
        i.id_comp_sup, sup.comp_name AS `comp_sup`, i.id_so_type, i.id_design_cat, cat.design_cat,
        i.id_size, s.size, i.id_class, cls.class_display, cls.class, i.id_color, col.color, i.price, i.price_date, i.comm, i.id_product, i.is_active
        FROM tb_item i 
        INNER JOIN tb_size s ON s.id_size = i.id_size
        INNER JOIN tb_color col ON col.id_color = i.id_color
        INNER JOIN tb_class cls ON cls.id_class = i.id_class
        INNER JOIN tb_m_comp sup ON sup.id_comp = i.id_comp_sup
        INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = i.id_design_cat  
        WHERE i.id_item>0 "
        query += condition + " "
        query += "ORDER BY i.id_item " + order_type

        'all item include
        If is_all Then
            Dim query_all As String = "(SELECT 0 AS `id_item`, '0' AS `item_code`, 'All Product' AS `item_name`, 'All Product' AS `item`, 
            0 AS `id_comp_sup`, '-' AS `comp_sup`, 0 AS `id_so_type`, 0 AS `id_design_cat`, '-' AS `design_cat`,
            '0' AS  `id_class`, '-' AS `class_display`, '-' AS `class`,
            0 AS `id_size`, '-' AS `size`, 0 AS `id_color`, '-' AS color, 0 AS `price`, '-' AS `price_date`, 0 AS `comm`, 0 AS `id_product`, '1' AS `is_active`) "
            query = query_all + " UNION ALL " + "(" + query + ")"
        End If



        Return query
    End Function

    Public Function queryMainUpd(ByVal condition As String) As String
        'dengan harga terbaru
        If condition <> "-1" Then
            condition = condition
        Else
            condition = ""
        End If

        Dim query As String = "SELECT * FROM( "
        query += "SELECT i.id_item, i.item_code, i.item_name, CONCAT(i.item_code,' - ', i.item_name) AS `item`, 
        i.id_comp_sup, i.id_so_type, i.id_design_cat, cat.design_cat,
        i.id_size, s.size, i.id_class, cls.class_display, cls.class, i.id_color, col.color, i.price, i.price_date, i.comm, i.id_product, i.is_active
        FROM tb_item i 
        INNER JOIN tb_size s ON s.id_size = i.id_size
        INNER JOIN tb_color col ON col.id_color = i.id_color
        INNER JOIN tb_class cls ON cls.id_class = i.id_class
        INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = i.id_design_cat 
        WHERE i.id_item>0 "
        query += condition + " "
        query += "ORDER BY i.last_updated DESC 
        ) a GROUP BY a.item_code "
        Return query
    End Function

    Sub syncItem()
        Dim query As String = "CALL get_product()"
        execute_non_query(query, True, "", "", "", "")
    End Sub
End Class
