Public Class FormUserRole
    Public id As String = "-1"
    Public action As String = "-1"

    Private Sub FormUserRole_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub actionLoad()
        If action = "upd" Then
            GCData.Enabled = True
            Dim r As New ClassUser()
            Dim query_main As String = r.queryRole("AND r.id_role=" + id + "", 1)
            Dim data_main As DataTable = execute_query(query_main, -1, True, "", "", "", "")
            TxtRole.Text = data_main.Rows(0)("role").ToString

            Dim query As String = "SELECT m.id_menu, m.menu, IF(ISNULL(a.`id_role`), 'No','Yes') AS `is_allow`
            FROM tb_menu m
            LEFT JOIN tb_menu_access a ON a.id_menu = m.id_menu AND a.id_role='" + id + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCData.DataSource = data
        Else
            GCData.Enabled = False
        End If
    End Sub

    Private Sub FormUserRole_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormUserRole_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim role As String = addSlashes(TxtRole.Text)
        If action = "ins" Then
            Dim query As String = "INSERT INTO tb_role(role) VALUES('" + role + "'); SELECT LAST_INSERT_ID(); "
            id = execute_query(query, 0, True, "", "", "", "")
            FormUser.viewRole()
            FormUser.GVRole.FocusedRowHandle = find_row(FormUser.GVRole, "id_role", id)
            action = "upd"
            actionLoad()
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to give these access?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = DialogResult.Yes Then
                'main
                Dim query As String = "UPDATE tb_role SET role='" + role + "' WHERE id_role='" + id + "' "
                execute_non_query(query, True, "", "", "", "")

                'delete role
                Dim query_del As String = "DELETE FROM tb_menu_access WHERE id_role='" + id + "' "
                execute_non_query(query_del, True, "", "", "", "")

                GVData.ActiveFilterString = "[is_allow]='Yes'"
                PBC.Properties.Minimum = 0
                PBC.Properties.Maximum = GVData.RowCount - 1
                PBC.Properties.Step = 1
                PBC.Properties.PercentView = True
                For i As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                    Dim id_menu As String = GVData.GetRowCellValue(i, "id_menu").ToString
                    Dim query_acc As String = "INSERT INTO tb_menu_access VALUES('" + id + "', '" + id_menu + "') "
                    execute_non_query(query_acc, True, "", "", "", "")
                    PBC.PerformStep()
                    PBC.Update()
                Next
            End If
            FormUser.viewRole()
            FormUser.GVRole.FocusedRowHandle = find_row(FormUser.GVRole, "id_role", id)
            Close()
        End If
    End Sub
End Class