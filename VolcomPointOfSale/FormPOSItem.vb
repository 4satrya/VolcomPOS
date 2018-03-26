Public Class FormPOSItem
    Public id_pop_up As String = "-1"

    Private Sub FormPOSItem_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormPOSItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As New ClassItem()
        Dim query As String = i.queryMainUpd("AND i.is_active=1 ")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItem.DataSource = data
    End Sub

    Private Sub FormPOSItem_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            If id_pop_up = "-1" Then 'pos
                FormPOS.TxtItemCode.Text = GVItem.GetFocusedRowCellValue("item_code").ToString
            ElseIf id_pop_up = "1" Then 'adjusment
                FormAdjSingle.TxtCode.Text = GVItem.GetFocusedRowCellValue("item_code").ToString
            End If
            Close()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
End Class