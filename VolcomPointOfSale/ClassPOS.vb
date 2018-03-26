Public Class ClassPOS
    Public Const eClear As String = Chr(27) + "@"
    Public Const eCentre As String = Chr(27) + Chr(97) + "1"
    Public Const eLeft As String = Chr(27) + Chr(77) + "1" + Chr(27) + Chr(97) + "0"
    Public Const eRight As String = Chr(27) + Chr(97) + "2"
    Public Const eDrawer As String = eClear + Chr(27) + "p" + Chr(0) + ".}"
    Public Const eCut As String = Chr(27) + "i" + vbCrLf
    Public Const eSmlText As String = Chr(27) + "!" + Chr(1)
    Public Const eNmlText As String = Chr(27) + "!" + Chr(0)
    Public Const eInit As String = eNmlText + Chr(13) + Chr(27) + "3" + Chr(18) + vbCrLf
    Public Const eBigCharOn As String = Chr(27) + "!" + Chr(56)
    Public Const eBigCharOff As String = Chr(27) + "!" + Chr(0)
    Dim stt_pos As String = "1"
    Dim is_payment_ok As String = "2"

    Private prn As New ClassRawPrint

    Private PrinterName As String = get_setup_field("printer_name")

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

        Dim query As String = "SELECT p.id_pos, ref.pos_number AS `pos_ref_number`,p.pos_number, 
        p.pos_date, DATE_FORMAT(p.pos_date,'%d/%m/%Y') AS  `pos_date_display` , DATE_FORMAT(p.pos_date,'%H:%i') AS  `pos_time_display`,
        p.id_shift, s.id_shift_type, st.shift_type, st.shift_name, st.shift_start, s.id_user, 
        s.id_pos_dev, pd.pos_dev, pd.mac_address,
        s.open_shift, s.close_shift, s.cash AS `cash_initial`, s.is_open, 
        s.id_user, csh.username AS `cashier`, csh_emp.employee_code AS `cashier_number`, csh_emp.employee_name AS `cashier_name`,  
        p.id_pos_status, stt.pos_status,
        p.id_pos_cat, cat.pos_cat,
        p.subtotal, p.discount, p.tax, p.total,(p.total*-1) AS `total_refund`, 
        CAST(((100/(100+o.tax))*p.total) AS DECIMAL(15,0)) AS `kena_ppn`,
        CAST(((o.tax/(100+o.tax))*p.total) AS DECIMAL(15,0)) AS `ppn`,
        p.id_voucher, p.voucher_number, p.voucher, p.point, p.cash, (p.total-(p.card+p.voucher)) AS `cash_drawer`,
        p.card, p.id_card_type, card.card_type, p.card_number, p.card_name, p.`change`, p.`total_qty`, (p.`total_qty`*-1) AS `total_qty_refund`,
        p.id_sales, emp.employee_code AS `sales_number`, emp.employee_name AS `sales_name`, p.id_country, cty.country,p.is_payment_ok
        FROM tb_pos p 
        INNER JOIN tb_shift s ON s.id_shift = p.id_shift 
        INNER JOIN tb_shift_type st ON st.id_shift_type = s.id_shift_type 
        INNER JOIN tb_user csh ON csh.id_user = s.id_user
        INNER JOIN tb_m_employee csh_emp ON csh_emp.id_employee = csh.id_employee
        INNER JOIN tb_pos_dev pd ON pd.id_pos_dev = s.id_pos_dev
        LEFT JOIN tb_m_employee emp ON emp.id_employee = p.id_sales
        LEFT JOIN tb_m_country cty ON cty.id_country = p.id_country
        INNER JOIN tb_lookup_pos_status stt ON stt.id_pos_status = p.id_pos_status
        INNER JOIN tb_lookup_pos_cat cat ON cat.id_pos_cat = p.id_pos_cat
        LEFT JOIN tb_lookup_card_type card ON card.id_card_type = p.id_card_type
        LEFT JOIN tb_pos ref ON ref.id_pos = p.id_pos_ref
        JOIN tb_opt o
        WHERE p.id_pos>0 "
        query += condition + " "
        query += "ORDER BY p.id_pos " + order_type
        Return query
    End Function

    Public Function queryDet(ByVal condition As String, ByVal order_type As String)
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

        Dim query As String = "SELECT pd.id_pos_det, pd.id_pos,
        pd.id_item, i.item_code, 
        i.item_name, 
        IF(LENGTH(i.item_name)<=35,i.item_name, SUBSTRING(i.item_name,1,35)) AS `item_name_display`,
        pd.comm, pd.qty, pd.price, (pd.price*pd.qty) AS `amo`, 
        '' AS `is_edit`
        FROM tb_pos_det pd 
        INNER JOIN tb_item i ON i.id_item = pd.id_item 
        WHERE pd.id_pos>0 "
        query += condition + " "
        query += "ORDER BY pd.id_pos_det " + order_type
        Return query
    End Function

    Public Function getPOSDev() As DataTable
        Dim mycomp As New ClassUser()
        Dim query As String = "SELECT * FROM tb_pos_dev WHERE mac_address='" + mycomp.getMacAddress() + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function


    Public Function queryShift(ByVal condition As String, ByVal order_type As String) As String
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

        Dim query As String = "SELECT s.id_shift, s.id_shift_type, st.shift_type, st.shift_name, st.shift_start, 
        s.id_user, u.`username`, s.id_pos_dev, dev.pos_dev, dev.mac_address, s.open_shift, DATE_FORMAT(s.open_shift,'%d/%m/%Y') AS  `open_shift_display`, s.close_shift, s.cash, s.is_open 
        FROM tb_shift s 
        INNER JOIN tb_shift_type st ON st.id_shift_type = s.id_shift_type 
        INNER JOIN tb_pos_dev dev ON dev.id_pos_dev = s.id_pos_dev
        INNER JOIN tb_user u ON u.id_user = s.id_user
        WHERE s.id_shift>0 "
        query += condition + " "
        query += "ORDER BY s.id_shift " + order_type
        Return query
    End Function

    Public Function querySal(ByVal condition As String, ByVal order_by As String, ByVal group_by As String) As String
        If order_by <> "-1" Then
            order_by = "ORDER BY " + order_by
        Else
            order_by = ""
        End If

        If condition <> "-1" Then
            condition = condition
        Else
            condition = ""
        End If

        If group_by <> "-1" Then
            group_by = "GROUP BY " + group_by
        Else
            group_by = ""
        End If

        Dim query As String = "SELECT e.employee_name, SUM(p.subtotal) AS `subtotal`, SUM(p.discount) AS `discount`,
        (SUM(p.subtotal)-SUM(p.discount)) AS `after_discount`,
        SUM(p.tax) AS `tax`, SUM(p.total) AS `total`,
        SUM(p.card) AS `card`, SUM(p.voucher) AS `voucher`,
        SUM(p.total)-(SUM(p.card)+SUM(p.voucher)) AS `cash_in_drawer`, SUM(p.total_qty) AS `total_qty`
        FROM tb_pos p
        INNER JOIN tb_m_employee e ON e.id_employee = p.id_sales
        WHERE p.id_pos>0 "
        query += condition + " "
        query += group_by + " "
        query += order_by + " "
        Return query
    End Function

    '===========PRINTER==================
    Private Sub StartPrint()
        prn.OpenPrint(PrinterName)
    End Sub

    Private Sub PrintHeader()
        Dim query As String = "Select * FROM tb_opt"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Print(eInit + eCentre + Chr(27) + Chr(33) + Chr(16) + data.Rows(0)("header_1").ToString)
        Print(eNmlText + Chr(27) + Chr(77) + "1" + data.Rows(0)("header_2").ToString)
        Print(Chr(27) + Chr(77) + "1" + data.Rows(0)("header_3").ToString)
        Print(Chr(27) + Chr(77) + "1" + data.Rows(0)("header_4").ToString)
        Print(Chr(27) + Chr(77) + "1" + data.Rows(0)("header_5").ToString + eLeft)
        PrintDashes()
    End Sub

    Private Sub PrintHeaderRefund(ByVal id_pos As String)
        Dim query As String = queryMain("And p.id_pos=" + id_pos + "", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Print(eInit + eCentre + Chr(27) + Chr(33) + Chr(14) + "*** REFUND ***")
        Print(eNmlText + Chr(27) + Chr(77) + "1" + "REF NO. : " + data.Rows(0)("pos_ref_number").ToString)
        PrintDashes()
    End Sub

    Private Sub PrintHeaderClosing()
        Dim query As String = "Select * FROM tb_opt"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Print(eInit + eCentre + Chr(27) + Chr(33) + Chr(16) + data.Rows(0)("header_closing").ToString)
        Print(eNmlText + Chr(27) + Chr(77) + "1" + data.Rows(0)("header_1").ToString)
        Print(Chr(27) + Chr(77) + "1" + data.Rows(0)("header_2").ToString)
    End Sub

    Private Sub PrintBody(ByVal id_pos As String, ByVal copy As Boolean)
        Dim query_main As String = queryMain("AND p.id_pos=" + id_pos + "", "1")
        Dim dt_main As DataTable = execute_query(query_main, -1, True, "", "", "", "")
        Print(eLeft + dt_main.Rows(0)("pos_number").ToString + Chr(13) + eRight + dt_main.Rows(0)("pos_date_display").ToString)
        Print(eLeft + dt_main.Rows(0)("pos_dev").ToString + Chr(13) + eRight + dt_main.Rows(0)("pos_time_display").ToString)

        If copy Then
            Dim dt As String = DateTime.Parse(getTimeDB.ToString).ToString("dd\/MM\/yyyy HH:mm:ss")
            PrintDashes()
            Print(eNmlText + eCentre + "Printed : " + dt)
            Print(eCentre + Chr(27) + Chr(33) + Chr(16) + "- C  O  P  Y -" + eNmlText + Chr(27) + Chr(77) + "1")
        End If


        Print(eLeft + "No.--------Code--------Qty--------Amount")
        Dim query_det As String = queryDet("AND pd.id_pos=" + id_pos + "", "1")
        Dim dt_det As DataTable = execute_query(query_det, -1, True, "", "", "", "")
        Dim no As Integer = 1
        For i As Integer = 0 To (dt_det.Rows.Count - 1)
            printItem(no.ToString, dt_det.Rows(i)("item_code").ToString, dt_det.Rows(i)("item_name_display").ToString, Decimal.Parse(dt_det.Rows(i)("qty")).ToString("N0"), Decimal.Parse(dt_det.Rows(i)("amo")).ToString("N0"))
            no += 1
        Next

        PrintDashes()
        Dim total_qty As String = Decimal.Parse(dt_main.Rows(0)("total_qty")).ToString("N0")
        If total_qty.Length = "1" Then
            total_qty = " " + total_qty
        Else
            total_qty = total_qty
        End If
        Print(eLeft + "Total                  " + total_qty + Chr(13) + eRight + Decimal.Parse(dt_main.Rows(0)("total")).ToString("N0"))
        Print(eLeft + "Dasar Kena PPN" + Chr(13) + eRight + Decimal.Parse(dt_main.Rows(0)("kena_ppn")).ToString("N0"))
        Print(eLeft + "PPN" + Chr(13) + eRight + Decimal.Parse(dt_main.Rows(0)("ppn")).ToString("N0"))
        Print(eLeft + "Cash" + Chr(13) + eRight + Decimal.Parse(dt_main.Rows(0)("cash")).ToString("N0"))
        If dt_main.Rows(0)("card") > 0 Then
            Print(eLeft + "Card" + Chr(13) + eRight + Decimal.Parse(dt_main.Rows(0)("card")).ToString("N0"))
        End If
        If dt_main.Rows(0)("voucher") > 0 Then
            Print(eLeft + "Voucher" + Chr(13) + eRight + Decimal.Parse(dt_main.Rows(0)("voucher")).ToString("N0"))
        End If
        Print(eLeft + "Change" + Chr(13) + eRight + Decimal.Parse(dt_main.Rows(0)("change")).ToString("N0"))

        'jika ada card/voucher
        Print(vbLf)
        If dt_main.Rows(0)("card") > 0 Then
            Print(eLeft + "       Card Type" + "    : " + dt_main.Rows(0)("card_type").ToString)
            Print(eLeft + "       Number" + "       : " + dt_main.Rows(0)("card_number").ToString)
            Print(eLeft + "       Holder" + "       : " + dt_main.Rows(0)("card_name").ToString)
        End If
        If dt_main.Rows(0)("voucher") > 0 Then
            Print(eLeft + "       Voucher No." + "  : " + dt_main.Rows(0)("voucher_number"))
        End If

        stt_pos = dt_main.Rows(0)("id_pos_status").ToString
        is_payment_ok = dt_main.Rows(0)("is_payment_ok").ToString
        Print(vbLf)
    End Sub

    Private Sub PrintBodyRefund(ByVal id_pos As String)
        Dim query_main As String = queryMain("AND p.id_pos=" + id_pos + "", "1")
        Dim dt_main As DataTable = execute_query(query_main, -1, True, "", "", "", "")
        Print(eLeft + dt_main.Rows(0)("pos_number").ToString + Chr(13) + eRight + dt_main.Rows(0)("pos_date_display").ToString)
        Print(eLeft + dt_main.Rows(0)("pos_dev").ToString + Chr(13) + eRight + dt_main.Rows(0)("pos_time_display").ToString)

        Print(eLeft + "No.--------Code--------Qty--------Amount")
        Dim query_det As String = queryDet("AND pd.id_pos=" + id_pos + "", "1")
        Dim dt_det As DataTable = execute_query(query_det, -1, True, "", "", "", "")
        Dim no As Integer = 1
        For i As Integer = 0 To (dt_det.Rows.Count - 1)
            printItem(no.ToString, dt_det.Rows(i)("item_code").ToString, dt_det.Rows(i)("item_name_display").ToString, Decimal.Parse(dt_det.Rows(i)("qty")).ToString("N0"), Decimal.Parse(dt_det.Rows(i)("amo")).ToString("N0"))
            no += 1
        Next

        PrintDashes()
        Dim total_qty As String = Decimal.Parse(dt_main.Rows(0)("total_qty")).ToString("N0")
        If total_qty.Length = "1" Then
            total_qty = " " + total_qty
        Else
            total_qty = total_qty
        End If
        Print(eLeft + "Total                  " + total_qty + Chr(13) + eRight + Decimal.Parse(dt_main.Rows(0)("total")).ToString("N0"))
        Print(vbLf)
    End Sub

    Private Sub PrintBodyClosing(ByVal id_shift As String)
        Dim query_main As String = queryShift("AND s.id_shift=" + id_shift + "", "1")
        Dim dt_main As DataTable = execute_query(query_main, -1, True, "", "", "", "")
        Print(eLeft + "========================================")
        Print(eLeft + "Date      : " + dt_main.Rows(0)("open_shift_display").ToString)
        Print(eLeft + "Cashier   : " + dt_main.Rows(0)("username").ToString)
        Print(eLeft + "Shift     : " + dt_main.Rows(0)("shift_type").ToString + Chr(13) + eRight + "POS#" + dt_main.Rows(0)("pos_dev").ToString)
        Print(eLeft + "========================================")

        Dim sal As New ClassPOS()
        Dim query_sal As String = sal.querySal("AND  p.id_shift=" + id_shift + " AND p.id_pos_status=2", "p.id_pos ASC", "p.id_shift")
        Dim dt_sal As DataTable = execute_query(query_sal, -1, True, "", "", "", "")

        Dim subtotal As String = "0"
        Dim discount As String = "0"
        Dim after_discount As String = "0"
        Dim tax As String = "0"
        Dim netto As String = "0"
        Dim card As String = "0"
        Dim voucher As String = "0"
        Dim cash_in_drawer As String = "0"

        If dt_sal.Rows.Count > 0 Then
            subtotal = Decimal.Parse(dt_sal.Rows(0)("subtotal").ToString()).ToString("N0")
            discount = Decimal.Parse(dt_sal.Rows(0)("discount").ToString()).ToString("N0")
            after_discount = Decimal.Parse(dt_sal.Rows(0)("after_discount").ToString()).ToString("N0")
            tax = Decimal.Parse(dt_sal.Rows(0)("tax").ToString()).ToString("N0")
            netto = Decimal.Parse(dt_sal.Rows(0)("total").ToString()).ToString("N0")
            card = Decimal.Parse(dt_sal.Rows(0)("card").ToString()).ToString("N0")
            voucher = Decimal.Parse(dt_sal.Rows(0)("voucher").ToString()).ToString("N0")
            cash_in_drawer = Decimal.Parse(dt_sal.Rows(0)("cash_in_drawer").ToString()).ToString("N0")
        End If
        Print(eLeft + "a. Gross Sale Before Disc.." + Chr(13) + eRight + subtotal)
        Print(eLeft + "b. Discount................" + Chr(13) + eRight + discount)
        Print(eRight + "----------")
        Print(eLeft + "c. Gross Sale After Disc..." + Chr(13) + eRight + after_discount)
        Print(eLeft + "d. Tax....................." + Chr(13) + eRight + tax)
        Print(eRight + "----------")
        Print(eLeft + "e. Netto..................." + Chr(13) + eRight + netto)
        Print(eLeft + "")
        Print(eLeft + "f. Card...................." + Chr(13) + eRight + card)
        Print(eLeft + "g. Voucher................." + Chr(13) + eRight + voucher)
        Print(eRight + "----------")
        Print(eLeft + "h. Cash in Drawer.........." + Chr(13) + eRight + cash_in_drawer)
        Print(eLeft + "")

        'refund
        Print(eLeft + "i. Refund List :")
        Print(eLeft + "   No  Ref      Time  Qty         Amount")
        Print(eLeft + "   -------------------------------------")
        'Print(eLeft + "   100 10008511 18:50 100 99.999.900.000")
        Dim qrf As String = sal.queryMain("AND p.id_shift=" + id_shift + " AND p.id_pos_cat=2 AND p.id_pos_status=2", "1")
        Dim dtf As DataTable = execute_query(qrf, -1, True, "", "", "", "")
        Dim total_refund As Decimal = 0
        Dim total_qty_refund As Decimal = 0
        If dtf.Rows.Count > 0 Then
            Dim no_refund As Integer = 1
            For i As Integer = 0 To dtf.Rows.Count - 1
                'no
                Dim no As String = ""
                If no_refund.ToString.Length = 1 Then
                    no = no_refund.ToString + "  "
                ElseIf no_refund.ToString.Length = 2 Then
                    no = no_refund.ToString + " "
                Else
                    no = no_refund.ToString
                End If

                'number
                Dim ref_max As Integer = 8
                Dim ref As String = dtf.Rows(i)("pos_ref_number").ToString
                If ref.Length < ref_max Then
                    For c = 1 To (ref_max - ref.Length)
                        ref += " "
                    Next
                Else
                    ref = ref
                End If

                'qty
                Dim qty As String = Decimal.Parse(dtf.Rows(i)("total_qty_refund").ToString).ToString("N0")
                If qty.ToString.Length = 1 Then
                    qty = "  " + qty.ToString
                ElseIf no_refund.ToString.Length = 2 Then
                    qty = " " + qty.ToString
                Else
                    qty = qty.ToString
                End If
                total_qty_refund += dtf.Rows(i)("total_qty_refund")

                'total
                Dim total_max As Integer = 14
                Dim total As String = Decimal.Parse(dtf.Rows(i)("total_refund").ToString).ToString("N0")
                If total.Length < total_max Then
                    For a = 1 To (total_max - total.Length)
                        total = " " + total
                    Next
                Else
                    total = total
                End If
                total_refund += dtf.Rows(i)("total_refund")

                Print(eLeft + "   " + no + " " + ref + " " + DateTime.Parse(dtf.Rows(i)("pos_date").ToString).ToString("HH:mm") + " " + qty + " " + total)
                no_refund += 1
            Next
        End If
        Print(eRight + "----------")
        'total qty display
        Dim total_qty_refund_d As String = Decimal.Parse(total_qty_refund).ToString("N0")
        If total_qty_refund_d.ToString.Length = 1 Then
            total_qty_refund_d = "  " + total_qty_refund_d.ToString
        ElseIf total_qty_refund_d.ToString.Length = 2 Then
            total_qty_refund_d = " " + total_qty_refund_d.ToString
        Else
            total_qty_refund_d = total_qty_refund_d.ToString
        End If
        'total refund display
        Dim total_display_max As Integer = 14
        Dim total_refund_d As String = Decimal.Parse(total_refund).ToString("N0")
        If total_refund_d.Length < total_display_max Then
            For a = 1 To (total_display_max - total_refund_d.Length)
                total_refund_d = " " + total_refund_d
            Next
        Else
            total_refund_d = total_refund_d
        End If
        Print(eLeft + "   Total............  " + total_qty_refund_d + " " + total_refund_d)
        Print(eLeft + "")

        'voucher
        Print(eLeft + "j. Voucher List : ")
        Print(eLeft + "   No  Voucher# Ref     Time     Amount")
        Print(eLeft + "   -------------------------------------")
        'Print(eLeft + "   100 16110000 1001158 15:23 99.999.000")
        Dim qvch As String = sal.queryMain("AND p.id_shift=" + id_shift + " AND p.id_pos_status=2 AND !ISNULL(p.id_voucher)", "1")
        Dim dtvch As DataTable = execute_query(qvch, -1, True, "", "", "", "")
        Dim total_vch As Decimal = 0
        If dtvch.Rows.Count > 0 Then
            Dim no_vch As Integer = 1
            For i As Integer = 0 To dtvch.Rows.Count - 1
                'no
                Dim no As String = ""
                If no_vch.ToString.Length = 1 Then
                    no = no_vch.ToString + "  "
                ElseIf no_vch.ToString.Length = 2 Then
                    no = no_vch.ToString + " "
                Else
                    no = no_vch.ToString
                End If

                'nyumber
                Dim number_max As Integer = 8
                Dim number As String = dtvch.Rows(i)("voucher_number").ToString
                If number.Length < number_max Then
                    For c = 1 To (number_max - number.Length)
                        number += " "
                    Next
                Else
                    number = number
                End If

                'ref
                Dim ref_max As Integer = 7
                Dim ref As String = dtvch.Rows(i)("pos_number").ToString
                If ref.Length < ref_max Then
                    For a = 1 To (ref_max - ref.Length)
                        ref = " " + ref
                    Next
                Else
                    ref = ref
                End If

                'voucher
                Dim vch_max As Integer = 10
                Dim vch As String = Decimal.Parse(dtvch.Rows(i)("voucher").ToString).ToString("N0")
                If vch.Length < vch_max Then
                    For a = 1 To (vch_max - vch.Length)
                        vch = " " + vch
                    Next
                Else
                    vch = vch
                End If
                total_vch += dtvch.Rows(i)("voucher")

                'time
                Dim time_vch As String = DateTime.Parse(dtf.Rows(i)("pos_date").ToString).ToString("HH:mm")

                Print(eLeft + "   " + no + " " + number + " " + ref + " " + time_vch + " " + vch)
                no_vch += 1
            Next
        End If
        Print(eRight + "----------")
        Print(eLeft + "   Total............  " + Chr(13) + eRight + Decimal.Parse(total_vch.ToString).ToString("N0"))
        Print(eLeft + "")

        'statisctic
        Print(eLeft + "k. Statistics :")
        Dim qstt As String = sal.querySal("AND p.id_shift=" + id_shift + " AND p.id_pos_status=2", "p.id_pos ASC", "p.id_pos")
        Dim dtstt As DataTable = execute_query(qstt, -1, True, "", "", "", "")
        Print(eLeft + "   - No. of Transaction : " + dtstt.Rows.Count.ToString)
        Print(eLeft + "")

        'sales performance
        Print(eLeft + "l. Sales Promotion Performance :")
        Print(eLeft + "   Name                   Qty     Amount")
        Print(eLeft + "   -------------------------------------")
        'Print(eLeft + "   ABCDEFGHIJKLMNOPQRSTUV 100 99.999.999")
        Dim qsls As String = sal.querySal("AND p.id_shift=" + id_shift + " AND p.id_pos_status=2", "e.employee_name ASC", "p.id_sales")
        Dim dtsls As DataTable = execute_query(qsls, -1, True, "", "", "", "")
        Dim total_sls As Decimal = 0
        Dim total_qty As Decimal = 0
        If dtsls.Rows.Count > 0 Then
            Dim no_sls As Integer = 1
            For i As Integer = 0 To dtsls.Rows.Count - 1
                'name
                Dim name_max As Integer = 22
                Dim name As String = dtsls.Rows(i)("employee_name").ToString
                If name.Length < name_max Then
                    For c = 1 To (name_max - name.Length)
                        name += " "
                    Next
                Else
                    name = name
                End If

                'qty
                Dim qty_max As Integer = 3
                Dim qty As String = Decimal.Parse(dtsls.Rows(i)("total_qty").ToString).ToString("N0")
                If qty.Length < qty_max Then
                    For a = 1 To (qty_max - qty.Length)
                        qty = " " + qty
                    Next
                Else
                    qty = qty
                End If
                total_qty += dtsls.Rows(i)("total_qty")

                'total
                Dim amount_max As Integer = 10
                Dim amount As String = Decimal.Parse(dtsls.Rows(i)("total").ToString).ToString("N0")
                If amount.Length < amount_max Then
                    For a = 1 To (amount_max - amount.Length)
                        amount = " " + amount
                    Next
                Else
                    amount = amount
                End If
                total_sls += dtsls.Rows(i)("total")

                Print(eLeft + "   " + name.Substring(0, 22) + " " + qty + " " + amount)
                no_sls += 1
            Next
        End If
        Print(eRight + "----------")
        'qty display
        Dim qty_d_max As Integer = 3
        Dim total_qty_d As String = Decimal.Parse(total_qty.ToString).ToString("N0")
        If total_qty_d.Length < qty_d_max Then
            For a = 1 To (qty_d_max - total_qty_d.Length)
                total_qty_d = " " + total_qty_d
            Next
        Else
            total_qty_d = total_qty_d
        End If
        'total sls display
        Dim total_sls_d_max As Integer = 10
        Dim total_sls_d As String = Decimal.Parse(total_sls).ToString("N0")
        If total_sls_d.Length < total_sls_d_max Then
            For a = 1 To (total_sls_d_max - total_sls_d.Length)
                total_sls_d = " " + total_sls_d
            Next
        Else
            total_sls_d = total_sls_d
        End If
        Print(eLeft + "   Total................. " + total_qty_d + " " + total_sls_d)
        Print(vbLf)
    End Sub


    Private Sub printItem(ByVal no As String, code As String, desc As String, qty As String, amount As String)
        'no=5; code=18; qty=2; amount=15
        If no.Length = "1" Then
            no = " " + no + ".  "
        Else
            no = no + ".  "
        End If

        Dim code_max As Integer = 18
        If code.Length < code_max Then
            For c = 1 To (code_max - code.Length)
                code += " "
            Next
        Else
            code = code
        End If

        If qty.Length = "1" Then
            qty = " " + qty
        Else
            qty = qty
        End If

        Dim amount_max As Integer = 15
        If amount.Length < amount_max Then
            For a = 1 To (amount_max - amount.Length)
                amount = " " + amount
            Next
        Else
            amount = amount
        End If
        Print(eLeft + no + code + qty + amount)
        Print(eLeft + "     " + desc)
    End Sub

    Private Sub PrintFooter()
        If stt_pos = "2" Or (stt_pos = "1" And is_payment_ok = "1") Then 'closed
            Dim query As String = "SELECT * FROM tb_opt"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Print(eCentre + data.Rows(0)("footer_1").ToString)
            Print(eCentre + data.Rows(0)("footer_2").ToString)
            Print(eCentre + data.Rows(0)("footer_3").ToString)
            Print(eCentre + data.Rows(0)("footer_4").ToString)
        ElseIf stt_pos = "3" Then 'cancelled
            Print(eCentre + "*** CANCELLED TRANSACTION ***")
        Else
            Print(eCentre + "*** OPENED TRANSACTION ***")
        End If

        Print(vbLf + vbLf + vbLf + vbLf + vbLf + vbLf + vbLf + vbLf + vbLf + eCut + eDrawer)
    End Sub

    Private Sub PrintFooterRefund()
        Print(eCentre + "--- ACC SUPERVISOR ---")
        Print(vbLf + vbLf + vbLf + vbLf + vbLf + vbLf + vbLf + vbLf + vbLf + eCut + eDrawer)
    End Sub

    Private Sub PrintFooterClosing()
        Dim dt As DateTime = getTimeDB()
        Print(eLeft + "Supervisor Check :")
        Print(eLeft + "Date : " + DateTime.Parse(dt.ToString).ToString("dd\/MM\/yyyy"))
        Print(eLeft + "Time : " + DateTime.Parse(dt.ToString).ToString("HH:mm:ss"))
        Print(vbLf + vbLf + vbLf + vbLf + vbLf + vbLf + vbLf + vbLf + vbLf + vbLf + vbLf + eCut + eDrawer)
    End Sub

    Private Sub Print(Line As String)
        prn.SendStringToPrinter(PrinterName, Line + vbLf)
    End Sub

    Private Sub PrintDashes()
        Print(eLeft + eNmlText + "-".PadRight(33, "-"))
    End Sub

    Private Sub EndPrint()
        prn.ClosePrint()
    End Sub

    Public Sub printPos(ByVal id_pos As String, ByVal copy As Boolean)
        StartPrint()

        If prn.PrinterIsOpen = True Then
            PrintHeader()
            PrintBody(id_pos, copy)
            PrintFooter()
            EndPrint()
        End If
    End Sub

    Public Sub printRefund(ByVal id_pos As String)
        StartPrint()

        If prn.PrinterIsOpen = True Then
            PrintHeaderRefund(id_pos)
            PrintBodyRefund(id_pos)
            PrintFooterRefund()
            EndPrint()
        End If
    End Sub

    Public Sub printClosing(ByVal id_shift As String)
        StartPrint()

        If prn.PrinterIsOpen = True Then
            PrintHeaderClosing()
            PrintBodyClosing(id_shift)
            PrintFooterClosing()
            EndPrint()
        End If
    End Sub

    Sub cut()
        StartPrint()

        If prn.PrinterIsOpen = True Then
            Print(vbLf + vbLf + vbLf + vbLf + vbLf + vbLf + vbLf + vbLf + vbLf + eCut + eDrawer)
            EndPrint()
        End If
    End Sub


    Sub vfdDisplayText(ByVal line1 As String, ByVal line2 As String)
        Try
            Dim sp As New IO.Ports.SerialPort()

            sp.PortName = "COM4"
            sp.BaudRate = 9600
            sp.Open()
            sp.Write(Convert.ToString(ChrW(12)))
            sp.WriteLine(line1)
            sp.WriteLine(ChrW(13) & line2)
            sp.Close()
            sp.Dispose()
            sp = Nothing
        Catch ex As Exception
        End Try
    End Sub

End Class
