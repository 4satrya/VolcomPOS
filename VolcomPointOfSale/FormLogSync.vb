Public Class FormLogSync
    Private Sub FormLogSync_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt_now As DateTime = getTimeDBServer()
        DEFrom.EditValue = dt_now
        DEUntil.EditValue = dt_now
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewLogData()
    End Sub

    Sub viewLogData()
        Dim date_from As String = ""
        Try
            date_from = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim date_until As String = ""
        Try
            date_until = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query As String = "SELECT l.sync_time, d.sync_data, IF(l.is_success=1,'OK', 'Failed') AS `status`, l.remark 
        FROM tb_sync_log l
        INNER JOIN tb_sync_data d ON d.id_sync_data = l.id_sync_data
        WHERE DATE(l.sync_time)>='" + date_from + "' AND DATE(l.sync_time)<='" + date_until + "' ORDER BY l.sync_time DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
    End Sub

    Private Sub FormLogSync_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class