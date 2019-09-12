Public Class ReportRet
    Public Shared id As String = "-1"
    Public Shared dt As DataTable
    Public Shared is_pre_printing = "-1"

    Private Sub ReportRet_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        If is_pre_printing = "1" Then
            'main
            Dim query As String = "SELECT o.outlet_name AS `own_store_name`, DATE_FORMAT(NOW(), '%d-%m-%Y') AS `created_date`, DATE_FORMAT(NOW(), '%d-%m-%Y') AS `printed_date`, e.employee_nick_name AS `printed_by`
            FROM tb_opt o
            JOIN tb_user u ON u.id_user=" + id_user + "
            INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            DataSource = data
            XrTableAppr.Visible = False
            LabelDistribution.Visible = False

            'detail
            viewDetailPrePrinting()
        Else
            Dim query As String = "SELECT r.id_ret, r.ret_number, DATE_FORMAT(r.ret_date, '%d-%m-%Y') AS `created_date`, r.ref, DATE_FORMAT(r.ref_date, '%d-%m-%Y') AS `ref_date`,
            CONCAT(cf.comp_number, ' - ', cf.comp_name) AS `wh`, CONCAT(ct.comp_number, ' - ', ct.comp_name) AS `supplier`,
            SUM(rd.ret_qty) AS `total_qty`, SUM(rd.ret_qty * rd.price) AS `total_amo`, r.ret_note,
            stt.report_status AS `status`, o.outlet_name AS `own_store_name`, DATE_FORMAT(NOW(), '%d-%m-%Y') AS `printed_date`, e.employee_nick_name AS `printed_by`
            FROM tb_ret r 
            INNER JOIN tb_ret_det rd ON rd.id_ret = r.id_ret
            INNER JOIN tb_m_comp cf ON cf.id_comp = r.id_comp_from
            INNER JOIN tb_m_comp ct ON ct.id_comp = r.id_comp_to
            INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = r.id_report_status
            JOIN tb_opt o
            JOIN tb_user u ON u.id_user=" + id_user + "
            INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
            WHERE r.id_ret=" + id + " GROUP BY r.id_ret "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            DataSource = data

            'set footer detail
            RowTotalQty.Text = Decimal.Parse(data.Rows(0)("total_qty").ToString).ToString("N0")
            RowTotalAmount.Text = Decimal.Parse(data.Rows(0)("total_amo").ToString).ToString("N0")

            'detail
            viewDetail()
        End If
    End Sub

    Sub viewDetail()
        Dim row As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow
        Dim query As String = "SELECT i.item_code AS `code`, i.item_name AS `name`, s.size, rd.ret_qty AS `qty`, rd.price, (rd.ret_qty * rd.price) AS `amount`
        FROM tb_ret r 
        INNER JOIN tb_ret_det rd ON rd.id_ret = r.id_ret
        INNER JOIN tb_item i ON i.id_item = rd.id_item
        INNER JOIN tb_size s ON s.id_size = i.id_size
        WHERE r.id_ret=" + id + " "
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

        Dim font_row_style As New Font("Segoe UI", 7, FontStyle.Regular)
        For i = 0 To data.Rows.Count - 1
            'row
            If i = 0 Then
                row = XTable.InsertRowBelow(XTRow)
                row.HeightF = 15
            Else
                row = XTable.InsertRowBelow(row)
            End If

            'no
            Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
            no.Text = (i + 1).ToString + "."
            no.Borders = DevExpress.XtraPrinting.BorderSide.None
            no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            no.BackColor = Color.Transparent
            no.Font = font_row_style

            'barcode
            Dim code As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
            code.Text = data.Rows(i)("code").ToString
            code.Borders = DevExpress.XtraPrinting.BorderSide.None
            code.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            code.BackColor = Color.Transparent
            code.Font = font_row_style

            'descrition
            Dim descrip As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
            descrip.Text = data.Rows(i)("name").ToString
            descrip.Borders = DevExpress.XtraPrinting.BorderSide.None
            descrip.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            descrip.BackColor = Color.Transparent
            descrip.Font = font_row_style

            'size
            Dim size As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
            size.Text = data.Rows(i)("size").ToString
            size.Borders = DevExpress.XtraPrinting.BorderSide.None
            size.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            size.BackColor = Color.Transparent
            size.Font = font_row_style

            'qty
            Dim qty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
            qty.Text = Decimal.Parse(data.Rows(i)("qty").ToString).ToString("N0")
            qty.Borders = DevExpress.XtraPrinting.BorderSide.None
            qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            qty.BackColor = Color.Transparent
            qty.Font = font_row_style

            'price
            Dim price As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
            price.Text = Decimal.Parse(data.Rows(i)("price").ToString).ToString("N0")
            price.Borders = DevExpress.XtraPrinting.BorderSide.None
            price.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            price.BackColor = Color.Transparent
            price.Font = font_row_style

            'amount
            Dim amo As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)
            amo.Text = Decimal.Parse(data.Rows(i)("amount").ToString).ToString("N0")
            amo.Borders = DevExpress.XtraPrinting.BorderSide.None
            amo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            amo.BackColor = Color.Transparent
            amo.Font = font_row_style
        Next
    End Sub

    Sub viewDetailPrePrinting()
        Dim row As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow
        Dim data As DataTable = dt

        Dim font_row_style As New Font("Segoe UI", 7, FontStyle.Regular)
        For i = 0 To data.Rows.Count - 1
            'row
            If i = 0 Then
                row = XTable.InsertRowBelow(XTRow)
                row.HeightF = 15
            Else
                row = XTable.InsertRowBelow(row)
            End If

            'no
            Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
            no.Text = (i + 1).ToString + "."
            no.Borders = DevExpress.XtraPrinting.BorderSide.None
            no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            no.BackColor = Color.Transparent
            no.Font = font_row_style

            'barcode
            Dim code As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
            code.Text = data.Rows(i)("item_code").ToString
            code.Borders = DevExpress.XtraPrinting.BorderSide.None
            code.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            code.BackColor = Color.Transparent
            code.Font = font_row_style

            'descrition
            Dim descrip As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
            descrip.Text = data.Rows(i)("item_name").ToString
            descrip.Borders = DevExpress.XtraPrinting.BorderSide.None
            descrip.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            descrip.BackColor = Color.Transparent
            descrip.Font = font_row_style

            'size
            Dim size As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
            size.Text = data.Rows(i)("size").ToString
            size.Borders = DevExpress.XtraPrinting.BorderSide.None
            size.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            size.BackColor = Color.Transparent
            size.Font = font_row_style

            'qty
            Dim qty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
            qty.Text = Decimal.Parse(data.Rows(i)("ret_qty").ToString).ToString("N0")
            qty.Borders = DevExpress.XtraPrinting.BorderSide.None
            qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            qty.BackColor = Color.Transparent
            qty.Font = font_row_style

            'price
            Dim price As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
            price.Text = Decimal.Parse(data.Rows(i)("price").ToString).ToString("N0")
            price.Borders = DevExpress.XtraPrinting.BorderSide.None
            price.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            price.BackColor = Color.Transparent
            price.Font = font_row_style

            'amount
            Dim amo As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)
            amo.Text = Decimal.Parse((data.Rows(i)("ret_qty") * data.Rows(i)("price")).ToString).ToString("N0")
            amo.Borders = DevExpress.XtraPrinting.BorderSide.None
            amo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            amo.BackColor = Color.Transparent
            amo.Font = font_row_style
        Next
    End Sub
End Class