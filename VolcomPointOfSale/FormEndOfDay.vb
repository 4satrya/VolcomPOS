Public Class FormEndOfDay
    Private Sub FormEndOfDay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        'get max date
        Dim qmd As String = "SELECT p.pos_date as `date_now` FROM tb_pos p WHERE p.id_pos_status=2 ORDER BY p.id_pos ASC LIMIT 1 "
        Dim dmd As DataTable = execute_query(qmd, -1, True, "", "", "", "")
        DETransDate.EditValue = dmd.Rows(0)("date_now")
        Dim trans_date As String = DateTime.Parse(DETransDate.EditValue.ToString).ToString("yyyy-MM-dd")

        'cek shift ad yg masi buka
        Dim qcs As String = "SELECT * FROM tb_pos p 
        INNER JOIN tb_shift s ON s.id_shift = p.id_shift
        WHERE p.id_pos_status=2 AND DATE(p.pos_date)='" + trans_date + "' AND s.is_open=1 "
        Dim dcs As DataTable = execute_query(qcs, -1, True, "", "", "", "")
        If dcs.Rows.Count > 0 Then
            stopCustom("Can't continue this action, because active shift still open. Please make sure to do the closing shift")
            Close()
            Exit Sub
        End If

        'cek amount
        Dim qam As String = "SELECT IFNULL(SUM(p.total),0) AS `amount` FROM tb_pos p 
        INNER JOIN tb_shift s ON s.id_shift = p.id_shift
        WHERE p.id_pos_status=2 AND DATE(p.pos_date)='" + trans_date + "' AND p.is_closed=2 "
        Dim dam As DataTable = execute_query(qam, -1, True, "", "", "", "")
        If dam.Rows.Count <= 0 Then
            TxtAmount.EditValue = 0
        Else
            TxtAmount.EditValue = dam.Rows(0)("amount")
        End If
        If TxtAmount.EditValue <= 0 Then
            stopCustom("Transaction not found")
            Close()
            Exit Sub
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormEndOfDay_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to continue this action ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                Dim trans_date As String = DateTime.Parse(DETransDate.EditValue.ToString).ToString("yyyy-MM-dd")
                Dim p As New ClassPOS()
                p.endOfDay(trans_date)
                Close()
            Catch ex As Exception
                stopCustom(ex.ToString)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub
End Class