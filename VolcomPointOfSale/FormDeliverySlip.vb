Public Class FormDeliverySlip
    Public id As String = "-1"

    Private Sub FormDeliverySlip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDelSlip()
    End Sub

    Private Sub FormDeliverySlip_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewDelSlip()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT d.id_delivery_slip, d.id_pl_sales_order_del, d.number, 
        d.id_wh, CONCAT(wh.comp_number, ' - ', wh.comp_name) AS `wh`, d.id_store,CONCAT(sto.comp_number, ' - ', sto.comp_name) AS `store`,
        d.created_date,
        d.item_code, d.item_name, d.qty, d.id_design_cat, cat.design_cat, d.price, sz.size
        FROM tb_delivery_slip d
        INNER JOIN tb_m_comp wh ON wh.id_comp = d.id_wh
        INNER JOIN tb_m_comp sto ON sto.id_comp = d.id_store
        INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = d.id_design_cat
        INNER JOIN tb_size sz ON sz.id_code_detail = d.id_size
        WHERE d.id_delivery_slip>0 "
        If id <> "-1" Then
            query += "AND d.id_pl_sales_order_del='" + id + "' "
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub
End Class