Public Class FormDept
    Private Sub FormDept_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormDept_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim qopt As String = "SELECT * FROM tb_opt"
        Dim dopt As DataTable = execute_query(qopt, -1, True, "", "", "", "")
        Dim query As String = "SELECT * FROM tb_m_departement"
        Dim data As DataTable = execute_query(query, -1, False, dopt.Rows(0)("host_main").ToString, dopt.Rows(0)("username_main").ToString, dopt.Rows(0)("pass_main").ToString, dopt.Rows(0)("db_main").ToString)
        GCDept.DataSource = data
    End Sub

    Private Sub GVDept_DoubleClick(sender As Object, e As EventArgs) Handles GVDept.DoubleClick
        FormUser.TxtOutletId.Text = GVDept.GetFocusedRowCellValue("id_departement").ToString
        FormUser.TxtOutletName.Text = GVDept.GetFocusedRowCellValue("departement").ToString.ToUpper
        Close()
    End Sub
End Class