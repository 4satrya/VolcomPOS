Public Class FormAdj
    Private Sub FormAdj_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewAdjOut()
        viewAdjIn()
    End Sub

    Private Sub FormAdj_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormAdj_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
    End Sub

    Sub insert()
        Cursor = Cursors.WaitCursor
        If XTCAdj.SelectedTabPageIndex = 0 Then 'out
            FormAdjOut.action = "ins"
            FormAdjOut.ShowDialog()
        Else 'in
            FormAdjIn.action = "ins"
            FormAdjIn.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub edit()
        Cursor = Cursors.WaitCursor
        If XTCAdj.SelectedTabPageIndex = 0 Then 'out
            If GVAdjOut.FocusedRowHandle >= 0 Then
                FormAdjOut.action = "upd"
                FormAdjOut.id = GVAdjOut.GetFocusedRowCellValue("id_adj_out").ToString
                FormAdjOut.ShowDialog()
            End If
        Else 'in
            If GVAdjIn.FocusedRowHandle >= 0 Then
                FormAdjIn.action = "upd"
                FormAdjIn.id = GVAdjIn.GetFocusedRowCellValue("id_adj_in").ToString
                FormAdjIn.ShowDialog()
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Sub delete()

    End Sub

    Sub exitForm()
        Cursor = Cursors.WaitCursor
        Close()
        Cursor = Cursors.Default
    End Sub

    Sub printPreview()
        Cursor = Cursors.WaitCursor
        FormBlack.Show()
        If XTCAdj.SelectedTabPageIndex = 0 Then 'out
            print(GCAdjOut, "Adjustment Out")
        Else 'in
            print(GCAdjIn, "Adjustment In")
        End If
        FormBlack.Close()
        Cursor = Cursors.Default
    End Sub

    Sub viewAdjOut()
        Cursor = Cursors.WaitCursor
        Dim i As New ClassAdj()
        Dim query As String = i.queryMainOut("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAdjOut.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Sub viewAdjIn()
        Cursor = Cursors.WaitCursor
        Dim i As New ClassAdj()
        Dim query As String = i.queryMainIn("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAdjIn.DataSource = data
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
        exitForm()
    End Sub

    Private Sub PanelControlBack_MouseHover(sender As Object, e As EventArgs) Handles PanelControlBack.MouseHover
        PanelControlBack.Cursor = Cursors.Hand
    End Sub

    Private Sub PanelControlBack_MouseLeave(sender As Object, e As EventArgs) Handles PanelControlBack.MouseLeave
        PanelControlBack.Cursor = Cursors.Default
    End Sub
End Class