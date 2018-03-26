Public Class FormReportCopyReceipt
    Sub exitForm()
        Close()
    End Sub

    Private Sub FormReportCopyReceipt_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnViewPOS.Click
        Dim pos_number As String = addSlashes(TxtPOSNumber.Text)
        Dim pos As New ClassPOS()
        Dim query As String = pos.queryMain("AND p.pos_number='" + pos_number + "'", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            If CEPOS.EditValue.ToString = "True" Then
                ReportPOSCopy.id = data.Rows(0)("id_pos").ToString
                Dim Report As New ReportPOSCopy()
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.PreviewForm.PrintControl.Zoom = 2.0F
                Tool.PreviewForm.FormBorderStyle = FormBorderStyle.None
                Tool.ShowPreviewDialog()
            Else
                pos.printPos(data.Rows(0)("id_pos").ToString, True)
            End If
        Else
            stopCustom("Transaction not found")
        End If
    End Sub

    Private Sub PanelControlBack_Click(sender As Object, e As EventArgs) Handles PanelControlBack.Click
        Close()
    End Sub

    Private Sub PanelControlBack_MouseHover(sender As Object, e As EventArgs) Handles PanelControlBack.MouseHover
        PanelControlBack.Cursor = Cursors.Hand
    End Sub

    Private Sub PanelControlBack_MouseLeave(sender As Object, e As EventArgs) Handles PanelControlBack.MouseLeave
        PanelControlBack.Cursor = Cursors.Default
    End Sub

    Private Sub FormReportCopyReceipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtPOSNumber.Focus()
        DEFrom.EditValue = getTimeDB()
        For Each t As DevExpress.XtraTab.XtraTabPage In XtraTabControl1.TabPages
            XtraTabControl1.SelectedTabPage = t
        Next t
        XtraTabControl1.SelectedTabPage = XtraTabControl1.TabPages(0)
        viewShift()
        viewPOSDev()
        viewCsh()
    End Sub

    Sub viewShift()
        Dim query As String = "SELECT s.id_shift_type, s.shift_type FROM tb_shift_type s ORDER BY id_shift_type ASC "
        viewLookupQuery(LEShift, query, 0, "shift_type", "id_shift_type")
    End Sub

    Sub viewPOSDev()
        Dim query As String = "SELECT * FROM tb_pos_dev d ORDER BY d.id_pos_dev ASC "
        viewLookupQuery(LEPOSDev, query, 1, "pos_dev", "id_pos_dev")
    End Sub

    Sub viewCsh()
        Dim query As String = "SELECT s.id_user, e.employee_name  
        FROM tb_pos p 
        INNER JOIN tb_shift s ON s.id_shift = p.id_shift  
        INNER JOIN tb_user u ON u.id_user = s.id_user 
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee 
        GROUP BY s.id_user "
        viewLookupQuery(LECashier, query, 0, "employee_name", "id_user")
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        If XtraTabControl1.TabIndex = 0 Then
            TxtPOSNumber.Focus()
        Else
            DEFrom.Focus()
        End If
    End Sub

    Private Sub TxtPOSNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtPOSNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            CEPOS.Focus()
        End If
    End Sub

    Private Sub CEPOS_KeyDown(sender As Object, e As KeyEventArgs) Handles CEPOS.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnViewPOS.Focus()
        End If
    End Sub

    Private Sub BtnViewClosing_Click(sender As Object, e As EventArgs) Handles BtnViewClosing.Click
        Dim open_shift As String = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim id_shift_type As String = LEShift.EditValue.ToString
        Dim id_pos_dev As String = LEPOSDev.EditValue.ToString
        Dim id_user_csh As String = LECashier.EditValue.ToString
        Dim pos As New ClassPOS()
        Dim query As String = pos.queryShift("AND DATE(s.open_shift)='" + open_shift + "' AND s.id_shift_type=" + id_shift_type + " AND s.id_pos_dev=" + id_pos_dev + " AND s.id_user=" + id_user_csh + "", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            If CEClosing.EditValue.ToString = "True" Then
                FormBlack.Show()
                FormPOSDrawerInfo.id_shift = data.Rows(0)("id_shift").ToString
                FormPOSDrawerInfo.ShowDialog()
                FormBlack.Close
                BringToFront()
            Else
                pos.printClosing(data.Rows(0)("id_shift").ToString)
            End If
        Else
            stopCustom("Shift not found")
        End If
    End Sub

    Private Sub DEFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFrom.KeyDown
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
            LECashier.Focus()
        End If
    End Sub

    Private Sub LECashier_KeyDown(sender As Object, e As KeyEventArgs) Handles LECashier.KeyDown
        If e.KeyCode = Keys.Enter Then
            CEClosing.Focus()
        End If
    End Sub

    Private Sub CEClosing_KeyDown(sender As Object, e As KeyEventArgs) Handles CEClosing.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnViewClosing.Focus()
        End If
    End Sub
End Class