Public Class FormRec
    Private Sub FormRec_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormRec_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewRec()
    End Sub

    Private Sub FormRec_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Escape Then 'close
            Close()
        ElseIf e.KeyCode = Keys.F8 Then 'new
            insert()
        ElseIf e.KeyCode = Keys.F7 Then 'view
            edit()
        ElseIf e.KeyCode = Keys.F9 Then 'delete
            delete()
        ElseIf e.KeyCode = Keys.F10 Then 'delete
            printPreview()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub insert()
        FormRecDet.action = "ins"
        FormRecDet.ShowDialog()
    End Sub

    Sub edit()
        FormRecDet.action = "upd"
        FormRecDet.id = GVRec.GetFocusedRowCellValue("id_rec").ToString
        FormRecDet.ShowDialog()
    End Sub

    Sub delete()
        'If GVRec.FocusedRowHandle >= 0 Then
        '    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        '    If confirm = DialogResult.Yes Then
        '        Try
        '            Dim id As String = GVRec.GetFocusedRowCellValue("id_rec").ToString
        '            Dim query As String = "DELETE FROM tb_rec WHERE id_rec=" + id + " "
        '            execute_non_query(query, True, "", "", "", "")
        '            viewRec()
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
        FormBlack.Show()
        print(GCRec, "Product List")
        FormBlack.Close()
    End Sub

    Sub viewRec()
        Dim i As New ClassRec()
        Dim query As String = i.queryMain("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRec.DataSource = data
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
End Class