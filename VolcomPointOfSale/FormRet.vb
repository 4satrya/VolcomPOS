﻿Public Class FormRet
    Private Sub FormRet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormRet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt_now As DateTime = getTimeDB()
        DEFromOwn.EditValue = dt_now
        DEUntilOwn.EditValue = dt_now
    End Sub

    Private Sub FormRet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Escape Then 'close
            Close()
        ElseIf e.KeyCode = Keys.F8 Then 'new
            insert()
        ElseIf e.KeyCode = Keys.F7 Then 'view
            edit()
        ElseIf e.KeyCode = Keys.F9 Then 'delete
            'delete()
        ElseIf e.KeyCode = Keys.F10 Then 'delete
            printPreview()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub insert()
        Cursor = Cursors.WaitCursor
        FormRetDet.action = "ins"
        FormRetDet.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub edit()
        Cursor = Cursors.WaitCursor
        If GVRet.FocusedRowHandle >= 0 Then
            FormRetDet.action = "upd"
            FormRetDet.id = GVRet.GetFocusedRowCellValue("id_ret").ToString
            FormRetDet.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub delete()
        'If GVRet.FocusedRowHandle >= 0 Then
        '    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        '    If confirm = DialogResult.Yes Then
        '        Try
        '            Dim id As String = GVRet.GetFocusedRowCellValue("id_ret").ToString
        '            Dim query As String = "DELETE FROM tb_ret WHERE id_ret=" + id + " "
        '            execute_non_query(query, True, "", "", "", "")
        '            viewRet()
        '        Catch ex As Exception
        '            errorDelete()
        '        End Try
        '    End If
        'End If
    End Sub

    Sub exitForm()
        Close()
    End Sub

    Sub printPreview()
        Cursor = Cursors.WaitCursor
        FormBlack.Show()
        print(GCRet, "Return List")
        FormBlack.Close()
        Cursor = Cursors.Default
    End Sub

    Sub viewRet()
        Cursor = Cursors.WaitCursor
        Dim date_from As String = ""
        Try
            date_from = DateTime.Parse(DEFromOwn.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim date_until As String = ""
        Try
            date_until = DateTime.Parse(DEUntilOwn.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim cond As String = "AND (DATE(r.ret_date)>='" + date_from + "' AND DATE(r.ret_date)<='" + date_until + "' )"

        Dim i As New ClassRet()
        Dim query As String = i.queryMain(cond, "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRet.DataSource = data
        Cursor = Cursors.Default
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

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub PrintPreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        printPreview()
    End Sub

    Private Sub PanelControlBack_Click(sender As Object, e As EventArgs) Handles PanelControlBack.Click
        Close()
    End Sub

    Private Sub PanelControlBack_MouseHover(sender As Object, e As EventArgs) Handles PanelControlBack.MouseHover
        PanelControlBack.Cursor = Cursors.Hand
    End Sub

    Private Sub PanelControlBack_MouseLeave(sender As Object, e As EventArgs) Handles PanelControlBack.MouseLeave
        PanelControlBack.Cursor = Cursors.Default
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewRet()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        viewRet()
    End Sub

    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        insert()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        printPreview()
    End Sub

    Private Sub GVRet_DoubleClick(sender As Object, e As EventArgs) Handles GVRet.DoubleClick
        If GVRet.RowCount > 0 And GVRet.FocusedRowHandle >= 0 Then
            edit()
        End If
    End Sub
End Class