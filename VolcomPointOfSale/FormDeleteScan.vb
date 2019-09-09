Public Class FormDeleteScan
    Public id_pop_up As String = "-1"
    'scan variable
    Public cforKeyDown As Char = vbNullChar
    Public _lastKeystroke As DateTime = DateTime.Now
    Public UseKeyboard As String = "-1"
    Public speed_barcode_read As Integer = 0
    Public speed_barcode_read_timer As Integer = 0

    Private Sub FormDeleteScan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Interval = speed_barcode_read_timer
    End Sub

    Sub actionRecOwnProduct(ByVal code As String)
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
    End Sub

    Sub actionTrf(ByVal code As String)
        makeSafeGV(FormTrfDet.GVScan)
        FormTrfDet.GVScan.ActiveFilterString = "[item_code]='" + code + "' "

        If FormTrfDet.GVScan.RowCount > 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this item : " + TxtItemCode.Text + " - " + FormTrfDet.GVScan.GetFocusedRowCellValue("item_name").ToString + " ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = DialogResult.Yes Then
                FormTrfDet.GVScan.DeleteSelectedRows()
                makeSafeGV(FormTrfDet.GVScan)
                FormTrfDet.GCScan.RefreshDataSource()
                FormTrfDet.GVScan.RefreshData()
                TxtItemCode.Text = ""
                TxtItemCode.Focus()
            Else
                makeSafeGV(FormTrfDet.GVScan)
                TxtItemCode.Text = ""
                TxtItemCode.Focus()
            End If
        Else
            stopCustom("Code not found")
            makeSafeGV(FormTrfDet.GVScan)
            TxtItemCode.Text = ""
            TxtItemCode.Focus()
        End If
    End Sub

    Sub actionReturn(ByVal code As String)
        makeSafeGV(FormRetDet.GVScan)
        FormRetDet.GVScan.ActiveFilterString = "[item_code]='" + code + "' "

        If FormRetDet.GVScan.RowCount > 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this item : " + TxtItemCode.Text + " - " + FormRetDet.GVScan.GetFocusedRowCellValue("item_name").ToString + " ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = DialogResult.Yes Then
                FormRetDet.GVScan.DeleteSelectedRows()
                makeSafeGV(FormRetDet.GVScan)
                FormRetDet.GCScan.RefreshDataSource()
                FormRetDet.GVScan.RefreshData()
                TxtItemCode.Text = ""
                TxtItemCode.Focus()
            Else
                makeSafeGV(FormRetDet.GVScan)
                TxtItemCode.Text = ""
                TxtItemCode.Focus()
            End If
        Else
            stopCustom("Code not found")
            makeSafeGV(FormRetDet.GVScan)
            TxtItemCode.Text = ""
            TxtItemCode.Focus()
        End If
    End Sub

    Private Sub TxtItemCode_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtItemCode.KeyUp
        If UseKeyboard = "2" Then
            'barcode scanner
            If Len(TxtItemCode.Text) > 1 Then
                If cforKeyDown <> ChrW(e.KeyCode) OrElse cforKeyDown = vbNullChar Then
                    cforKeyDown = vbNullChar
                    TxtItemCode.Text = ""
                    Return
                End If


                Dim elapsed As TimeSpan = DateTime.Now - _lastKeystroke
                If elapsed.TotalMilliseconds > speed_barcode_read Then TxtItemCode.Text = ""

                If e.KeyCode = Keys.[Return] AndAlso TxtItemCode.Text.Count > 0 Then
                    Dim code As String = addSlashes(TxtItemCode.Text)
                    If id_pop_up = "1" Then ' rec own product
                        actionRecOwnProduct(code)
                    ElseIf id_pop_up = "2" Then 'transfer
                        actionTrf(code)
                    ElseIf id_pop_up = "3" Then 'return
                        actionReturn(code)
                    End If
                End If

            End If
            _lastKeystroke = DateTime.Now
        Else
            'keyboard
            If e.KeyCode = Keys.[Return] AndAlso TxtItemCode.Text.Count > 0 Then
                Dim code As String = addSlashes(TxtItemCode.Text)
                If id_pop_up = "1" Then ' rec own product
                    actionRecOwnProduct(code)
                ElseIf id_pop_up = "2" Then 'transfer
                    actionTrf(code)
                ElseIf id_pop_up = "3" Then 'return
                    actionReturn(code)
                End If
            End If
        End If
    End Sub

    Private Sub TxtItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtItemCode.KeyDown
        cforKeyDown = ChrW(e.KeyCode)
    End Sub

    Private Sub FormDeleteScan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If UseKeyboard = "2" Then
            TxtItemCode.Text = ""
            Timer1.Stop()
        End If
    End Sub

    Private Sub TxtItemCode_TextChanged(sender As Object, e As EventArgs) Handles TxtItemCode.TextChanged
        If UseKeyboard = "2" Then
            Timer1.Stop()
            Timer1.Start()
        End If
    End Sub
End Class