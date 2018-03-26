Public Class FormPOSRefund
    Private Sub FormPOSRefund_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query_last_trx As String = "SELECT pos_number FROM tb_pos WHERE id_pos_cat=1 AND id_pos_status=2 ORDER BY id_pos DESC LIMIT 1"
        TextEdit1.Text = execute_query(query_last_trx, 0, True, "", "", "", "")
    End Sub

    Private Sub FormPOSRefund_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim pos_number As String = addSlashes(TextEdit1.Text.ToString)
            If pos_number = "" Then
                stopCustom("Please input transaction number")
            Else
                Dim query As String = "SELECT id_pos,total FROM tb_pos WHERE id_pos_cat=1 AND id_pos_status=2 AND pos_number='" + pos_number + "'"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                If data.Rows.Count > 0 Then
                    'check
                    Dim query_check As String = "SELECT COUNT(*) FROM tb_pos WHERE id_pos_ref='" + data.Rows(0)("id_pos").ToString + "'"
                    Dim jum_check As String = execute_query(query_check, 0, True, "", "", "", "")
                    If jum_check > "0" Then
                        stopCustom("#" + pos_number + " has been refund")
                        TextEdit1.Focus()
                    Else
                        FormPOS.id = data.Rows(0)("id_pos").ToString
                        FormPOS.new_trans = True
                        FormPOS.actionLoad()
                        FormPOS.showDisplay("Total :", "-", FormPOS.TxtTotal.Text)
                        Close()
                    End If
                Else
                    stopCustom("Transaction not found")
                End If
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub

    Private Sub FormPOSRefund_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class