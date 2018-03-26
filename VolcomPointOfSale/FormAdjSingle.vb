Public Class FormAdjSingle
    Public id_pop_up As String = "-1"
    Dim id_item As String = ""

    Private Sub FormAdjSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtQty.EditValue = 0
    End Sub

    Private Sub FormAdjSingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormAdjSingle_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then

        ElseIf e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub

    Private Sub TxtCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtCode.Text = "" Then
                Cursor = Cursors.WaitCursor
                FormPOSItem.id_pop_up = "1"
                FormPOSItem.ShowDialog()
                Cursor = Cursors.Default
            Else
                Cursor = Cursors.Default
                Dim i As New ClassItem()
                Dim query As String = i.queryMain("AND i.item_code='" + addSlashes(TxtCode.Text) + "' AND i.is_active=1", "1", False)
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                If data.Rows.Count > 0 Then
                    'filter
                    FormAdjOut.GVScanSum.ActiveFilterString = "[id_item]=" + data.Rows(0)("id_item").ToString + ""
                    FormAdjOut.GVScanSum.RefreshData()
                    If FormAdjOut.GVScanSum.RowCount > 0 Then
                        stopCustom("Code is already exist")
                        FormAdjOut.GVScanSum.ActiveFilterString = ""
                        TxtCode.Text = ""
                        TxtCode.Focus()
                    Else
                        FormAdjOut.GVScanSum.ActiveFilterString = ""
                        id_item = data.Rows(0)("id_item").ToString
                        TxtDesc.Text = data.Rows(0)("item_name").ToString
                        TxtSize.Text = data.Rows(0)("size").ToString
                        TxtPrice.EditValue = data.Rows(0)("price")
                        TxtCode.Enabled = False
                        TxtQty.Enabled = True
                        TxtQty.Focus()
                    End If
                Else
                    stopCustom("Code not found")
                    TxtCode.Text = ""
                    TxtCode.Focus()
                End If
                Cursor = Cursors.WaitCursor
            End If
        End If
    End Sub

    Private Sub TxtQty_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtQty.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim qty As Decimal = TxtQty.EditValue
            If qty > 0 Then
                If id_pop_up = "1" Then
                    FormAdjOut.addRows(id_item, TxtCode.Text, TxtDesc.Text, TxtSize.Text, TxtQty.EditValue, TxtPrice.EditValue)
                    Close()
                ElseIf id_pop_up = "2" Then
                    FormAdjIn.addRows(id_item, TxtCode.Text, TxtDesc.Text, TxtSize.Text, TxtQty.EditValue, TxtPrice.EditValue)
                    Close()
                End If
            End If
        End If
    End Sub


End Class