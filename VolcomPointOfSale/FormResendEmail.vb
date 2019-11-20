Public Class FormResendEmail
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        'send email
        Dim idx As String = addSlashes(TxtId.Text)
        Dim rmt As String = addSlashes(TxtRMT.Text)
        Try
            Dim m As New ClassSendEmail()
            m.report_mark_type = rmt
            m.id_report = idx
            m.opt = "1"
            m.send_email()
            Close()
        Catch ex As Exception
            Dim err_note As String = addSlashes("Cancelled Transaction Email;id=" + idx + ";" + ex.ToString + "")
            execute_non_query("INSERT INTO tb_log_mail(report_mark_type, opt, note, log_date) VALUES(14,1, '" + err_note + "', NOW()); ", True, "", "", "", "")
        End Try
    End Sub

    Private Sub FormResendEmail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class