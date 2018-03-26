Public Class FormPOSDrawerInfo
    Public id_shift As String = "-1"

    Private Sub FormPOSDrawerInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'opt
        Dim query_opt As String = "SELECT * FROM tb_opt"
        Dim dt_opt As DataTable = execute_query(query_opt, -1, True, "", "", "", "")
        LabelHeader1.Text = dt_opt.Rows(0)("header_1").ToString
        LabelHeader2.Text = dt_opt.Rows(0)("header_2").ToString

        'shift
        Dim pos As New ClassPOS()
        Dim query_shf As String = pos.queryShift("AND s.id_shift=" + id_shift + "", "1")
        Dim dt_shf As DataTable = execute_query(query_shf, -1, True, "", "", "", "")
        LabelDateShift.Text = DateTime.Parse(dt_shf.Rows(0)("open_shift").ToString).ToString("dd/MM/yyyy")
        LabelCashier.Text = dt_shf.Rows(0)("username").ToString
        LabelShift.Text = dt_shf.Rows(0)("shift_type").ToString
        LabelPOS.Text = "POS#" + dt_shf.Rows(0)("pos_dev").ToString

        'info sales
        Dim sal As New ClassPOS()
        Dim query_sal As String = sal.querySal("AND  p.id_shift=" + id_shift + " AND p.id_pos_status=2", "p.id_pos ASC", "p.id_shift")
        Dim dt_sal As DataTable = execute_query(query_sal, -1, True, "", "", "", "")
        If dt_sal.Rows.Count > 0 Then
            LabelBefore.Text = Decimal.Parse(dt_sal.Rows(0)("subtotal").ToString()).ToString("N0")
            LabelDiscount.Text = Decimal.Parse(dt_sal.Rows(0)("discount").ToString()).ToString("N0")
            LabelAfter.Text = Decimal.Parse(dt_sal.Rows(0)("after_discount").ToString()).ToString("N0")
            LabelTax.Text = Decimal.Parse(dt_sal.Rows(0)("tax").ToString()).ToString("N0")
            LabelNetto.Text = Decimal.Parse(dt_sal.Rows(0)("total").ToString()).ToString("N0")
            LabelCard.Text = Decimal.Parse(dt_sal.Rows(0)("card").ToString()).ToString("N0")
            LabelVoucher.Text = Decimal.Parse(dt_sal.Rows(0)("voucher").ToString()).ToString("N0")
            LabelCashDrawer.Text = Decimal.Parse(dt_sal.Rows(0)("cash_in_drawer").ToString()).ToString("N0")
        End If

        'refund
        Dim qrf As String = sal.queryMain("AND p.id_shift=" + id_shift + " AND p.id_pos_cat=2 AND p.id_pos_status=2", "1")
        Dim dtf As DataTable = execute_query(qrf, -1, True, "", "", "", "")
        GCRefund.DataSource = dtf

        'voucher
        Dim qvch As String = sal.queryMain("AND p.id_shift=" + id_shift + " AND p.id_pos_status=2 AND !ISNULL(p.id_voucher)", "1")
        Dim dtvch As DataTable = execute_query(qvch, -1, True, "", "", "", "")
        GCVoucher.DataSource = dtvch

        'statisctic
        Dim qstt As String = sal.querySal("AND p.id_shift=" + id_shift + " AND p.id_pos_status=2", "p.id_pos ASC", "p.id_pos")
        Dim dtstt As DataTable = execute_query(qstt, -1, True, "", "", "", "")
        LabelSold.Text = dtstt.Rows.Count.ToString

        'sales performance
        Dim qsls As String = sal.querySal("AND p.id_shift=" + id_shift + " AND p.id_pos_status=2", "e.employee_name ASC", "p.id_sales")
        Dim dtsls As DataTable = execute_query(qsls, -1, True, "", "", "", "")
        GCSales.DataSource = dtsls


    End Sub

    Private Sub GVRefund_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVRefund.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVVoucher_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVVoucher.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

End Class