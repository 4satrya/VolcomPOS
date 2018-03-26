Public Class ReportPOSCopy
    Public Shared id As String = "-1"

    Private Sub ReportPOSCopy_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim pos As New ClassPOS()
        Dim query_det As String = pos.queryDet("AND pd.id_pos=" + id + "", "1")
        Dim data As DataTable = execute_query(query_det, -1, True, "", "", "", "")
        GCPOS.DataSource = data
        GVPOS.OptionsPrint.UsePrintStyles = True

        GVPOS.AppearancePrint.FilterPanel.BackColor = Color.Transparent
        GVPOS.AppearancePrint.FilterPanel.ForeColor = Color.Black
        GVPOS.AppearancePrint.FilterPanel.Font = New Font("Segoe UI", 7, FontStyle.Regular)

        GVPOS.AppearancePrint.GroupFooter.BackColor = Color.Transparent
        GVPOS.AppearancePrint.GroupFooter.ForeColor = Color.Black
        GVPOS.AppearancePrint.GroupFooter.Font = New Font("Segoe UI", 7, FontStyle.Bold)

        GVPOS.AppearancePrint.GroupRow.BackColor = Color.Transparent
        GVPOS.AppearancePrint.GroupRow.ForeColor = Color.Black
        GVPOS.AppearancePrint.GroupRow.Font = New Font("Segoe UI", 7, FontStyle.Bold)


        GVPOS.AppearancePrint.HeaderPanel.BackColor = Color.Transparent
        GVPOS.AppearancePrint.HeaderPanel.ForeColor = Color.Black
        GVPOS.AppearancePrint.HeaderPanel.Font = New Font("Segoe UI", 5, FontStyle.Regular)

        GVPOS.AppearancePrint.FooterPanel.BackColor = Color.Transparent
        GVPOS.AppearancePrint.FooterPanel.ForeColor = Color.Black
        GVPOS.AppearancePrint.FooterPanel.Font = New Font("Segoe UI", 5, FontStyle.Regular)

        GVPOS.AppearancePrint.Row.Font = New Font("Segoe UI", 5, FontStyle.Regular)

        GVPOS.OptionsPrint.ExpandAllDetails = True
        GVPOS.OptionsPrint.UsePrintStyles = True
        GVPOS.OptionsPrint.PrintDetails = True
        GVPOS.OptionsPrint.PrintFooter = True

        'header/footer
        Dim query_hf As String = "SELECT * FROM tb_opt"
        Dim data_hf As DataTable = execute_query(query_hf, -1, True, "", "", "", "")
        LHeader1.Text = data_hf.Rows(0)("header_1").ToString
        LHeader2.Text = data_hf.Rows(0)("header_2").ToString
        LHeader3.Text = data_hf.Rows(0)("header_3").ToString
        LHeader4.Text = data_hf.Rows(0)("header_4").ToString
        LHeader5.Text = data_hf.Rows(0)("header_5").ToString
        LabelFooter1.Text = data_hf.Rows(0)("footer_1").ToString
        LabelFooter2.Text = data_hf.Rows(0)("footer_2").ToString
        LabelFooter3.Text = data_hf.Rows(0)("footer_3").ToString
        LabelFooter4.Text = data_hf.Rows(0)("footer_4").ToString

        'main
        Dim query_main As String = pos.queryMain("AND p.id_pos=" + id + "", "1")
        Dim dt_main As DataTable = execute_query(query_main, -1, True, "", "", "", "")
        LNumber.Text = dt_main.Rows(0)("pos_number").ToString
        LCashier.Text = dt_main.Rows(0)("pos_dev").ToString
        Ldate.Text = dt_main.Rows(0)("pos_date_display").ToString
        LTime.Text = dt_main.Rows(0)("pos_time_display").ToString
        LTotal.Text = Decimal.Parse(dt_main.Rows(0)("total")).ToString("N0")
        LKenaPPN.Text = Decimal.Parse(dt_main.Rows(0)("kena_ppn")).ToString("N0")
        LPPN.Text = Decimal.Parse(dt_main.Rows(0)("ppn")).ToString("N0")
        LCash.Text = Decimal.Parse(dt_main.Rows(0)("cash")).ToString("N0")
        If dt_main.Rows(0)("card") > 0 Then
            LCard.Text = Decimal.Parse(dt_main.Rows(0)("card")).ToString("N0")
        End If
        If dt_main.Rows(0)("voucher") > 0 Then
            LVchNumber.Text = Decimal.Parse(dt_main.Rows(0)("voucher")).ToString("N0")
        End If
        LChange.Text = Decimal.Parse(dt_main.Rows(0)("change")).ToString("N0")
        If dt_main.Rows(0)("card") > 0 Then
            LCardType.Text = dt_main.Rows(0)("card_type").ToString
            LCardNumber.Text = dt_main.Rows(0)("card_number").ToString
            LHolder.Text = dt_main.Rows(0)("card_name").ToString
        Else
            LCardTypeHead.Visible = False
            LCardTypeDot.Visible = False
            LCardType.Visible = False
            LCardNumberHead.Visible = False
            LCardNumberDot.Visible = False
            LCardNumber.Visible = False
            LCardHolderHead.Visible = False
            LCardHolderDot.Visible = False
            LHolder.Visible = False
        End If
        If dt_main.Rows(0)("voucher") > 0 Then
            LVchNumber.Text = dt_main.Rows(0)("voucher_number")
        Else
            LVchHead.Visible = False
            LVchDot.Visible = False
            LVchNumber.Visible = False
        End If
    End Sub

    Private Sub GVPOS_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVPOS.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class