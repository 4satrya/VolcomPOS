﻿Public Class FormDeleteScan
    Public id_pop_up As String = "-1"

    Private Sub FormDeleteScan_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TxtItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtItemCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim code As String = addSlashes(TxtItemCode.Text)
            If id_pop_up = "1" Then ' rec own product
                makeSafeGV(FormRecOwnProduct.GVData)
                FormRecOwnProduct.GVData.ActiveFilterString = "[item_code]='" + code + "' "
                If FormRecOwnProduct.GVData.RowCount > 0 Then
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this item : " + TxtItemCode.Text + " - " + FormRecOwnProduct.GVData.GetFocusedRowCellValue("item_name").ToString + " ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = DialogResult.Yes Then
                        Dim id_delivery_slip As String = FormRecOwnProduct.GVData.GetFocusedRowCellValue("id_delivery_slip").ToString
                        FormRecOwnProduct.GVData.DeleteSelectedRows()
                        makeSafeGV(FormRecOwnProduct.GVData)
                        FormRecOwnProduct.GCData.RefreshDataSource()
                        FormRecOwnProduct.GVData.RefreshData()
                        FormRecOwnProduct.countQty(id_delivery_slip)
                        TxtItemCode.Text = ""
                        TxtItemCode.Focus()
                    Else
                        makeSafeGV(FormRecOwnProduct.GVData)
                        TxtItemCode.Text = ""
                        TxtItemCode.Focus()
                    End If
                Else
                    stopCustom("Code not found")
                    makeSafeGV(FormRecOwnProduct.GVData)
                    TxtItemCode.Text = ""
                    TxtItemCode.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub FormDeleteScan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub
End Class