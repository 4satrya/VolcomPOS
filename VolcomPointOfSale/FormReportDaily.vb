Public Class FormReportDaily
    Dim from As String = ""
    Dim until As String = ""
    Dim status As String = ""
    Dim shift As String = ""

    Private Sub FormReportDaily_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEFrom.Focus()
        DEFrom.EditValue = getTimeDB()
        DEUntil.EditValue = getTimeDB()
        viewShift()
        viewStatus()
    End Sub

    Sub exitForm()
        Close()
    End Sub

    Sub viewPOS()
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


        Dim pos As New ClassPOS()
        Dim query As String = pos.queryMain(cond, "1")
        Dim dt As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDaily.DataSource = dt

        'label
        from = DEFrom.Text
        until = DEUntil.Text
        status = LEStatus.Text
        shift = LEShift.Text
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewPOS()
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

    Private Sub FormReportDaily_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub PanelControlBack_Click(sender As Object, e As EventArgs) Handles PanelControlBack.Click
        exitForm()
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
            BtnView.Focus()
        End If
    End Sub

    Private Sub GVDaily_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDaily.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub DEFrom_EditValueChanged(sender As Object, e As EventArgs) Handles DEFrom.EditValueChanged
        DEUntil.Properties.MinValue = DEFrom.EditValue
    End Sub

    Private Sub FormReportDaily_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            exitForm()
        ElseIf e.KeyCode = Keys.F10 Then
            printPreview()
        End If
    End Sub

    Sub printPreview()
        Cursor = Cursors.WaitCursor
        FormBlack.Show()
        ReportDaily.dt = GCDaily.DataSource
        Dim Report As New ReportDaily()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVDaily.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVDaily.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVDaily)

        'Parse val
        Dim dt As DateTime = getTimeDB()
        Report.LabelFrom.Text = from
        Report.LabelUntil.Text = until
        Report.LabelShift.Text = shift
        Report.LabelStatus.Text = status
        Report.LabelDate.Text = dt.ToString("dd\/MM\/yyyy")
        Report.LabelTime.Text = dt.ToString("HH:mm:ss")

        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
        FormBlack.Close()
        Cursor = Cursors.Default
    End Sub


End Class