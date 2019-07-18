Public Class FormRec
    Private Sub FormRec_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormRec_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt_now As DateTime = getTimeDB()
        DEFromOwn.EditValue = dt_now
        DEUntilOwn.EditValue = dt_now
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
        Cursor = Cursors.WaitCursor
        If XTCRec.SelectedTabPageIndex = 0 Then
            If XTCOwn.SelectedTabPageIndex = 1 And GVDS.RowCount > 0 And GVDS.FocusedRowHandle >= 0 Then
                Cursor = Cursors.WaitCursor
                FormRecOwnProduct.action = "ins"
                FormRecOwnProduct.id_pl_sales_order_del = GVDS.GetFocusedRowCellValue("id_pl_sales_order_del").ToString
                FormRecOwnProduct.ShowDialog()
                Cursor = Cursors.Default
            End If
        ElseIf XTCRec.SelectedTabPageIndex = 1 Then
            FormRecDet.action = "ins"
            FormRecDet.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub edit()
        Cursor = Cursors.WaitCursor
        If XTCRec.SelectedTabPageIndex = 0 Then

        ElseIf XTCRec.SelectedTabPageIndex = 1 Then
            FormRecDet.action = "upd"
            FormRecDet.id = GVRec.GetFocusedRowCellValue("id_rec").ToString
            FormRecDet.ShowDialog()
        End If
        Cursor = Cursors.Default
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

    Sub refreshData()
        If XTCRec.SelectedTabPageIndex = 0 Then
            If XTCOwn.SelectedTabPageIndex = 0 Then
                viewRecOwn()
            ElseIf XTCOwn.SelectedTabPageIndex = 1 Then
                viewDS()
            End If
        ElseIf XTCRec.SelectedTabPageIndex = 1 Then
            viewRec()
        End If
    End Sub

    Sub exitForm()
        Close()
    End Sub

    Sub printPreview()
        FormBlack.Show()
        print(GCRec, "Product List")
        FormBlack.Close()
    End Sub

    Sub viewRecOwn()
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

        Dim cond As String = "AND (r.rec_date>='" + date_from + "' AND r.rec_date<='" + date_until + "' )"
        Dim r As New ClassRec()
        Dim query As String = r.queryMainOwn(cond, "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRecOwn.DataSource = data
        GVRecOwn.BestFitColumns()
        Cursor = Cursors.Default
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

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        refreshData()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        printPreview()
    End Sub

    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        insert()
    End Sub

    Sub viewDS()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT a.id_pl_sales_order_del, a.number, a.created_date 
        FROM (
	        SELECT d.id_pl_sales_order_del, d.number, d.created_date, (d.qty-IFNULL(r.qty,0)) AS `bal`
	        FROM tb_delivery_slip d
	        LEFT JOIN (
		        SELECT rd.id_delivery_slip, SUM(rd.qty) AS `qty`
		        FROM tb_rec_own_det rd
		        INNER JOIN tb_rec_own r ON r.id_rec_own = rd.id_rec_own
		        WHERE r.id_report_status!=5
		        GROUP BY rd.id_delivery_slip
	        ) r ON r.id_delivery_slip = d.id_delivery_slip
	        HAVING bal>0
        ) a
        GROUP BY a.id_pl_sales_order_del "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDS.DataSource = data
        GVDS.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub XTCOwn_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCOwn.SelectedPageChanged
        If XTCOwn.SelectedTabPageIndex = 0 Then
        ElseIf XTCOwn.SelectedTabPageIndex = 1 Then
            viewDS()
        End If
    End Sub

    Private Sub GVDS_DoubleClick(sender As Object, e As EventArgs) Handles GVDS.DoubleClick
        If GVDS.RowCount > 0 And GVDS.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormDeliverySlip.id = GVDS.GetFocusedRowCellValue("id_pl_sales_order_del").ToString
            FormDeliverySlip.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewRecOwn()
    End Sub
End Class