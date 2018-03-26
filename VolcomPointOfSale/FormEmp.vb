Public Class FormEmp
    Private Sub FormEmp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT * FROM tb_m_employee a ORDER BY a.employee_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCEmp.DataSource = data
    End Sub

    Private Sub FormEmp_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVEmp_DoubleClick(sender As Object, e As EventArgs) Handles GVEmp.DoubleClick
        FormUser.TxtSupervisor.Text = GVEmp.GetFocusedRowCellValue("employee_name").ToString
        Close()
    End Sub
End Class