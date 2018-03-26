Public Class FormUserDet
    Public action As String = "-1"
    Public id As String = "-1"

    Sub viewEmployee()
        Dim query As String = "SELECT * FROM tb_m_employee "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        SLEEmployee.Properties.DataSource = Nothing
        SLEEmployee.Properties.DataSource = data
        SLEEmployee.Properties.DisplayMember = "employee_name"
        SLEEmployee.Properties.ValueMember = "id_employee"
        If data.Rows.Count.ToString >= 1 Then
            SLEEmployee.EditValue = data.Rows(0)("id_employee").ToString
        Else
            SLEEmployee.EditValue = Nothing
        End If
    End Sub

    Sub getEmp()
        Dim q As String = "SELECT employee_code FROM tb_m_employee WHERE id_employee = '" + SLEEmployee.EditValue.ToString + "' "
        Dim d As DataTable = execute_query(q, -1, True, "", "", "", "")
        TxtUsername.Text = d.Rows(0)("employee_code").ToString
    End Sub

    Sub viewRole()
        Dim query As String = "SELECT * FROM tb_role"
        viewSearchLookupQuery(SLERole, query, "id_role", "role", "id_role")
    End Sub

    Private Sub FormUserDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewEmployee()
        viewRole()
        actionLoad()
    End Sub

    Sub actionLoad()
        If action = "upd" Then
            Dim query As String = "SELECT * FROM tb_user WHERE id_user=" + id + ""
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            SLEEmployee.EditValue = data.Rows(0)("id_employee").ToString
            SLERole.EditValue = data.Rows(0)("id_role").ToString
            TxtUsername.EditValue = data.Rows(0)("username").ToString
        Else
            getEmp()
        End If
    End Sub

    Private Sub FormUserDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        getEmp()
    End Sub

    Private Sub SLEEmployee_EditValueChanged(sender As Object, e As EventArgs) Handles SLEEmployee.EditValueChanged
        Dim def As String = ""
        Try
            def = SLEEmployee.Properties.View.GetFocusedRowCellValue("employee_code").ToString
        Catch ex As Exception
        End Try
        TxtUsername.Text = def
    End Sub

    Sub insertEmp(ByVal id_employee As String)
        Dim query_cek As String = "SELECT COUNT(*) FROM tb_m_employee WHERE id_employee='" + id_employee + "' "
        Dim jum_cek As String = execute_query(query_cek, 0, True, "", "", "", "")
        If jum_cek <= 0 Then
            'insert employee
            Dim query_employee As String = "INSERT INTO tb_m_employee 
            SELECT * FROM tb_m_employee WHERE tb_m_employee.id_employee='" + id_employee + "' "
            execute_non_query(query_employee, True, "", "", "", "")
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim username As String = addSlashes(TxtUsername.Text)
        Dim id_role As String = SLERole.EditValue.ToString
        Dim id_employee As String = SLEEmployee.EditValue.ToString
        If action = "ins" Then
            'main
            Dim query As String = "INSERT INTO tb_user(id_role, id_employee, username, password)
            VALUES('" + id_role + "', '" + id_employee + "', '" + username + "', MD5('" + username + "')); SELECT LAST_INSERT_ID(); "
            id = execute_query(query, 0, True, "", "", "", "")

            'cek employee
            insertEmp(id_employee)
        Else
            Dim query As String = "UPDATE tb_user SET id_role='" + id_role + "', id_employee='" + id_employee + "', username='" + username + "', 
            password=MD5('" + username + "'), is_change='2' WHERE id_user='" + id + "' "
            execute_non_query(query, True, "", "", "", "")

            'cek employee
            insertEmp(id_employee)
        End If
        FormUser.viewUser()
        FormUser.GVUser.FocusedRowHandle = find_row(FormUser.GVUser, "id_user", id)
        action = "upd"
        Close()
    End Sub
End Class