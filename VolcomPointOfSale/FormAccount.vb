Public Class FormAccount
    Private Sub TxtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtUsername.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtPass.Focus()
        End If
    End Sub

    Private Sub TxtPassConfirm_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtPassConfirm.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnSignIn.Focus()
        End If
    End Sub

    Private Sub BtnSignIn_Click(sender As Object, e As EventArgs) Handles BtnSignIn.Click
        Dim username As String = addSlashes(TxtUsername.Text)
        Dim pass As String = addSlashes(TxtPass.Text)
        Dim pass_confirm As String = addSlashes(TxtPassConfirm.Text)

        Dim u As New ClassUser()
        Dim dt As DataTable = execute_query(u.queryMain("AND u.username='" + username + "' AND u.password='" + pass + "' ", "1"), -1, True, "", "", "", "")
        Dim check As Boolean = False
        If dt.Rows.Count > 0 Then
            check = False
        Else
            check = True
        End If

        If username = "" Or pass = "" Or pass_confirm = "" Then
            stopCustom("Data can't blank")
        ElseIf pass <> pass_confirm Then
            stopCustom("Confirm password not match")
        ElseIf Not check Then
            stopCustom("Username & password already exists")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to continue this process?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = DialogResult.Yes Then
                Dim query As String = "UPDATE tb_user SET `username`='" + username + "', `password`=MD5('" + pass + "'), is_change=1 WHERE id_user=" + id_user + " "
                execute_non_query(query, True, "", "", "", "")
                Close()
                FormHome.logout()
            End If
        End If
    End Sub

    Private Sub FormAccount_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
        If is_change_pass_user = "2" Then
            FormHome.logout()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub TxtPass_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtPass.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtPassConfirm.Focus()
        End If
    End Sub

End Class