Public Class FormHome
    Private Sub FormHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'menu config
        Dim apps As New ClassUser()
        apps.showMenu() 'show menu

        'apply form general setup
        apply_skin()
        setLabelUser()
        My.Application.ChangeCulture("en-US")
        My.Application.Culture.NumberFormat.NumberDecimalSeparator = ","
        My.Application.Culture.NumberFormat.NumberGroupSeparator = "."
        WindowState = FormWindowState.Maximized
        Opacity = 100

        If is_change_pass_user = "2" Then
            FormAccount.ShowDialog()
        End If
    End Sub

    Sub setDBInfo()
        'db conn info
        Dim el As DevExpress.XtraEditors.TileItemElement = TIDB.Elements(1)
        el.Text = app_host
        el = TIDB.Elements(2)
        el.Text = app_database
    End Sub


    Private Sub TileItem10_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TIExit.ItemClick
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to sign out your account?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = DialogResult.Yes Then
            logout()
        End If
    End Sub

    Sub logout()
        id_user = 0
        id_comp_user = 0
        id_employee_user = 0
        id_role_login = 0
        role_login = 0
        id_departement_user = 0
        username_user = 0
        name_user = 0
        Close()
        FormFront.info()
        FormFront.Opacity = 100
        FormFront.BringToFront()
    End Sub

    Private Sub TileItem2_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TIUser.ItemClick
        Cursor = Cursors.WaitCursor
        FormUser.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub setLabelUser()
        Dim u As New ClassUser()
        LabelEmployeeLogin.Text = name_user
        LabelRoleLogin.Text = role_login
    End Sub

    Private Sub TILogout_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TILogout.ItemClick
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to logout this system?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = DialogResult.Yes Then
            Dim lg As New ClassUser()
            lg.logout()
        End If
    End Sub

    Private Sub FormHome_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then 'close
            Close()
        End If
    End Sub

    Private Sub TIProduct_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TIProduct.ItemClick
        Cursor = Cursors.WaitCursor
        FormItem.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub TINotif_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TICompany.ItemClick
        Cursor = Cursors.WaitCursor
        FormMasterCompany.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub TIRec_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TIRec.ItemClick
        Cursor = Cursors.WaitCursor
        FormRec.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub TIStock_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TIStock.ItemClick
        Cursor = Cursors.WaitCursor
        FormStock.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub TIRet_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TIRet.ItemClick
        Cursor = Cursors.WaitCursor
        FormRet.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub TITrf_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TITrf.ItemClick
        Cursor = Cursors.WaitCursor
        FormTrf.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub TIDaily_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TIDaily.ItemClick
        Cursor = Cursors.WaitCursor
        FormReportDaily.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub TITransDetail_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TITransDetail.ItemClick
        Cursor = Cursors.WaitCursor
        FormReportTransDetail.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub TITransSum_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TITransSum.ItemClick
        Cursor = Cursors.WaitCursor
        FormReportTransSum.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub TICopyReceipt_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TICopyReceipt.ItemClick
        Cursor = Cursors.WaitCursor
        FormReportCopyReceipt.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub TIStockOpname_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TIStockOpname.ItemClick
        Cursor = Cursors.WaitCursor
        FormSO.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub TIAdj_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TIAdj.ItemClick
        Cursor = Cursors.WaitCursor
        FormAdj.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormHome_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub TIAccount_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TIAccount.ItemClick
        Cursor = Cursors.WaitCursor
        FormAccount.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class