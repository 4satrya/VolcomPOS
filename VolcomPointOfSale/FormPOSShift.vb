Public Class FormPOSShift
    Dim id_pos_dev As String = "-1"
    Private Sub FormPOSShift_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
        If FormPOS.id_shift = "-1" Then
            FormPOS.Close()
        End If
    End Sub

    Private Sub FormPOSShift_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtUsername.Text = username_user
        TxtName.Text = name_user
        DEDate.EditValue = getTimeDB()
        TxtShift.Text = execute_query("SELECT get_shift(2)", 0, True, "", "", "", "")
        TxtShiftName.Text = execute_query("SELECT get_shift(3)", 0, True, "", "", "", "")

        'default cast
        Dim dt_cash As DataTable = execute_query("SELECT default_cash FROM tb_opt", -1, True, "", "", "", "")
        TxtCash.EditValue = dt_cash.Rows(0)("default_cash")

        'pos device
        Dim comp As New ClassPOS()
        Dim dt_comp As DataTable = comp.getPOSDev()
        TxtPOS.Text = dt_comp.Rows(0)("pos_dev").ToString
        id_pos_dev = dt_comp.Rows(0)("id_pos_dev").ToString
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Dim cash As String = decimalSQL(TxtCash.EditValue.ToString)
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Initializing OK ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = DialogResult.Yes Then
            Try
                Dim query As String = "INSERT INTO tb_shift(id_shift_type, id_user, id_pos_dev, open_shift, cash, is_open) 
                VALUES(get_shift(1), '" + id_user + "','" + id_pos_dev + "', NOW(), '" + cash + "', '1'); SELECT LAST_INSERT_ID(); "
                FormPOS.id_shift = execute_query(query, 0, True, "", "", "", "")
                FormPOS.shift()
                Close()
            Catch ex As Exception
                stopCustom(ex.ToString)
            End Try
        End If
    End Sub
End Class