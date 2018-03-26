Public Class FormReportTransDetail
    Dim from As String = ""
    Dim until As String = ""
    Dim status As String = ""
    Dim shift As String = ""
    Dim pos As String = ""

    Private Sub FormReportTransDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEFrom.EditValue = getTimeDB()
        DEUntil.EditValue = getTimeDB()
        viewShift()
        viewStatus()
        viewPOSDev()
    End Sub

    Sub viewPOSDet()
        Cursor = Cursors.WaitCursor
        Dim cond As String = ""

        'date
        Dim dt_from As String = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim dt_until As String = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        cond += "AND (DATE(p.pos_date) >= DATE('" + dt_from + "') AND DATE(p.pos_date) <= DATE('" + dt_until + "')) "

        'status
        cond += "AND p.id_pos_status=" + LEStatus.EditValue.ToString + " "

        'shift
        If LEShift.EditValue.ToString <> "0" Then
            cond += "AND s.id_shift_type=" + LEShift.EditValue.ToString + " "
        End If

        'pos
        cond += "AND sh.id_pos_dev=" + LEPOSDev.EditValue.ToString + " "


        Dim query As String = "SELECT pd.id_item, i.id_size, s.size, i.item_code, i.item_name,
        SUM(pd.qty) AS `qty`, pd.price
        FROM tb_pos_det pd
        INNER JOIN tb_pos p ON p.id_pos = pd.id_pos
        INNER JOIN tb_item i ON i.id_item = pd.id_item
        INNER JOIN tb_size s ON s.id_size = i.id_size 
        INNER JOIN tb_shift sh ON sh.id_shift = p.id_shift
        WHERE 1=1 "
        query += cond + " "
        query += "GROUP BY pd.id_item "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCTransDetail.DataSource = data

        'label
        from = DEFrom.Text
        until = DEUntil.Text
        status = LEStatus.Text
        shift = LEShift.Text
        pos = LEPOSDev.Text
        Cursor = Cursors.Default
    End Sub

    Sub viewShift()
        Dim query As String = "SELECT 0 AS `id_shift_type`, 'ALL' AS `shift_type` UNION ALL "
        query += "SELECT s.id_shift_type, s.shift_type FROM tb_shift_type s ORDER BY id_shift_type ASC "
        viewLookupQuery(LEShift, query, 0, "shift_type", "id_shift_type")
    End Sub

    Sub viewStatus()
        Dim query As String = "SELECT * FROM tb_lookup_pos_status s ORDER BY s.id_pos_status ASC "
        viewLookupQuery(LEStatus, query, 1, "pos_status", "id_pos_status")
    End Sub

    Sub viewPOSDev()
        Dim query As String = "SELECT * FROM tb_pos_dev d ORDER BY d.id_pos_dev ASC "
        viewLookupQuery(LEPOSDev, query, 1, "pos_dev", "id_pos_dev")
    End Sub

    Sub exitForm()
        Close()
    End Sub

    Private Sub FormReportTransDetail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            exitForm()
        ElseIf e.KeyCode = Keys.F10 Then
            printPreview()
        End If
    End Sub

    Sub printPreview()
        Cursor = Cursors.WaitCursor
        FormBlack.Show()
        ReportTransDetail.dt = GCTransDetail.DataSource
        Dim Report As New ReportTransDetail()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVTransDetail.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVTransDetail.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVTransDetail)

        'Parse val
        Dim dt As DateTime = getTimeDB()
        Report.LabelFrom.Text = from
        Report.LabelUntil.Text = until
        Report.LabelShift.Text = shift
        Report.LabelStatus.Text = status
        Report.LabelDate.Text = dt.ToString("dd\/MM\/yyyy")
        Report.LabelTime.Text = dt.ToString("HH:mm:ss")
        Report.LabelPOS.Text = "POS-" + pos
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
        FormBlack.Close()
        Cursor = Cursors.Default
    End Sub

    Private Sub PanelControlBack_Click(sender As Object, e As EventArgs) Handles PanelControlBack.Click
        exitForm()
    End Sub

    Private Sub FormReportTransDetail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewPOSDet()
    End Sub

    Private Sub GVTransDetail_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVTransDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub DEFrom_EditValueChanged(sender As Object, e As EventArgs) Handles DEFrom.EditValueChanged
        DEUntil.Properties.MinValue = DEFrom.EditValue
    End Sub

    Private Sub DEFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntil.Focus()
        End If
    End Sub

    Private Sub DEUntil_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntil.KeyDown
        If e.KeyCode = Keys.Enter Then
            LEStatus.Focus()
        End If
    End Sub

    Private Sub LEStatus_KeyDown(sender As Object, e As KeyEventArgs) Handles LEStatus.KeyDown
        If e.KeyCode = Keys.Enter Then
            LEShift.Focus()
        End If
    End Sub

    Private Sub LEShift_KeyDown(sender As Object, e As KeyEventArgs) Handles LEShift.KeyDown
        If e.KeyCode = Keys.Enter Then
            LEPOSDev.Focus()
        End If
    End Sub

    Private Sub LEPOSDev_KeyDown(sender As Object, e As KeyEventArgs) Handles LEPOSDev.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnView.Focus()
        End If
    End Sub
End Class