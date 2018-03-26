Public Class FormMasterCompany
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim bcontact_active As String = "1"

    Private Sub FormCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_company()
    End Sub

    Sub view_company()
        Dim data As DataTable = execute_query("SELECT tb_m_comp.id_comp as id_comp,tb_m_comp.comp_number as comp_number,tb_m_comp.comp_name as comp_name,tb_m_comp.address_primary as address_primary,tb_m_comp.is_active as is_active,tb_m_comp_cat.comp_cat_name as company_category FROM tb_m_comp,tb_m_comp_cat WHERE tb_m_comp.id_comp_cat=tb_m_comp_cat.id_comp_cat ORDER BY comp_name", -1, True, "", "", "", "")
        GCCompany.DataSource = data
    End Sub

    Private Sub FormCompany_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormMasterCompany_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated

    End Sub

    Private Sub FormMasterCompany_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate

    End Sub

    Private Sub GVCompany_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVCompany.DoubleClick

    End Sub

    Sub insert()
        FormMasterCompanySingle.ShowDialog()
    End Sub

    Sub edit()
        FormMasterCompanySingle.id_company = GVCompany.GetFocusedRowCellValue("id_comp").ToString
        FormMasterCompanySingle.ShowDialog()
    End Sub

    Sub delete()
        If GVCompany.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = DialogResult.Yes Then
                Try
                    Dim id As String = GVCompany.GetFocusedRowCellValue("id_comp").ToString
                    Dim query As String = "DELETE FROM tb_m_comp WHERE id_comp=" + id + " "
                    execute_non_query(query, True, "", "", "", "")
                    view_company()
                Catch ex As Exception
                    errorDelete()
                End Try
            End If
        End If
    End Sub


    Sub compContact()
        Cursor = Cursors.WaitCursor
        FormMasterCompanySingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub exitForm()
        Close()
    End Sub

    Sub printPreview()
        print(GCCompany, "Company")
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        insert()
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        edit()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        delete()
    End Sub

    Private Sub ImportExcelToolStripMenuItem_Click(sender As Object, e As EventArgs)
        compContact()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub PrintPreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        printPreview()
    End Sub

    Private Sub FormMasterCompany_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Escape Then 'close
            Close()
        ElseIf e.KeyCode = Keys.Insert Then 'new
            insert()
        ElseIf e.KeyCode = Keys.Enter Then 'edit
            edit()
        ElseIf e.KeyCode = Keys.Delete Then 'delete
            delete()
        ElseIf e.KeyCode = Keys.P AndAlso e.Modifiers = Keys.Control Then 'delete
            printPreview()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub PanelControl3_Paint(sender As Object, e As PaintEventArgs)

    End Sub


    Private Sub PCClose_Click(sender As Object, e As EventArgs)
        exitForm()
    End Sub

    Private Sub PanelControl5_Click(sender As Object, e As EventArgs) Handles PanelControl5.Click
        Close()
    End Sub
End Class