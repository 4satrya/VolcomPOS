Public Class FormLoginInv
    Private Sub FormLoginInv_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormLoginInv_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnSignIn_Click(sender As Object, e As EventArgs) Handles BtnSignIn.Click
        signIn()
    End Sub

    Sub signIn()
        If TxtUsername.Text = "" Or TxtPass.Text = "" Then
            stopCustom("Username or password can't blank")
        Else
            Dim query As String
            Dim username As String = addSlashes(TxtUsername.Text)
            Dim password As String = addSlashes(TxtPass.Text)
            Dim data As DataTable
            Try
                Cursor = Cursors.WaitCursor
                Dim u As New ClassUser()
                query = String.Format(u.queryMain("AND u.username='{0}' AND u.password=MD5('{1}')", "1"), username, password)
                data = execute_query(query, -1, True, "", "", "", "")
                If data.Rows.Count > 0 Then
                    id_user = data.Rows(0)("id_user").ToString
                    id_role_login = data.Rows(0)("id_role").ToString
                    role_login = data.Rows(0)("role").ToString
                    name_user = data.Rows(0)("employee_name").ToString
                    username_user = data.Rows(0)("username").ToString
                    id_employee_user = data.Rows(0)("id_employee").ToString
                    is_change_pass_user = data.Rows(0)("is_change").ToString

                    Close()
                    FormHome.ShowDialog()
                Else
                    stopCustom("Login failure, please check your input !")
                End If
                Cursor = Cursors.Default
            Catch ex As Exception
                stopCustom(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Close()
        FormFront.Opacity = 100
    End Sub

    Private Sub TxtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtUsername.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtPass.Focus()
        End If
    End Sub

    Private Sub TxtPass_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtPass.KeyDown
        If e.KeyCode = Keys.Enter Then
            signIn()
        End If
    End Sub

    Private Sub FormLoginInv_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            TxtUsername.Text = "catur"
            TxtPass.Text = "catur"
        End If
    End Sub
End Class